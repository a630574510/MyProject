using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Citic.Model;
using System.Text;
using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Citic_Web
{
    public class BasePage : Page
    {
        private static Citic.BLL.UserLog UserLogBll = null;
        //当前用户
        private User _CurrentUser;
        //部门
        private string _Department;

        /// <summary>
        /// 当前用户
        /// </summary>
        public User CurrentUser
        {
            set { this._CurrentUser = value; }
            get { return _CurrentUser; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            //设置网站的跟路径
            //AuthProcess.SetRootDirectory(Server.HtmlEncode(Request.ApplicationPath));

            User user = null;
            user = AuthProcess.GetAuthenticateUser(true);
            CurrentUser = user;
            this.Department = AuthProcess.GetAuthenticateDept(true);
            base.OnInit(e);
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }
        public string RequestValue(string Item, string defalutvalue)
        {
            string ItemValue = null;
            ItemValue = HttpContext.Current.Request.QueryString[Item];
            ItemValue = (ItemValue == null) ? defalutvalue : ItemValue.Trim();
            return ItemValue;
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public string RequestValue(string Item)
        {
            return RequestValue(Item, "");
        }

        /// <summary>
        /// 将时间格式化为字符串
        /// 如：“2013-12-20 11:29:43”
        /// 为：“2013-12-20”
        /// 要求年限 > 2000
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ConvertDateTimeToUI(DateTime dt)
        {
            if (dt.Year > 2000)
                return dt.ToString("yyyy-MM-dd");
            else
                return string.Empty;
        }

        /// <summary>
        /// 将时间格式化为字符串
        /// 如：“2013-12-20 11:29:43”
        /// 为：“20131220112943”
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected string ConvertLongDateTimeToUI(DateTime dt)
        {
            if (dt.Year > 1900)
                return dt.ToString("yyyyMMddHHmmss");
            else
                return string.Empty;
        }
        /// <summary>
        /// 将时间格式化为字符串
        /// 如：“2013-12-20 11:29:43”
        /// 为：“20131220”
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected string ConvertShortDateTimeToUI(DateTime dt)
        {
            if (dt.Year > 1900)
                return dt.ToString("yyyyMMdd");
            else
                return string.Empty;
        }

        public void WriteCookie(string Key, string Value, int Minutes)
        {
            HttpCookie coki = new HttpCookie(Key);
            coki.Value = Value;
            coki.Expires = System.DateTime.Now.AddMinutes(Minutes);
            Response.Cookies.Add(coki);
        }

        public void WriteCookie(string Key, string Value)
        {
            WriteCookie(Key, Value, 30);
        }

        public void WriteUserLog(int UserID, int MenuId, string IPAddress, int CompanyId, int DepartmentId, string RoleId)
        {
            if (UserLogBll == null)
            {
                UserLogBll = new Citic.BLL.UserLog();
            }
            Citic.Model.UserLog UserLogInfo = new Citic.Model.UserLog();
            UserLogInfo.UserID = UserID;
            UserLogInfo.ActionID = MenuId;
            UserLogInfo.IPAddress = IPAddress;
            UserLogInfo.CompanyID = CompanyId;
            UserLogInfo.DeptID = DepartmentId;
            UserLogInfo.ActionTime = DateTime.Now;
            UserLogInfo.RoleID = int.Parse(RoleId);
            UserLogBll.Add(UserLogInfo);
        }

        public string GetGridTableHtml(Grid grid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");

            sb.Append("<tr>");
            foreach (GridColumn column in grid.Columns)
            {
                sb.AppendFormat("<td>{0}</td>", column.HeaderText);
            }
            sb.Append("</tr>");


            foreach (GridRow row in grid.Rows)
            {
                sb.Append("<tr>");
                foreach (object value in row.Values)
                {
                    string html = value.ToString();
                    // 处理CheckBox
                    if (html.Contains("box-grid-static-checkbox"))
                    {
                        if (html.Contains("box-grid-static-checkbox-uncheck"))
                        {
                            html = "×";
                        }
                        else
                        {
                            html = "√";
                        }
                    }

                    // 处理图片
                    if (html.Contains("<img"))
                    {
                        string prefix = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "");
                        html = html.Replace("src=\"", "src=\"" + prefix);
                    }

                    sb.AppendFormat("<td>{0}</td>", html);
                }
                sb.Append("</tr>");
            }

            sb.Append("</table>");

            return sb.ToString();
        }

        #region 将FineUI.Grid中显示的数据转换成DataTable--乔春羽
        /// <summary>
        /// 将FineUI.Grid中显示的数据转换成DataTable
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        protected DataTable GetTableForGrid(FineUI.Grid grid)
        {
            DataTable dt = new DataTable(); ;
            foreach (FineUI.GridColumn col in grid.Columns)
            {
                DataColumn dc = new DataColumn();
                if (col.HeaderText != "编辑" || col.HeaderText != "删除")
                {
                    dc.ColumnName = col.HeaderText;
                }
                dt.Columns.Add(dc);
            }
            foreach (FineUI.GridRow row in grid.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (FineUI.GridColumn col in grid.Columns)
                {
                    if (col.HeaderText != "编辑" || col.HeaderText != "删除")
                    {
                        string value = row.Values[col.ColumnIndex];
                        if (value.IndexOf(">") > 0)
                        {
                            value = value.Substring(value.IndexOf(">") + 1);
                            value = value.Substring(0, value.LastIndexOf("<"));

                        }
                        dr[col.ColumnIndex] = value;
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 将DataTable中的英文表头
        /// 改成
        /// FineUI.Grid中显示的表头，
        /// 并且删除多余的列
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="row"></param>
        protected void ModifyTableHeaderByGrid(FineUI.Grid grid, DataTable dt)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                DataColumn col = dt.Columns[i];
                bool isHave = false;
                foreach (FineUI.GridColumn gc in grid.Columns)
                {
                    if (col.ColumnName == gc.ColumnID)
                    {
                        col.ColumnName = gc.HeaderText;
                        isHave = true;
                        break;
                    }
                }
                if (!isHave)
                {
                    dt.Columns.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// 得到Grid表的ColumnID
        /// （即，要查询的数据库列集合）
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        protected string[] GetGridColumnIDForGrid(FineUI.Grid grid)
        {
            List<string> cols = new List<string>();
            foreach (FineUI.GridColumn col in grid.Columns)
            {
                cols.Add(col.ColumnID);
            }
            return cols.ToArray();
        }
        #endregion

        #region 扩展方法，页面上获取隐藏域中的页码--乔春羽
        protected void SyncSelectedRowIndexArrayToHiddenField(FineUI.Grid grid, FineUI.HiddenField hf)
        {
            List<string> ids = GetSelectedRowIndexArrayFromHiddenField(hf);

            List<int> selectedRows = new List<int>();
            if (grid.SelectedRowIndexArray != null && grid.SelectedRowIndexArray.Length > 0)
            {
                selectedRows = new List<int>(grid.SelectedRowIndexArray);
            }

            for (int i = 0, count = Math.Min(grid.PageSize, (grid.RecordCount - grid.PageIndex * grid.PageSize)); i < count; i++)
            {
                string id = grid.DataKeys[i][0].ToString();
                if (selectedRows.Contains(i))
                {
                    if (!ids.Contains(id))
                    {
                        ids.Add(id);
                    }
                }
                else
                {
                    if (ids.Contains(id))
                    {
                        ids.Remove(id);
                    }
                }

            }

            hf.Text = new JArray(ids).ToString(Formatting.None);
        }
        protected List<string> GetSelectedRowIndexArrayFromHiddenField(FineUI.HiddenField hf)
        {
            JArray idsArray = new JArray();

            string currentIDS = hf.Text.Trim();
            if (!String.IsNullOrEmpty(currentIDS))
            {
                idsArray = JArray.Parse(currentIDS);
            }
            else
            {
                idsArray = new JArray();
            }
            return new List<string>(idsArray.ToObject<string[]>());
        }
        protected void UpdateSelectedRowIndexArray(FineUI.Grid grid, FineUI.HiddenField hf)
        {
            List<string> ids = GetSelectedRowIndexArrayFromHiddenField(hf);

            List<int> nextSelectedRowIndexArray = new List<int>();
            for (int i = 0, count = Math.Min(grid.PageSize, (grid.RecordCount - grid.PageIndex * grid.PageSize)); i < count; i++)
            {
                string id = grid.DataKeys[i][0].ToString();
                if (ids.Contains(id))
                {
                    nextSelectedRowIndexArray.Add(i);
                }
            }
            grid.SelectedRowIndexArray = nextSelectedRowIndexArray.ToArray();
        }
        #endregion

        #region 业务逻辑层变量--乔春羽
        private Citic.BLL.Dealer dealerBll = null;
        /// <summary>
        /// 经销商业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.Dealer DealerBll
        {
            get
            {
                if (dealerBll == null)
                {
                    dealerBll = new Citic.BLL.Dealer();
                }
                return dealerBll;
            }
        }
        private Citic.BLL.Bank bankBll = null;

        /// <summary>
        /// 合作行业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.Bank BankBll
        {
            get
            {
                if (bankBll == null)
                {
                    bankBll = new Citic.BLL.Bank();
                }
                return bankBll;
            }
        }

        private Citic.BLL.Draft draftBll = null;

        /// <summary>
        /// 汇票业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.Draft DraftBll
        {
            get
            {
                if (draftBll == null)
                {
                    draftBll = new Citic.BLL.Draft();
                }
                return draftBll;
            }
        }

        private Citic.BLL.Linkman linkmanBll = null;

        /// <summary>
        /// 联系人业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.Linkman LinkmanBll
        {
            get
            {
                if (linkmanBll == null)
                {
                    linkmanBll = new Citic.BLL.Linkman();
                }
                return linkmanBll;
            }
        }

        private Citic.BLL.Factory factoryBll = null;

        /// <summary>
        /// 厂商业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.Factory FactoryBll
        {
            get
            {
                if (factoryBll == null)
                {
                    factoryBll = new Citic.BLL.Factory();
                }
                return factoryBll;
            }
        }

        private Citic.BLL.Supervisor supervisorBll = null;

        /// <summary>
        /// 供应商业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.Supervisor SupervisorBll
        {
            get
            {
                if (supervisorBll == null)
                {
                    supervisorBll = new Citic.BLL.Supervisor();
                }
                return supervisorBll;
            }
        }

        private Citic.BLL.Brand brandBll = null;

        /// <summary>
        /// 品牌业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.Brand BrandBll
        {
            get
            {
                if (brandBll == null)
                {
                    brandBll = new Citic.BLL.Brand();
                }
                return brandBll;
            }
        }

        private Citic.BLL.Car carBll = null;
        /// <summary>
        /// 质押物（车）业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.Car CarBll
        {
            get
            {
                if (carBll == null)
                {
                    carBll = new Citic.BLL.Car();
                }
                return carBll;
            }
        }

        private Citic.BLL.Storage storageBll = null;

        /// <summary>
        /// 仓库业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.Storage StorageBll
        {
            get
            {
                if (storageBll == null)
                {
                    storageBll = new Citic.BLL.Storage();
                }
                return storageBll;
            }
        }

        private Citic.BLL.DBSX _DBSXBll = null;

        /// <summary>
        /// 待办事项业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.DBSX DBSXBll
        {
            get
            {
                if (_DBSXBll == null)
                {
                    _DBSXBll = new Citic.BLL.DBSX();
                }
                return _DBSXBll;
            }
        }

        private Citic.BLL.Supervisor_History _Super_HistoryBll = null;

        /// <summary>
        /// 监管员历史记录业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.Supervisor_History Super_HistoryBll
        {
            get
            {
                if (_Super_HistoryBll == null)
                {
                    _Super_HistoryBll = new Citic.BLL.Supervisor_History();
                }
                return _Super_HistoryBll;
            }
        }

        private Citic.BLL.Menu _MenuBll = null;

        /// <summary>
        /// 权限业务信息（菜单项）--乔春羽
        /// </summary>
        protected Citic.BLL.Menu MenuBll
        {
            get
            {
                if (_MenuBll == null)
                {
                    _MenuBll = new Citic.BLL.Menu();
                }
                return _MenuBll;
            }
        }

        private Citic.BLL.Dealer_Bank _Dealer_Bank = null;

        /// <summary>
        /// 银行经销商合作业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.Dealer_Bank Dealer_BankBll
        {
            get
            {
                if (_Dealer_Bank == null)
                {
                    _Dealer_Bank = new Citic.BLL.Dealer_Bank();
                }
                return _Dealer_Bank;
            }
        }

        private Citic.BLL.StockError _StockErrorBll = null;

        /// <summary>
        /// 日查库业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.StockError StockErrorBll
        {
            get
            {
                if (_StockErrorBll == null)
                {
                    _StockErrorBll = new Citic.BLL.StockError();
                }
                return _StockErrorBll;
            }
        }

        private Citic.BLL.CarErrorCount _CECBll = null;

        /// <summary>
        /// 车辆异常统计业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.CarErrorCount CECBLL
        {
            get
            {
                if (_CECBll == null)
                {
                    _CECBll = new Citic.BLL.CarErrorCount();
                }
                return _CECBll;
            }
        }

        private Citic.BLL.HZXMGJ _HZXMGJBLL = null;

        /// <summary>
        /// 合作项目跟进业务信息--乔春羽
        /// </summary>
        public Citic.BLL.HZXMGJ HZXMGJBLL
        {
            get
            {
                if (_HZXMGJBLL == null)
                {
                    _HZXMGJBLL = new Citic.BLL.HZXMGJ();
                }
                return _HZXMGJBLL;
            }
        }

        private List<Citic.Model.Dealer_Bank> _Banks = null;

        /// <summary>
        /// 所选的合作银行集合--乔春羽
        /// </summary>
        protected List<Citic.Model.Dealer_Bank> Banks
        {
            get
            {
                if (_Banks == null)
                {
                    if (Session["bank_jsons"] != null)
                    {
                        _Banks = Session["bank_jsons"] as List<Citic.Model.Dealer_Bank>;
                    }
                    else
                    {
                        _Banks = new List<Citic.Model.Dealer_Bank>();
                        Session.Add("bank_jsons", _Banks);
                    }
                }
                return _Banks;
            }
        }

        private Citic.BLL.Role _RoleBll = null;

        /// <summary>
        /// 角色业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.Role RoleBll
        {
            get
            {
                if (_RoleBll == null)
                {
                    _RoleBll = new Citic.BLL.Role();
                }
                return _RoleBll;
            }
        }

        private Citic.BLL.User _UserBll = null;

        /// <summary>
        /// 用户业务信息--乔春羽
        /// </summary>
        protected Citic.BLL.User UserBll
        {
            get
            {
                if (_UserBll == null)
                {
                    _UserBll = new Citic.BLL.User();
                }
                return _UserBll;
            }
        }

        private Citic.BLL.RiskQuesDay _RQDBLL = null;

        /// <summary>
        /// 每日风控问题追踪业务信息--乔春羽
        /// </summary>
        public Citic.BLL.RiskQuesDay RQDBLL
        {
            get
            {
                if (_RQDBLL == null)
                {
                    _RQDBLL = new Citic.BLL.RiskQuesDay();
                }
                return _RQDBLL;
            }
        }

        private Citic.BLL.RiskQuestion _RQBLL = null;

        protected Citic.BLL.RiskQuestion RQBLL
        {
            get
            {
                if (_RQBLL == null)
                {
                    _RQBLL = new Citic.BLL.RiskQuestion();
                }
                return _RQBLL;
            }
        }

        private Citic.BLL.RisksSolveDocuments _RSDBLL;

        public Citic.BLL.RisksSolveDocuments RSDBLL
        {
            get
            {
                if (_RSDBLL == null)
                {
                    _RSDBLL = new Citic.BLL.RisksSolveDocuments();
                }
                return _RSDBLL;
            }
        }

        private Citic.BLL.QueryWH _QueryWH;
        /// <summary>
        /// 查库频率--乔春羽
        /// </summary>
        public Citic.BLL.QueryWH QueryWH
        {
            get
            {
                if (_QueryWH == null)
                {
                    _QueryWH = new Citic.BLL.QueryWH();
                }
                return _QueryWH;
            }
        }

        private Citic.BLL.XDBG _XDBGBBLL;

        /// <summary>
        /// “巡店报告”--乔春羽
        /// </summary>
        protected Citic.BLL.XDBG XDBGBBLL
        {
            get
            {
                if (_XDBGBBLL == null) _XDBGBBLL = new Citic.BLL.XDBG();
                return _XDBGBBLL;
            }
        }

        private Citic.BLL.XDBG_Record _XDBG_RecordBLL;
        /// <summary>
        /// “巡店报告”操作记录
        /// </summary>
        protected Citic.BLL.XDBG_Record XDBG_RecordBLL
        {
            get
            {
                if (_XDBG_RecordBLL == null)
                    _XDBG_RecordBLL = new Citic.BLL.XDBG_Record();
                return _XDBG_RecordBLL;
            }
        }

        private Citic.BLL.UserMapping _UMBLL = null;
        /// <summary>
        /// 用户对应银行--乔春羽
        /// </summary>
        public Citic.BLL.UserMapping UMBLL
        {
            get
            {
                if (_UMBLL == null)
                {
                    _UMBLL = new Citic.BLL.UserMapping();
                }
                return _UMBLL;
            }
        }

        private Citic.BLL.DeptToRole _DeptToRole = null;

        public Citic.BLL.DeptToRole DeptToRole
        {
            get
            {
                if (_DeptToRole == null)
                {
                    _DeptToRole = new Citic.BLL.DeptToRole();
                }
                return _DeptToRole;
            }
        }

        #endregion

        #region 操作Excel文件的工具类变量--乔春羽
        private Citic_Web.ExcelEditHelper _ExcelEditHelper;

        /// <summary>
        /// 操作Excel文件的工具类
        /// </summary>
        protected Citic_Web.ExcelEditHelper ExcelEditHelper
        {
            get
            {
                if (_ExcelEditHelper == null)
                {
                    _ExcelEditHelper = new ExcelEditHelper();
                }
                return _ExcelEditHelper;
            }
        }

        private Citic_Web.Common.InsertPicToExcel _InsertPicToExcel;

        /// <summary>
        /// 向Excel文件中插入图片的帮助类
        /// </summary>
        public Citic_Web.Common.InsertPicToExcel InsertPicToExcel
        {
            get
            {
                if (_InsertPicToExcel == null) _InsertPicToExcel = new Common.InsertPicToExcel();
                return _InsertPicToExcel;
            }
        }

        protected void CloseInsertPicToExcel()
        {
            _InsertPicToExcel.Dispose();
            _InsertPicToExcel = null;
        }
        protected void CloseExcelEditHelper()
        {
            _ExcelEditHelper.Close();
            _ExcelEditHelper = null;
            GC.Collect();
        }
        #endregion

        #region 根据当前登陆用户的角色，获取用户的权限--乔春羽
        /// <summary>
        /// 根据当前登陆用户的角色，获取用户的权限
        /// </summary>
        /// <param name="isNavigation">是否是菜单项</param>
        /// <returns></returns>
        protected DataTable GetMenusByCurrentUserRoleID(bool isNavigation)
        {
            DataTable dt = null;
            dt = MenuBll.GetMenusByRoleID(CurrentUser.RoleId.ToString(), isNavigation).Tables[0];
            return dt;
        }

        /// <summary>
        /// 根据当前登陆用户的角色，获取用户的权限
        /// </summary>
        /// <returns></returns>
        protected DataTable GetMenusByCurrentUserRoleID()
        {
            DataTable dt = null;
            dt = MenuBll.GetMenusByRoleID(CurrentUser.RoleId.ToString()).Tables[0];
            return dt;
        }
        #endregion

        #region 给下拉框控件插入选项--乔春羽(2013.8.9)
        /// <summary>
        /// 给下拉框控件新增“请选择”选项
        /// </summary>
        /// <param name="ddl">控件对象</param>
        /// <param name="text">显示的文本</param>
        /// <param name="value">隐藏的值</param>
        /// <param name="position">要插入的位置</param>
        protected void AddItemByInsert(FineUI.DropDownList ddl, string text, string value, int position)
        {
            if (ddl != null)
            {
                if (position >= 0)
                {
                    ddl.Items.Insert(position, new FineUI.ListItem(text, value));
                }
                else
                {
                    FineUI.ListItem item = new FineUI.ListItem(text, value);
                    ddl.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// 向DropDownList中插入项
        /// </summary>
        /// <param name="index">要插入的位置</param>
        /// <param name="text">显示的值</param>
        /// <param name="value">隐藏的值</param>
        /// <param name="ddl">要插入项的控件</param>
        protected void AddItemByInsert(int index, string text, string value, System.Web.UI.WebControls.DropDownList ddl)
        {
            if (text != null && value != null && ddl != null)
            {
                System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem(text, value);
                if (index >= 0)
                {
                    ddl.Items.Insert(index, item);
                }
                else
                {
                    ddl.Items.Add(item);
                }
            }
        }
        #endregion

        #region 弹框--乔春羽(2014.1.3)
        protected void AlertShow(string message)
        {
            Alert.Show(message);
        }
        protected void AlertShow(string message, MessageBoxIcon icon)
        {
            Alert.Show(message, icon);
        }
        protected void AlertShow(string message, string title)
        {
            Alert.Show(message, title);
        }
        protected void AlertShow(string message, string title, MessageBoxIcon icon)
        {
            Alert.Show(message, title, icon);
        }
        protected void AlertShow(string message, string title, string okScript)
        {
            Alert.Show(message, title, okScript);
        }
        protected void AlertShow(string message, string title, MessageBoxIcon icon, string okScript)
        {
            Alert.Show(message, title, icon, okScript);
        }
        protected void AlertShow(string message, string title, MessageBoxIcon icon, string okScript, Target target)
        {
            Alert.Show(message, title, icon, okScript, target);
        }
        protected void AlertShow(string message, string title, MessageBoxIcon messBoxIcon, string okScript, Target target, Icon icon, string iconUrl)
        {
            Alert.Show(message, title, messBoxIcon, okScript, target, icon, iconUrl);
        }

        protected void AlertShowInTop(string message)
        {
            Alert.ShowInTop(message);
        }
        protected void AlertShowInTop(string message, MessageBoxIcon messBoxIcon)
        {
            Alert.ShowInTop(message, messBoxIcon);
        }
        protected void AlertShowInTop(string message, string title)
        {
            Alert.ShowInTop(message, title);
        }
        protected void AlertShowInTop(string message, string title, MessageBoxIcon icon)
        {
            Alert.ShowInTop(message, title, icon);
        }
        protected void AlertShowInTop(string message, string title, string okScript)
        {
            Alert.ShowInTop(message, title, okScript);
        }
        protected void AlertShowInTop(string message, string title, MessageBoxIcon icon, string okScript)
        {
            Alert.ShowInTop(message, title, icon, okScript);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Citic_Web.Reminds
{
    public partial class StockErrorList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ErrorOtherBind();
                RoleValidate();
                btn_Add.OnClientClick = WindowAdd.GetShowReference("../Reminds/AddStockError.aspx");
                //“解除异常”按钮
                btn_Remove.OnClientClick = grid_List.GetNoSelectionAlertInTopReference("未选择数据！");
            }
        }
        #region 绑定数据--乔春羽
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            //where条件 
            string where = ConditionInit();

            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where);
            string tbName = string.Format("tb_Car_{0}_{1}", ddl_Bank.SelectedValue, txt_DealerName.Text.Split('_')[1]);

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = StockErrorBll.GetListByPage(where, tbName, "CreateTime DESC", rowbegin, rowend).Tables[0];

            grid_List.DataSource = dt;
            grid_List.DataBind();
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder(" 1=1");
            if (this.ddl_Bank.SelectedValue != "-1")
            {
                where.AppendFormat(" and T.BankID = {0}", ddl_Bank.SelectedValue);
            }
            if (!string.IsNullOrEmpty(this.txt_DealerName.Text) && this.txt_DealerName.Text.IndexOf('_') > 0)
            {
                where.AppendFormat(" and T.DealerID = {0}", this.txt_DealerName.Text.Split('_')[1]);
            }
            if (this.txt_Vin.Text != string.Empty)
            {
                where.AppendFormat(" and T.Vin like '%{0}%'", this.txt_Vin.Text);
            }
            if (this.ddl_ErrorOther.SelectedValue != "-1")
            {
                where.AppendFormat(" and ErrorOther like '%{0}%'", this.ddl_ErrorOther.SelectedValue);
            }
            return where.ToString();
        }

        /// <summary>
        /// 获得查询后结果的总数据数量--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return StockErrorBll.GetRecordCount(where);
        }
        #endregion

        #region 加载合作银行信息--乔春羽
        private void BankDataBind()
        {
            //ddl_Bank.Items.Clear();

            //string dealerID = this.txt_DealerName.Text.Split('_')[1];
            //DataTable dt = Dealer_BankBll.GetList(string.Format(" A.IsDelete=0 and A.DealerID={0}", dealerID)).Tables[0];
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    ddl_Bank.DataTextField = "BankName";
            //    ddl_Bank.DataValueField = "BankID";
            //    ddl_Bank.DataSource = dt;
            //    ddl_Bank.DataBind();
            //}

            //AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
            ddl_Bank.Items.Clear();
            string val = this.txt_DealerName.Text;
            DataTable dt = null;
            if (!string.IsNullOrEmpty(val))
            {
                if (val.IndexOf('_') >= 0)
                {
                    val = val.Split('_')[1];
                    //DataTable dt = Dealer_BankBll.GetDealerByBankForDataTable(int.Parse(val), string.Empty);
                    dt = Dealer_BankBll.GetBanks(string.Format(" D.DealerID='{0}'", val)).Tables[0];
                }
            }
            else    //如果没有选择经销商，则加载出该用户所有的“有逻辑关系”的合作行
            {
                StringBuilder where = new StringBuilder();
                if (this.CurrentUser.RoleId == 10)
                {
                    dt = Dealer_BankBll.GetBankIDAndNameFilterRole(this.CurrentUser.RelationID.Value).Tables[0];
                }
                //银行
                else if (this.CurrentUser.RoleId == 8)
                {
                    Citic.Model.UserMapping model = UMBLL.GetModelByCondition(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                    if (model != null)
                    {
                        dt = BankBll.GetList(string.Format(" BankID='{0}' ", model.MappingID.Value.ToString())).Tables[0];
                    }
                    else
                    {
                        dt = BankBll.GetList(string.Format(" BankID='0' ", model.MappingID.Value.ToString())).Tables[0];
                    }
                }
                //5.市场专员，6.品牌专员
                else if (this.CurrentUser.RoleId == 5 || this.CurrentUser.RoleId == 6)
                {
                    StringBuilder ids = new StringBuilder(string.Empty);
                    DataTable _dt = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId)).Tables[0];
                    if (_dt != null && _dt.Rows.Count > 0)
                    {
                        ids.Append(" T.BankID in (");
                        foreach (DataRow row in _dt.Rows)
                        {
                            ids.AppendFormat("{0},", row["MappingID"].ToString());
                        }
                        ids.Remove(ids.Length - 1, 1);
                        ids.Append(")");
                        dt = BankBll.GetList(ids.ToString()).Tables[0];
                    }
                }
                else
                {
                    dt = BankBll.GetAllList().Tables[0];
                }
            }
            ddl_Bank.DataTextField = "BankName";
            ddl_Bank.DataValueField = "BankID";
            ddl_Bank.DataSource = dt;
            ddl_Bank.DataBind();
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }
        #endregion

        #region 加载“具体内容”信息--乔春羽(2013.12.23)
        private void ErrorOtherBind()
        {
            FileStream fs = new FileStream(Server.MapPath("~/Common/ErrorOther.SE"), FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                string value = sr.ReadLine();
                AddItemByInsert(ddl_ErrorOther, value.Split('_')[0], value.Split('_')[0], -1);
            }
            sr.Close();
            fs.Close();
            AddItemByInsert(ddl_ErrorOther, "请选择", "-1", 0);
            ddl_ErrorOther.SelectedIndex = 0;
        }
        #endregion

        #region 每页显示数量改变事件--乔春羽
        /// <summary>
        /// 每页显示数量改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_List.PageSize = int.Parse(ddlPageSize.SelectedValue);
            GridBind();
        }

        #endregion

        #region 翻页事件--乔春羽
        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);
            grid_List.PageIndex = e.NewPageIndex;

            //乔春羽
            GridBind();
            //乔春羽

            UpdateSelectedRowIndexArray(grid_List, hfSelectedIDS);
        }

        #endregion

        #region 行数据行绑定事件--乔春羽
        /// <summary>
        /// 行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            int index = -1;
            if (row != null)
            {
                //异常状态
                index = 5;
                string status = e.Values[index].ToString();
                if (status.Contains("cl")) { status = status.Replace("cl", "车辆异常"); }
                if (status.Contains("hgz")) { status = status.Replace("hgz", "合格证异常"); }
                e.Values[index] = status;

                //车辆状态
                index = 7;
                int carStatus = Convert.ToInt32(e.Values[index]);
                if (carStatus == Convert.ToInt32(Common.CarStatus.Init)) { e.Values[index] = "在途"; }
                if (carStatus == Convert.ToInt32(Common.CarStatus.Error)) { e.Values[index] = "异常"; }
                if (carStatus == Convert.ToInt32(Common.CarStatus.InStorage)) { e.Values[index] = "在库"; }
                if (carStatus == Convert.ToInt32(Common.CarStatus.Move)) { e.Values[index] = "移动"; }
                if (carStatus == Convert.ToInt32(Common.CarStatus.OutStorage)) { e.Values[index] = "出库"; }
                if (carStatus == Convert.ToInt32(Common.CarStatus.Pending)) { e.Values[index] = "申请中"; }

                //是否解决
                index = 8;
                bool flag = Convert.ToBoolean(e.Values[index]);
                if (flag)
                {
                    e.Values[index] = "已解除";
                }
                else
                {
                    e.Values[index] = "未解除";
                }

            }
        }

        private System.Web.UI.WebControls.LinkButton GetLinkButtonByID(int rowIndex, string id)
        {
            return (grid_List.Rows[rowIndex].FindControl(id) as System.Web.UI.WebControls.LinkButton);
        }

        /// <summary>
        /// 控制按钮的显示与隐藏
        /// </summary>
        /// <param name="state"></param>
        private void ControlTheButtonVisible(int rowIndex, int state)
        {
            switch (state)
            {
                case 1: //通过
                case 3: //未通过
                    GetLinkButtonByID(rowIndex, "lb_Sure").Visible = true;
                    GetLinkButtonByID(rowIndex, "lb_Delete").Visible = false;
                    GetLinkButtonByID(rowIndex, "lb_ApplyPass").Visible = false;
                    GetLinkButtonByID(rowIndex, "lb_ApplyReturn").Visible = false;
                    break;
                case 2: //处理中
                    if (this.CurrentUser.RoleId == 8)   //银行专员
                    {
                        GetLinkButtonByID(rowIndex, "lb_Sure").Visible = false;
                        GetLinkButtonByID(rowIndex, "lb_Delete").Visible = false;
                        GetLinkButtonByID(rowIndex, "lb_ApplyPass").Visible = true;
                        GetLinkButtonByID(rowIndex, "lb_ApplyReturn").Visible = true;
                    }
                    else if (this.CurrentUser.RoleId == 3) //业务经理
                    {
                        GetLinkButtonByID(rowIndex, "lb_Sure").Visible = false;
                        GetLinkButtonByID(rowIndex, "lb_Delete").Visible = true;
                        GetLinkButtonByID(rowIndex, "lb_ApplyPass").Visible = false;
                        GetLinkButtonByID(rowIndex, "lb_ApplyReturn").Visible = false;
                    }
                    break;
            }
        }
        #endregion

        #region 查询--乔春羽
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_DealerName.Text) || this.txt_DealerName.Text.IndexOf('_') <= 0)
            {
                Alert.ShowInTop("请选择经销商！");
                return;
            }
            if (string.IsNullOrEmpty(this.ddl_Bank.SelectedValue))
            {
                Alert.ShowInTop("请选择银行！");
                return;
            }
            GridBind();
        }
        #endregion

        #region 窗体关闭事件--乔春羽(2013.8.9)
        protected void WindowAdd_Close(object sender, WindowCloseEventArgs e)
        {

        }
        #endregion

        #region 经销商被输入后，联动出合作行--乔春羽(2013.12.6)
        protected void txt_DealerName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txt_DealerName.Text) && this.txt_DealerName.Text.IndexOf('_') > 0)
            {
                if (!string.IsNullOrEmpty(this.txt_DealerName.Text.Split('_')[0]) && !string.IsNullOrEmpty(this.txt_DealerName.Text.Split('_')[1]))
                {
                    BankDataBind();
                }
            }
        }
        #endregion

        #region 判断登陆角色，显示不同的按钮--乔春羽(2013.9.3)
        /// <summary>
        /// 按钮权限过滤
        /// </summary>
        private void RoleValidate()
        {
            DataTable dt = GetMenusByCurrentUserRoleID(false);
            List<string> urls = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                urls.Add(row["MenuUrl"].ToString());
            }
            ViewState.Add("roles", urls);
            if (urls.Contains("Search14"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("Insert14"))
            {
                btn_Add.Visible = true;
            }
            if (urls.Contains("Excel14"))
            {
                tbs_Excel.Visible = true;
                btn_ExpendExcel.Visible = true;
                hl_ExportExcel.Visible = true;
                hl_ExportAll.Visible = true;
                bl_Separator.Visible = true;
            }
            //“解除异常”
            if (urls.Contains("Remove14"))
            {
                btn_Remove.Visible = true;
                ts_Remove.Visible = true;
            }
        }
        #endregion

        #region 解除异常--乔春羽(2013.12.23)
        protected void btn_Remove_Click(object sender, EventArgs e)
        {
            int[] indexs = this.grid_List.SelectedRowIndexArray;
            List<string> ids = new List<string>();
            if (indexs != null && indexs.Length > 0)
            {
                foreach (int index in indexs)
                {
                    ids.Add(grid_List.Rows[index].DataKeys[0].ToString());
                }
                int num = StockErrorBll.UpdateErrorStatusRange(ids.ToArray(), this.CurrentUser.UserId);
                if (num > 0)
                {
                    Alert.ShowInTop("异常解除成功！");
                    GridBind();
                }
                else
                {
                    Alert.ShowInTop("失败！");
                }
            }
        }
        #endregion

        #region 导出Excel--乔春羽
        /// <summary>
        /// 导出Excel
        /// </summary>
        protected void btn_ExpendExcel_Click(object sender, EventArgs e)
        {
            string where = ConditionInit();
            //保存Excel文件
            string sheetName = "日查库信息（当前页）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string sheetNameAll = "日查库信息（全部）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string filePath = string.Empty;
            //保存当前页的数据
            ExcelEditHelper.Create();
            ExcelEditHelper.AddSheet(sheetName);
            DataTable dt = null;

            dt = GetTableForGrid(grid_List);

            string fileName = sheetName + ".xls";//客户端保存的文件名
            ExcelEditHelper.DataTableAdd2Excel(dt, sheetName);

            filePath = "~/DownExcel/" + sheetName + ".xls";
            bool flag = ExcelEditHelper.SaveAs(Server.MapPath(filePath));

            //释放ExcelEditHelper
            CloseExcelEditHelper();

            //下载Excel文件
            if (flag)
            {
                hl_ExportExcel.NavigateUrl = filePath;
            }

            //保存所有的数据
            ExcelEditHelper.Create();
            ExcelEditHelper.AddSheet(sheetNameAll);

            dt = StockErrorBll.GetAllProcess(where);

            ModifyTableHeaderByGrid(grid_List, dt);

            fileName = sheetName + ".xls";//客户端保存的文件名
            ExcelEditHelper.DataTableAdd2Excel(dt, sheetNameAll);

            filePath = "~/DownExcel/" + sheetNameAll + ".xls";
            flag = ExcelEditHelper.SaveAs(Server.MapPath(filePath));

            //释放ExcelEditHelper
            CloseExcelEditHelper();

            //下载Excel文件
            if (flag)
            {
                hl_ExportAll.NavigateUrl = filePath;
            }
        }
        #endregion
    }
}
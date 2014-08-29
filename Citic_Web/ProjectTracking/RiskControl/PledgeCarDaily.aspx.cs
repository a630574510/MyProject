using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

using FineUI;
namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class PledgeCarDaily : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RoleValidate();
            }
        }

        #region PrivateFields--乔春羽(2013.12.12)
        private DataTable DtSource
        {
            get { return ViewState["DtSource"] as DataTable; }
            set { ViewState["DtSource"] = value; }
        }
        #endregion

        #region 绑定数据--乔春羽
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            //where条件 
            string where = ConditionInit();
            string tbName = string.Format("tb_Car_{1}_{0}", ddl_Dealer.SelectedValue, txt_Bank.Text.Split('_')[1]);
            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where);

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DtSource = StockErrorBll.GetListByPage(where, tbName, "CreateTime DESC", rowbegin, rowend).Tables[0];

            grid_List.DataSource = DtSource;
            grid_List.DataBind();
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder(" 1=1 ");
            if (this.ddl_Dealer.SelectedValue != null && this.ddl_Dealer.SelectedValue != "-1")
            {
                where.AppendFormat(" and T.DealerID = {0}", ddl_Dealer.SelectedValue);
            }
            if (!string.IsNullOrEmpty(this.txt_Bank.Text))
            {
                where.AppendFormat(" and T.BankID = {0}", this.txt_Bank.Text.Split('_')[1]);
            }
            if (!string.IsNullOrEmpty(this.txt_Vin.Text))
            {
                where.AppendFormat(" and T.Vin like '%{0}%'", this.txt_Vin.Text);
            }
            if (!string.IsNullOrEmpty(this.txt_Brand.Text))
            {
                where.AppendFormat(" and B.BrandName like '%{0}%'", this.txt_Brand.Text);
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

        #region 加载企业信息--乔春羽
        private void BankDataBind()
        {
            this.ddl_Dealer.Items.Clear();
            string val = this.txt_Bank.Text;
            if (!string.IsNullOrEmpty(val) && val.IndexOf('_') > 0)
            {
                string where = string.Empty;
                //监管员
                if (this.CurrentUser.RoleId == 10)
                {
                    where = string.Format(" DealerID in (select DealerID from tb_Dealer_List where SupervisorID='{0}')", this.CurrentUser.RelationID.Value);
                }
                else
                {

                }
                DataTable dt = Dealer_BankBll.GetDealerByBankForDataTable(string.IsNullOrEmpty(val.Split('_')[1]) ? 0 : int.Parse(val.Split('_')[1]), where);

                ddl_Dealer.DataTextField = "DealerName";
                ddl_Dealer.DataValueField = "DealerID";
                ddl_Dealer.DataSource = dt;
                ddl_Dealer.DataBind();
            }
            AddItemByInsert(ddl_Dealer, "请选择", "-1", 0);
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
                index = 6;
                bool flag = Convert.ToBoolean(e.Values[index]);
                if (flag)
                {
                    e.Values[index] = "以解决";
                }
                else
                {
                    e.Values[index] = "待解决";
                }

                //异常情况
                index = 7;
                string status = e.Values[index].ToString();
                switch (status)
                {
                    case "1,1":
                        e.Values[index] = "车辆异常，合格证异常";
                        break;
                    case "1,0":
                        e.Values[index] = "车辆异常";
                        break;
                    case "0,1":
                        e.Values[index] = "合格证异常";
                        break;
                    case "0,0":
                        e.Values[index] = "无";
                        break;
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
            if (string.IsNullOrEmpty(this.txt_Bank.Text) || this.txt_Bank.Text.IndexOf('_') <= 0)
            {
                Alert.ShowInTop("请选择合作行！");
                return;
            }
            GridBind();
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
            if (urls.Contains("Search710"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("ExportExcel710"))
            {
                btn_BuildExcel.Visible = true;
                hl_ExportExcel.Visible = true;
            }
            if (urls.Contains("Delete"))
            {
            }
        }
        #endregion

        #region 选择经销商，加载合作行--乔春羽(2013.12.12)
        protected void txt_Dealer_TextChanged(object sender, EventArgs e)
        {
            BankDataBind();
        }
        #endregion

        #region 生成Excel--乔春羽(2013.12.12)
        protected void btn_BuildExcel_Click(object sender, EventArgs e)
        {
            string bankValue = this.txt_Bank.Text;
            if (string.IsNullOrEmpty(bankValue) || bankValue.IndexOf("_") <= 0 || bankValue.Split('_').Length != 2)
            {
                AlertShowInTop("请选择合作行！");
                return;
            }
            DataTable dt = null;
            string where = this.ConditionInit();
            string tbName = string.Format("tb_Car_{1}_{0}", ddl_Dealer.SelectedValue, txt_Bank.Text.Split('_')[1]);
            dt = StockErrorBll.GetListByPage(where, tbName, "CreateTime DESC", 0, 0).Tables[0];
            if (dt == null || dt.Rows.Count <= 0)
            {
                AlertShowInTop("没有可导出的数据！");
                return;
            }
            string sheetName = "《每日质押车辆统计表》";
            string fileName = Server.MapPath("~/DownExcel/" + sheetName + ".xls");
            Excel.Application excel = new Excel.Application();

            excel.Visible = false;
            Excel.Workbook wBook = excel.Workbooks.Add(true);
            Excel.Worksheet wSheet = wBook.Worksheets[1] as Excel.Worksheet;

            int errorCarCount = 0;
            if (dt.Rows.Count > 0)
            {
                int row = 0;
                row = dt.Rows.Count;
                int col = dt.Columns.Count;
                for (int i = 0; i < row; i++)
                {
                    if (!Convert.ToBoolean(dt.Rows[i]["Status"]))
                    {
                        errorCarCount++;
                    }
                    string vin = dt.Rows[i]["Vin"].ToString();
                    DateTime time = Convert.ToDateTime(dt.Rows[i]["CreateTime"]);
                    wSheet.Cells[i + 2, 1] = dt.Rows[i]["DealerName"];
                    wSheet.Cells[i + 2, 2] = dt.Rows[i]["BankName"];
                    wSheet.Cells[i + 2, 3] = dt.Rows[i]["BrandName"];
                    wSheet.Cells[i + 2, 4] = dt.Rows[i]["CreateTime"];
                    wSheet.Cells[i + 2, 5] = dt.Rows[i]["ErrorOther"];
                    wSheet.Cells[i + 2, 6] = vin.Substring(vin.Length - 6);
                    wSheet.Cells[i + 2, 7] = dt.Rows[i]["CreateTime"];
                    wSheet.Cells[i + 2, 8] = dt.Rows[i]["CarCost"];
                    wSheet.Cells[i + 2, 9] = Math.Abs((int)(DateTime.Now - time).TotalDays);
                }
            }

            wSheet.Cells[1, 1 + 0] = "经销商";
            wSheet.Cells[1, 1 + 1] = "合作行";
            wSheet.Cells[1, 1 + 2] = "品牌";
            wSheet.Cells[1, 1 + 3] = "查库日期";
            wSheet.Cells[1, 1 + 4] = "异常情况";
            wSheet.Cells[1, 1 + 5] = "车架号后六位";
            wSheet.Cells[1, 1 + 6] = "发生日期";
            wSheet.Cells[1, 1 + 7] = "金额";
            wSheet.Cells[1, 1 + 8] = "异常持续天数";

            //加尾部
            int bottom = dt.Rows.Count + 1;
            wSheet.Cells[bottom + 2, 1] = "质押车辆总数:";
            wSheet.Cells[bottom + 2, 2] = bottom - 1;
            wSheet.Cells[bottom + 3, 1] = "异常车辆总数:";
            wSheet.Cells[bottom + 3, 2] = errorCarCount;
            //监管员角色执行此步骤。
            if (this.CurrentUser.RoleId == 10)
            {
                wSheet.Cells[bottom + 4, 1] = "监管员签字（手签）:";
                wSheet.Cells[bottom + 5, 1] = "经销店授权人签字（手签）:";
            }
            wSheet.Cells[bottom + 6, 1] = "备注:";

            //设置禁止弹出保存和覆盖的询问提示框   
            excel.DisplayAlerts = false;
            excel.AlertBeforeOverwriting = false;

            //得到图片路径，该路径是以经销商银行来分的
            //string imagePath = url + "/" + string.Format("/UploadImage/日查库照片/{0}/{1}/{0}_{1}_{2}.jpg", this.txt_Dealer.Text.Split('_')[1], this.ddl_Bank.SelectedValue, ConvertShortDateTimeToUI(DateTime.Now));
            string imagePath = string.Format("~/UploadImage/日查库照片/{0}/{1}/{0}_{1}_{2}.jpg", this.ddl_Dealer.SelectedValue, this.txt_Bank.Text.Split('_')[1], ConvertShortDateTimeToUI(DateTime.Now));

            //监管员角色不执行此步骤。
            if (this.CurrentUser.RoleId == 10)
            {
                if (File.Exists(Server.MapPath(imagePath)))
                {
                    //插入图片
                    Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                    worksheet.Shapes.AddPicture(Server.MapPath(imagePath), MsoTriState.msoFalse, MsoTriState.msoTrue, (float)50, (float)(dt.Rows.Count * 10), 150, 150);
                }
                else
                {
                    AlertShowInTop("该店没有图片！");
                }
            }
            //保存工作簿   
            wSheet.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing);
            wBook.Save();
            //保存excel文件
            //excel.Save(fileName);
            //excel.SaveWorkspace(fileName);
            excel.Quit();
            wSheet = null;
            excel = null;

            hl_ExportExcel.NavigateUrl = "~/DownExcel/" + sheetName + ".xls";
        }
        #endregion
    }
}
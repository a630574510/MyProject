using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Citic_Web.Ledger
{
    public partial class Select_Ledger : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //清空ViewState中的数据
                ViewState.Clear();
            }
        }

        #region 绑定数据--乔春羽(2013.7.19)
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            //where条件
            string path = Common.OperateConfigFile.getValue("Dealer_Bank");
            string commandStr = Common.OperateConfigFile.getValue("Dealer_BankCommand");

            string[] dealerIDs = null;
            string[] bankIDs = null;
            //得到查询条件

            //选择了银行
            if (!string.IsNullOrEmpty(this.txt_Bank.Text) && this.txt_Bank.Text.IndexOf("_") > 0)
            {
                string bankID = this.txt_Bank.Text.Split('_')[1];
                bankIDs = new string[] { bankID };
                dealerIDs = Dealer_BankBll.GetDealerIDsByBankID(int.Parse(bankID));
            }

            //选择了经销商
            if (!string.IsNullOrEmpty(this.txt_DealerName.Text) && this.txt_DealerName.Text.IndexOf("_") > 0)
            {
                string dealerID = this.txt_DealerName.Text.Split('_')[1];
                dealerIDs = new string[] { dealerID };
                //bankIDs == null 说明用户在界面上没有选择银行
                //既然没有选择银行，那就根据选择的经销商查询出所有的合作行
                if (bankIDs == null)
                {
                    bankIDs = this.Dealer_BankBll.GetBankIDsBySearch(string.Format("DealerID = '{0}'", dealerID));
                }
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;

            try
            {
                DataSet ds = Dealer_BankBll.LedgerSearch(Server.MapPath(path), commandStr, "1=1", string.Empty, rowbegin, rowend, bankIDs, dealerIDs);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        this.grid_List.RecordCount = dt.Rows.Count;
                        grid_List.DataSource = dt;
                        grid_List.DataBind();
                    }
                    else
                    {
                        AlertShowInTop("没有数据！");
                    }
                }
                else 
                {
                    AlertShowInTop("没有数据！");
                }
            }
            catch (SqlException se)
            {
                AlertShowInTop(se.Message);
                AlertShowInTop("网络连接异常，请稍后再试。");
            }
        }

        /// <summary>
        /// 获得查询后结果的总数据数量--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return Dealer_BankBll.GetRecordCount(where);
        }
        #endregion

        #region 查询检索--乔春羽(2013.7.19)
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 加载合作银行信息--乔春羽
        private void BankDataBind()
        {
            DataTable dt = null;
            //监管员
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
                dt = BankBll.GetList("IsDelete=0").Tables[0];
            }
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    ddl_Bank.DataTextField = "BankName";
            //    ddl_Bank.DataValueField = "BankID";
            //    ddl_Bank.DataSource = dt;
            //    ddl_Bank.DataBind();
            //}
            //AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }
        #endregion

        #region 每页显示数量改变事件--乔春羽
        /// <summary>
        /// 每页显示数量改变事件--乔春羽
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
        /// 翻页事件--乔春羽
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

        #region 导出Excel--乔春羽(2013.7.19)
        protected void btn_BuildExcel_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(this.ddl_Bank.SelectedValue) || this.ddl_Bank.SelectedValue == "0")
            //{
            //    Alert.ShowInTop("请选择合作行！");
            //    return;
            //}
            if (this.grid_List.Rows.Count <= 0)
            {
                AlertShowInTop("没有可导出的数据！");
                return;
            }
            //保存Excel文件
            string sheetName = "总账";
            ExcelEditHelper.Create();
            ExcelEditHelper.AddSheet(sheetName);
            DataTable dt = null;

            dt = GetTableForGrid(grid_List);

            ExcelEditHelper.DataTableAdd2Excel(dt, sheetName);

            //下载Excel文件
            string fileName = sheetName + this.ConvertLongDateTimeToUI(DateTime.Now) + ".xls";//客户端保存的文件名

            bool flag = ExcelEditHelper.SaveAs(Server.MapPath("~/DownExcel/" + fileName));
            //释放ExcelEditHelper
            CloseExcelEditHelper();

            hl_ExportExcel.NavigateUrl = "~/DownExcel/" + fileName;
        }
        #endregion

        #region 数据行命令事件--乔春羽(2013.7.19)
        protected void grid_List_RowCommand(object sender, GridCommandEventArgs e)
        {

        }
        #endregion
    }
}
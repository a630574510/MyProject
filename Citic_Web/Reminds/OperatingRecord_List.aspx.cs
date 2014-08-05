using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Citic_Web.Reminds
{
    public partial class OperatingRecord_List : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BankDataBind();
                DealerDataBind();
                //过滤权限--乔春羽（2013.9.3）
                RoleValidate();
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

            if (this.grid_List.PageCount < this.grid_List.PageIndex)
            {
                this.grid_List.PageIndex = 1;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = DBSXBll.GetListByPage(where, "DealerName asc", rowbegin, rowend).Tables[0];
            ViewState.Add("dt", dt);

            grid_List.DataSource = dt;
            grid_List.DataBind();
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder(" (Status = 1 or Status = 3)");
            if (this.ddl_Bank.SelectedValue != null && this.ddl_Bank.SelectedValue != "0")
            {
                where.AppendFormat(" and BankID = {0}", ddl_Bank.SelectedValue);
            }
            if (this.ddl_Dealer.SelectedValue != null && this.ddl_Dealer.SelectedValue != "0")
            {
                if (!string.IsNullOrEmpty(this.txt_DealerName.Text))
                {
                    where.AppendFormat(" and (DealerID = {0} or DealerName like '%{1}%')", ddl_Dealer.SelectedValue, this.txt_DealerName.Text);
                }
                else
                {
                    where.AppendFormat(" and (DealerID = {0})", ddl_Dealer.SelectedValue);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this.txt_DealerName.Text))
                {
                    where.AppendFormat(" and (DealerName like '%{0}%')", this.txt_DealerName.Text);
                }
            }
            if (this.txt_Vin.Text != string.Empty)
            {
                where.AppendFormat(" and Vin like '%{0}%'", this.txt_Vin.Text);
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
            return DBSXBll.GetRecordCount(where);
        }
        #endregion

        #region 加载合作银行信息--乔春羽
        private void BankDataBind()
        {
            DataTable dt = BankBll.GetBankIDAndBankName("IsDelete=0");

            ddl_Bank.DataTextField = "BankName";
            ddl_Bank.DataValueField = "BankID";
            ddl_Bank.DataSource = dt;
            ddl_Bank.DataBind();

            ddl_Bank.Items.Insert(0, new FineUI.ListItem("请选择", "0"));

        }
        #endregion

        #region 加载企业信息（经销商）--乔春羽
        private void DealerDataBind()
        {
            string val = ddl_Bank.SelectedValue;
            if (val != null && val != string.Empty)
            {
                DataTable dt = Dealer_BankBll.GetDealerByBankForDataTable(int.Parse(val), string.Empty);

                ddl_Dealer.DataTextField = "DealerName";
                ddl_Dealer.DataValueField = "DealerID";
                ddl_Dealer.DataSource = dt;
                ddl_Dealer.DataBind();
            }
            ddl_Dealer.Items.Insert(0, new FineUI.ListItem("请选择", "0"));
        }
        #endregion

        #region 选择银行，加载企业信息--乔春羽
        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            DealerDataBind();
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

        #region 数据行绑定事件--乔春羽
        /// <summary>
        /// 行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                int type = Convert.ToInt32(e.Values[3]);
                switch (type)
                {
                    case 1:
                        e.Values[3] = "出库申请";
                        break;
                    case 2:
                        e.Values[3] = "移动申请";
                        break;
                }

                type = Convert.ToInt32(e.Values[6]);
                switch (type)
                {
                    case 1: //状态为“通过”
                        e.Values[6] = "通过";
                        break;
                    case 2:
                        e.Values[6] = "处理中";
                        break;
                    case 3:
                        e.Values[6] = "未通过";
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
            GridBind();
        }
        #endregion

        #region 表格排序--乔春羽
        protected void grid_List_Sort(object sender, GridSortEventArgs e)
        {
            grid_List.SortDirection = e.SortDirection;
            grid_List.SortColumnIndex = e.ColumnIndex;
            //重新绑定数据
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
            if (urls.Contains("Search11"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("Insert"))
            {

            }
            if (urls.Contains("Delete"))
            {
            }
        }
        /// <summary>
        /// 权限过滤--乔春羽
        /// </summary>
        /// <param name="menuUrl">被过滤的功能</param>
        /// <returns></returns>
        private bool RoleFilter(string menuUrl)
        {
            bool flag = false;

            return flag;
        }
        #endregion
    }
}
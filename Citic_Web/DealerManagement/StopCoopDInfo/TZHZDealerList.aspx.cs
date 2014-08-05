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

namespace Citic_Web.DealerManagement.StopCoopDInfo
{
    public partial class TZHZDealerList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //权限过滤
                RoleValidate();
            }
        }

        #region 绑定数据--乔春羽
        /// <summary>
        /// 绑定数据--乔春羽
        /// </summary>
        private void GridBind()
        {
            //where条件
            string where = ConditionInit();

            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where);

            if (this.grid_List.PageCount < this.grid_List.PageIndex)
            {
                this.grid_List.PageIndex = 0;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = Dealer_BankBll.GetListByPage(where, "BankID,DealerID,BrandID", rowbegin, rowend).Tables[0];

            grid_List.DataSource = dt;
            grid_List.DataBind();
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

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            string dealerName = this.txt_DealerName.Text;
            StringBuilder where = new StringBuilder("T.IsDelete=0 and T.CollaborateType=0");
            if (dealerName != string.Empty)
            {
                where.AppendFormat(" and T.DealerName like '%{0}%'", dealerName);
            }
            if (dp_Start.Text != string.Empty && dp_End.Text != string.Empty)
            {
                DateTime startTime = DateTime.Parse(dp_Start.Text);
                DateTime endTime = DateTime.Parse(dp_End.Text).AddDays(1);
                if (startTime < endTime)
                {
                    where.AppendFormat(" and T.DispatchTime between '{0}' and '{1}'", startTime, endTime);
                }
            }
            return where.ToString();
        }
        #endregion

        #region 查询数据--乔春羽
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
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

            GridBind();
            
            UpdateSelectedRowIndexArray(grid_List, hfSelectedIDS);
        }
        #endregion

        #region 行数据绑定事件--乔春羽
        protected void grid_List_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                int businessMode = Convert.ToInt32(e.Values[3]);
                string financingMode = e.Values[7].ToString();
                //业务模式
                switch (businessMode)
                {
                    case 1:
                        e.Values[3] = "车证模式";
                        break;
                    case 2:
                        e.Values[3] = "合格证模式";
                        break;
                    case 3:
                        e.Values[3] = "巡库模式";
                        break;
                }

                //融资模式
                if (financingMode.Contains("1"))
                {
                    financingMode = financingMode.Replace("1", "承兑汇票");
                }
                if (financingMode.Contains("2"))
                {
                    financingMode = financingMode.Replace("2", "法人透支");
                }
                if (financingMode.Contains("3"))
                {
                    financingMode = financingMode.Replace("3", "流动贷款");
                }
                if (financingMode.Contains("4"))
                {
                    financingMode = financingMode.Replace("4", "信用证");
                }
                e.Values[7] = financingMode;

                //付费周期
                int paymentCycle = Convert.ToInt32(e.Values[6]);
                switch (paymentCycle)
                {
                    case 1:
                        e.Values[6] = "月";
                        break;
                    case 2:
                        e.Values[6] = "季";
                        break;
                    case 3:
                        e.Values[6] = "半年";
                        break;
                    case 4:
                        e.Values[6] = "年";
                        break;
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
            if (urls.Contains("Search33"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("Insert33"))
            { }
            if (urls.Contains("Delete33"))
            { }
            if (urls.Contains("Modify33"))
            { }
            if (urls.Contains("Excel33"))
            { }
        }
        #endregion
    }
}
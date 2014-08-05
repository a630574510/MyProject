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
            DataTable dt = Dealer_BankBll.GetListByPage(where, "ID DESC", rowbegin, rowend).Tables[0];

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
            StringBuilder where = new StringBuilder(" T.IsDelete=0 and T.CollaborateType=0");
            string[] dealerIDs = null;
            //权限过滤
            int roleID = this.CurrentUser.RoleId;
            switch (roleID)
            {
                case 10:    //监管员
                    //根据监管员ID，查询其所监管的经销商
                    dealerIDs = new string[0];
                    dealerIDs = this.DealerBll.GetDealerIDsBySupervisorID(this.CurrentUser.RelationID.Value);
                    if (dealerIDs != null && dealerIDs.Length > 0)
                    {
                        where.AppendFormat(" and T.DealerID in ({0}) ", string.Join(",", dealerIDs));
                    }
                    else
                    {
                        where.Append(" and T.DealerID in (0) ");
                    }
                    break;

                case 8:     //银行
                    //合作行的过滤条件
                    dealerIDs = new string[0];
                    DataSet ds = this.UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                    int bankID = 0;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        bankID = Convert.ToInt32(dt.Rows[0]["MappingID"].ToString());
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            where.AppendFormat(" And T.BankID = '{0}' ", bankID);
                        }
                        else
                        {
                            where.Append(" And T.BankID = '0' ");
                        }
                    }
                    
                    break;
                case 5:     //市场专员
                case 6:     //品牌专员
                    StringBuilder ids = new StringBuilder(string.Empty);
                    ids.Append(" T.BankID in (");
                    DataTable _dt = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId)).Tables[0];
                    if (_dt != null && _dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in _dt.Rows)
                        {
                            ids.AppendFormat("{0},", row["MappingID"].ToString());
                        }
                        ids.Remove(ids.Length - 1, 1);
                    }
                    else
                    {
                        ids.Append("0");
                    }
                    ids.Append(")");

                    if (ids != null && ids.Length != 0)
                    {
                        where.AppendFormat(" AND {0}", ids.ToString());
                    }
                    break;
                case 9:     //厂家
                    break;
            }

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
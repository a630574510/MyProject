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

namespace Citic_Web.FinanceInfo
{
    public partial class DraftInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState.Clear();
                string draftNo = Request.QueryString["draftNo"];
                string tbName = Request.QueryString["c_t"];
                if (!string.IsNullOrEmpty(draftNo) && !string.IsNullOrEmpty(tbName))
                {
                    ViewState[DRAFTNO] = draftNo;
                    ViewState[TABLENAME] = tbName;
                    DraftDataBind();
                    CarDataBind();
                    RoleValidate();

                }
            }
        }

        #region PrivateFields--乔春羽
        private string GetDraftNo()
        {
            return ViewState[DRAFTNO].ToString();
        }
        private const string DRAFTNO = "no";
        private const string TABLENAME = "tableName";
        private const string MODEL = "model";
        #endregion

        #region 绑定数据--乔春羽

        /// <summary>
        /// 显示汇票信息
        /// </summary>
        private void DraftDataBind()
        {
            Citic.Model.Draft model = DraftBll.GetModel(GetDraftNo());
            if (model != null)
            {
                ViewState[MODEL] = model;
                this.lbl_BankName.Text = model.BankName;
                this.lbl_DealerName.Text = model.DealerName;
                this.lbl_DraftNo.Text = model.DraftNo;
                this.txt_GuaranteeNo.Text = model.GuaranteeNo;
                this.txt_PledgeNo.Text = model.PledgeNo;
                this.txt_RGuaranteeNo.Text = model.RGuaranteeNo;
                this.dp_BeginTime.SelectedDate = model.BeginTime;
                this.dp_EndTime.SelectedDate = model.EndTime;
                this.num_Money.Text = model.DarftMoney.ToString();
                this.num_Ratio.Text = model.Ratio.ToString();
                this.lbl_HKMoney.Text = model.HKMoney.ToString();
            }
        }

        /// <summary>
        /// 显示车辆信息
        /// </summary>
        private void CarDataBind()
        {
            //where条件
            string where = ConditionInit();

            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where);

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = CarBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend, ViewState[TABLENAME].ToString()).Tables[0];

            grid_List.DataSource = dt;
            grid_List.DataBind();
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("IsDelete=0");

            where.AppendFormat(" and DraftNo='{0}'", GetDraftNo());

            return where.ToString();
        }

        /// <summary>
        /// 获得查询后结果的总数据数量--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return CarBll.GetRecordCount(where, ViewState[TABLENAME].ToString());
        }
        #endregion

        #region 行命令事件--乔春羽
        protected void grid_List_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName != null && e.CommandName != string.Empty)
            {

            }
        }
        #endregion

        #region 行绑定事件--乔春羽
        /// <summary>
        /// 行绑定事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                int index = 8;
                if (e.Values[index] != null && e.Values[index].ToString() != string.Empty)
                {
                    int type = Convert.ToInt32(e.Values[index]);
                    switch (type)
                    {
                        case (int)Common.CarStatus.OutStorage:
                            e.Values[index] = "出库";
                            break;
                        case (int)Common.CarStatus.InStorage:
                            e.Values[index] = "在库";
                            break;
                        case (int)Common.CarStatus.Move:
                            e.Values[index] = "移动";
                            break;
                        case (int)Common.CarStatus.Init:
                            e.Values[index] = "在途";
                            break;
                        case (int)Common.CarStatus.Pending:
                            e.Values[index] = "申请中";
                            break;
                        case (int)Common.CarStatus.Error:
                            e.Values[index] = "异常";
                            break;
                    }
                }
            }
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
            CarDataBind();
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
            CarDataBind();
            //乔春羽

            UpdateSelectedRowIndexArray(grid_List, hfSelectedIDS);
        }
        #endregion

        #region 保存修改--乔春羽
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            Save();
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        private void Save()
        {
            Citic.Model.Draft model = ViewState[MODEL] as Citic.Model.Draft;
            model.DarftMoney = this.num_Money.Text;
            model.BeginTime = dp_BeginTime.SelectedDate;
            model.EndTime = dp_EndTime.SelectedDate;
            model.PledgeNo = this.txt_PledgeNo.Text;
            model.GuaranteeNo = this.txt_GuaranteeNo.Text;
            model.Ratio = Decimal.Parse(num_Ratio.Text);
            model.RGuaranteeNo = this.txt_RGuaranteeNo.Text;

            try
            {
                bool flag = DraftBll.Update(model);
                if (flag)
                {
                    Alert.ShowInTop("修改成功！");
                }
                else
                {
                    Alert.ShowInTop("修改失败！");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 改变控件的状态，让数据可以修改--乔春羽(2013.12.2)
        protected void btn_Modify_Click(object sender, EventArgs e)
        {
            foreach (FineUI.ControlBase cb in sf_DraftInfo.Controls)
            {
                if (cb is FineUI.Button)
                {
                    //Do not anything!
                }
                else
                {
                    if (this.btn_Modify.Text == "修改")
                        cb.Enabled = true;
                    else
                        cb.Enabled = false;
                }
            }
            if (this.btn_Modify.Text == "修改") { this.btn_Modify.Text = "取消"; this.btn_SaveAndClose.Enabled = true; } else { this.btn_Modify.Text = "修改"; this.btn_SaveAndClose.Enabled = false; }
        }
        #endregion

        #region 判断登陆角色，显示不同的按钮--乔春羽
        /// <summary>
        /// 按钮权限过滤
        /// </summary>
        private void RoleValidate()
        {
            DataTable dt = GetMenusByCurrentUserRoleID();
            List<string> urls = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                urls.Add(row["MenuUrl"].ToString());
            }
            ViewState.Add("roles", urls);
            if (urls.Contains("Modify41"))
            {
                btn_Modify.Enabled = true;
            }
        }
        #endregion
    }
}
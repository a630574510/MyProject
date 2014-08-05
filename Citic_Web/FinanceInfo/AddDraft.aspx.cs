using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;
namespace Citic_Web.FinanceInfo
{
    public partial class WebForm1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridBind(); BankDataBind();
            }
        }
        #region PrivateField--乔春羽(2013.11.29)
        private const string DEALERID = "DealerID";
        #endregion

        #region 绑定数据--乔春羽(2013.11.29)
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
            DataTable dt = DealerBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];

            grid_List.DataSource = dt;
            grid_List.DataBind();
        }


        /// <summary>
        /// 获得查询后结果的总数据数量
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return DealerBll.GetRecordCount(where);
        }

        #region 得到查询条件--乔春羽
        /// <summary>
        /// 得到查询条件
        /// </summary>
        private string ConditionInit()
        {
            string DealerName = this.ttb_DealerName.Text;
            StringBuilder where = new StringBuilder("IsDelete=0");
            if (DealerName != null && DealerName != string.Empty)
            {
                where.AppendFormat(" and DealerName like '%{0}%'", DealerName);
            }

            return where.ToString();
        }
        #endregion

        #endregion

        #region 查询操作--乔春羽(2013.11.29)
        protected void TwinTriggerBox1_Trigger1Click(object sender, EventArgs e)
        {
            // 执行清空动作
            ttb_DealerName.Text = "";
            ttb_DealerName.ShowTrigger1 = false;
        }
        protected void TwinTriggerBox1_Trigger2Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 行选择事件，选择经销商，关联查询出与之合作的银行--乔春羽(2013.11.29)
        protected void grid_List_RowSelect(object sender, GridRowSelectEventArgs e)
        {
            //表示已选择行
            if (e.RowIndex > -1)
            {
                //将经销商ID存起来
                ViewState.Add(DEALERID, this.grid_List.DataKeys[e.RowIndex][0]);
                //将经销商名显示出来
                this.lbl_DealerName.Text = this.grid_List.DataKeys[e.RowIndex][1].ToString();

                //加载银行
                BankDataBind();
            }
        }
        #endregion

        #region 绑定银行信息--乔春羽(2013.11.29)
        private void BankDataBind()
        {
            if (ViewState[DEALERID] != null)
            {
                DataTable dt = Dealer_BankBll.GetList(string.Format(" DealerID={0}", ViewState[DEALERID])).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.ddl_Bank.DataTextField = "BankName";
                    this.ddl_Bank.DataValueField = "BankID";
                    this.ddl_Bank.DataSource = dt;
                    this.ddl_Bank.DataBind();
                }
            }
            this.AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }
        #endregion

        #region 行绑定事件--乔春羽
        /// <summary>
        /// 行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                int index = 1;
                //企业属性
                string dealerType = Convert.ToString(e.Values[index]);
                if (dealerType.Contains("1"))
                {
                    dealerType = dealerType.Replace("1", "民营");
                }
                if (dealerType.Contains("2"))
                {
                    dealerType = dealerType.Replace("2", "国营");
                }
                if (dealerType.Contains("3"))
                {
                    dealerType = dealerType.Replace("3", "集团");
                }
                if (dealerType.Contains("4"))
                {
                    dealerType = dealerType.Replace("4", "单店");
                }
                e.Values[index] = dealerType;
                //是否是集团性质
                index = 2;
                bool isGroup = Convert.ToBoolean(e.Values[index]);
                e.Values[index] = isGroup ? "是" : "否";
                index = 3;
                string hasOtherIndustries = Convert.ToString(e.Values[index]);
                e.Values[index] = string.IsNullOrEmpty(hasOtherIndustries) ? "无" : hasOtherIndustries;
            }
        }
        #endregion

        #region 保存并且关闭页面--乔春羽
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            Save();
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #region 判断是否有重复的汇票号--乔春羽
        private bool ExistsDraftNo(string draftNo)
        {
            Citic.Model.Draft model = DraftBll.GetModel(draftNo);
            return model == null ? false : true;
        }
        #endregion

        /// <summary>
        /// 保存汇票
        /// </summary>
        private void Save()
        {
            Citic.Model.Draft model = new Citic.Model.Draft();
            model.BeginTime = DateTime.Parse(dp_Start.Text);
            model.CreateID = this.CurrentUser.UserId;
            model.CreateTime = DateTime.Now;
            model.DarftMoney = this.num_Money.Text;
            model.DealerID = Convert.ToInt32(ViewState[DEALERID]);
            model.DealerName = this.lbl_DealerName.Text;
            model.DraftType = true;
            model.EndTime = DateTime.Parse(dp_End.Text).AddDays(1);
            model.GuaranteeNo = this.txt_GuaranteeNo.Text;
            model.IsDelete = false;
            model.IsPort = false;
            model.PledgeNo = this.txt_PledgeNo.Text;
            model.Ratio = decimal.Parse(num_Ratio.Text);
            model.Remarks = this.txt_Remark.Text;
            model.RGuaranteeNo = this.txt_RGuaranteeNo.Text;
            model.DraftNo = this.txt_DraftNo.Text;
            model.BankID = int.Parse(ddl_Bank.SelectedValue);
            model.BankName = ddl_Bank.SelectedItem.Text;


            //汇款金额与敞口金额需要公式计算
            model.HKMoney = 0;
            model.CKMoney = 0;

            try
            {
                if (!ExistsDraftNo(model.DraftNo))
                {
                    int num = DraftBll.Add(model);
                    if (num > 0)
                    {
                        Alert.ShowInTop("添加成功！");
                    }
                    else
                    {
                        Alert.ShowInTop("添加失败！");
                    }
                }
                else
                {
                    Alert.ShowInTop("汇票号已存在，请重新填写！");
                }
            }
            catch (Exception)
            {

                throw;
            }
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
    }
}
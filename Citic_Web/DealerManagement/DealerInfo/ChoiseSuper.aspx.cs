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

namespace Citic_Web.DealerManagement.DealerInfo
{
    public partial class ChoiseSuper : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    ViewState.Add("DealerID", id);
                }
                GridBind();
            }
        }

        #region PrivateFields--乔春羽(2013.8.28)
        private int DealerID
        {
            get
            {
                int id = 0;
                if (ViewState["DealerID"] != null)
                {
                    id = Convert.ToInt32(ViewState["DealerID"]);
                }
                return id;
            }
        }
        #endregion

        #region 数据绑定--乔春羽(2013.8.28)
        /// <summary>
        /// 绑定数据--乔春羽
        /// </summary>
        private void GridBind()
        {
            DataTable dt = null;
            string where = ConditionInit();
            //指定总记录数
            grid_List.RecordCount = GetAllCount(where);
            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            try
            {
                dt = SupervisorBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];

                grid_List.DataSource = dt;
                grid_List.DataBind();
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "GridBind()");
            }
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("T.IsDelete=0");
            if (!string.IsNullOrEmpty(txt_SName.Text))
            {
                where.AppendFormat(" and T.SupervisorName like '%{0}%'", txt_SName.Text);
            }
            return where.ToString();
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetAllCount(string where)
        {
            return SupervisorBll.GetRecordCount(where);
        }
        #endregion

        #region 数据行绑定事件--乔春羽(2013.8.28)
        /// <summary>
        /// 绑定数据时，做一些处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //性别
                e.Values[1] = Convert.ToInt32(e.Values[1]) == 0 ? "男" : "女";
                //工作来源
                e.Values[5] = Convert.ToInt32(e.Values[5]) == 0 ? "属地" : "外派";
            }
        }
        #endregion

        #region 每页显示数量改变事件--乔春羽(2013.8.28)
        /// <summary>
        /// 每页显示数量改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_List.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GridBind();
        }
        #endregion

        #region 翻页事件--乔春羽(2013.8.28)
        /// <summary>
        /// 翻页事件
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

        #region 查询--乔春羽(2013.8.28)
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 双击数据行，选择监管员--乔春羽(2013.8.28)
        protected void grid_List_RowSelect(object sender, GridRowSelectEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sid = grid_List.DataKeys[e.RowIndex][0].ToString();
                string sname = grid_List.DataKeys[e.RowIndex][1].ToString();
                ViewState.Add("S", string.Format("{0}-{1}", sid, sname));
            }
        }
        #endregion

        #region 保存修改--乔春羽(2013.8.28)（待数据完整时，有待再次测试！）
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            //判断监管员历史是否保存
            bool upHis = false;
            //新添加的监管员历史ID
            int shID = 0;
            //获得经销商对象
            Citic.Model.Dealer model = new Citic.Model.Dealer();
            model = DealerBll.GetModel(DealerID);
            Citic.Model.Supervisor_History sh = null;
            //如果该经销商已存在监管员
            if (!string.IsNullOrEmpty(model.SupervisorName))
            {
                //就先更新了此经销商原来的监管员的“结束时间”
                string where = string.Format(" DealerID={0} and SupervisorID={1}", DealerID, model.SupervisorID);
                int count = Super_HistoryBll.GetRecordCount(where);
                if (count > 0)
                {
                    sh = Super_HistoryBll.GetModelByMaxID(where);
                    sh.Time_End = DateTime.Now;
                    upHis = Super_HistoryBll.Update(sh);
                    //再添加新的监管员记录
                    if (upHis)
                    {
                        sh = new Citic.Model.Supervisor_History();
                        sh.DealerID = DealerID;
                        sh.DealerName = model.DealerName;
                        sh.SupervisorID = int.Parse(ViewState["S"].ToString().Split('-')[0]);
                        sh.SupervisorName = ViewState["S"].ToString().Split('-')[1].ToString();
                        sh.Time_Start = DateTime.Now;
                        shID = Super_HistoryBll.Add(sh);
                    }
                }
                else
                {
                    sh = new Citic.Model.Supervisor_History();
                    sh.DealerID = model.DealerID;
                    sh.DealerName = model.DealerName;
                    sh.SupervisorID = model.SupervisorID.Value;
                    sh.SupervisorName = model.SupervisorName;
                    sh.Time_Start = DateTime.Now.AddDays(-1);
                    //sh.Time_End = DateTime.Now;
                    shID = Super_HistoryBll.Add(sh);
                }

            }
            else    //如果该经销商尚未分配监管员，就直接添加新的监管员历史记录
            {
                sh = new Citic.Model.Supervisor_History();
                sh.DealerID = DealerID;
                sh.DealerName = model.DealerName;
                sh.SupervisorID = int.Parse(ViewState["S"].ToString().Split('-')[0]);
                sh.SupervisorName = ViewState["S"].ToString().Split('-')[1].ToString();
                sh.Time_Start = DateTime.Now;
                shID = Super_HistoryBll.Add(sh);
            }
            //监管员历史修改完，开始给此经销商重新分配监管员
            model.DealerID = DealerID;
            model.SupervisorID = int.Parse(ViewState["S"].ToString().Split('-')[0]);
            model.SupervisorName = ViewState["S"].ToString().Split('-')[1].ToString();
            bool flag = DealerBll.SuperToDealer(model);
            if (flag && shID > 0)
            {
                AlertShowInTop("匹配成功！");
            }
            else
            {
                AlertShowInTop("匹配失败！");
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
        }
        #endregion

    }
}
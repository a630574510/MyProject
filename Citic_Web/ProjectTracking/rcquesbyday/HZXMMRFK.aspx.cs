using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI;
namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class HZXMMRFK : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_Add2.OnClientClick = WindowAdd2.GetShowReference("../../ProjectTracking/rcquesbyday/AddRiskQues.aspx");
            }
        }

        #region 合作项目跟进追踪表查询--乔春羽(2013.8.20)
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            FineUI.Button btn = sender as FineUI.Button;
            if (btn != null)
            {
                if (btn.ID == "btn_Search1")
                {
                    GridBind("1");
                }
                else if (btn.ID == "btn_Search2")
                {
                    GridBind("2");
                }
            }
        }
        #endregion

        #region 数据绑定--乔春羽(2013.8.20)
        private void GridBind(string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                //if (type == "1")
                //{
                //    DataTable dt = null;
                //    try
                //    {
                //        dt = HZXMGJBLL.GetList(string.Empty).Tables[0];
                //    }
                //    catch
                //    {

                //    }
                //    grid_List1.DataSource = dt;
                //    grid_List1.DataBind();
                //}
                //else 
                if (type == "2")
                {
                    DataTable dt = null;
                    try
                    {
                        dt = RQDBLL.GetList(string.Empty).Tables[0];
                    }
                    catch
                    {

                    }
                    grid_List2.DataSource = dt;
                    grid_List2.DataBind();
                }
            }
        }
        #endregion

        #region 行命令事件--乔春羽(2013.8.21)
        protected void grid_List_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            FineUI.Grid grid = sender as FineUI.Grid;
            if (grid != null)
            {
                //if (grid.ID == "grid_List1")
                //{
                //    int id = Convert.ToInt32(grid.DataKeys[e.RowIndex][0]);
                //    bool flag = HZXMGJBLL.Delete(id);
                //    if (flag)
                //    {
                //        Alert.ShowInTop("删除成功！");
                //        GridBind("1");
                //    }
                //    else
                //    {
                //        Alert.ShowInTop("删除失败！");
                //    }
                //}
                //else
                if (grid.ID == "grid_List2")
                {
                    int id = Convert.ToInt32(grid.DataKeys[e.RowIndex][0]);
                    bool flag = RQDBLL.Delete(id);
                    if (flag)
                    {
                        Alert.ShowInTop("删除成功！");
                        GridBind("2");
                    }
                    else
                    {
                        Alert.ShowInTop("删除失败！");
                    }
                }
            }
        }
        #endregion

        #region 行绑定事件--乔春羽(2013.8.21)
        protected void grid_List_RowDataBound(object sender, GridRowEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Grid grid = sender as Grid;
                if (grid != null)
                {
                    //if (grid.ID == "grid_List1")
                    //{
                    //    int index = 19;
                    //    int userid = Convert.ToInt32(e.Values[index]);
                    //    string username = UserBll.GetModel(userid).UserName;
                    //    e.Values[index] = username;
                    //}
                    //else
                    if (grid.ID == "grid_List2")
                    {
                        int index = 15;
                        int userid = Convert.ToInt32(e.Values[index]);
                        string username = UserBll.GetModel(userid).UserName;
                        e.Values[index] = username;
                    }
                }
            }
        }
        #endregion

    }
}
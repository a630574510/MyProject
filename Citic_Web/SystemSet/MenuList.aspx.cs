using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FineUI;

namespace Citic_Web.SystemSet
{
    public partial class MenuList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAddMenu.OnClientClick = WindowAddMenu.GetShowReference("../SystemSet/AddMenu.aspx");
                btnDeleteMenu.OnClientClick = GvMenu.GetNoSelectionAlertReference("请至少选择一项！");
                btnDeleteMenu.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", GvMenu.GetSelectedCountReference());
            }
        }
        protected void btnDeleteMenu_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();

            string[] DelMenu = hfSelectedIDS.Text.Trim().Replace("[", "").Replace("]", "").Split(',');
            for (int i = 0; i < DelMenu.Length; i++)
            {
                int DelId = Convert.ToInt32(DelMenu[i].Replace("\"", ""));
                if (MenuBll.GetModel(DelId).ParentMenu != 0)
                {
                    MenuBll.Delete(DelId);
                }
            }
            BindGrid();
        }
        private void BindGrid()
        {
            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            GvMenu.RecordCount = GetTotalCount();

            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(GvMenu.PageIndex, GvMenu.PageSize);

            // 3.绑定到Grid
            GvMenu.DataSource = table;
            GvMenu.DataBind();
        }
        /// <summary>
        /// 数据绑定，带参数查询-乔春羽
        /// </summary>
        /// <param name="where"></param>
        private void BindGrid(string where)
        {
            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            GvMenu.RecordCount = GetTotalCount(where);

            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(GvMenu.PageIndex, GvMenu.PageSize, where);

            // 3.绑定到Grid
            GvMenu.DataSource = table;
            GvMenu.DataBind();
        }
        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount()
        {

            return MenuBll.GetListForParent("").Tables[0].Rows.Count;
        }

        /// <summary>
        /// 模拟返回总项数-乔春羽
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        private int GetTotalCount(string where)
        {
            return MenuBll.GetListForParent(where).Tables[0].Rows.Count;
        }

        /// <summary>
        /// 模拟数据库分页
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        {
            DataTable source = MenuBll.GetListForParent("").Tables[0];

            DataTable paged = source.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > source.Rows.Count)
            {
                rowend = source.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(source.Rows[i]);
            }

            return paged;
        }
        /// <summary>
        /// 模拟数据库分页-乔春羽
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize, string where)
        {
            DataTable source = MenuBll.GetListForParent(where).Tables[0];

            DataTable paged = source.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > source.Rows.Count)
            {
                rowend = source.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(source.Rows[i]);
            }

            return paged;
        }
        protected void GvMenu_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();

            GvMenu.PageIndex = e.NewPageIndex;
            //乔春羽
            string searchText = tbxMyBox1.Text;
            if (searchText != string.Empty)
            {
                searchText = " b.MenuName like '%" + searchText + "%' ";
                BindGrid(searchText);
            }
            else
            {
                BindGrid();
            }
            //乔春羽

            UpdateSelectedRowIndexArray();
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvMenu.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            //乔春羽
            string searchText = tbxMyBox1.Text;
            if (searchText != string.Empty)
            {
                searchText = " b.MenuName like '%" + searchText + "%' ";
                BindGrid(searchText);
            }
            else
            {
                BindGrid();
            }
            //乔春羽
        }
        private void SyncSelectedRowIndexArrayToHiddenField()
        {
            List<string> ids = GetSelectedRowIndexArrayFromHiddenField();

            List<int> selectedRows = new List<int>();
            if (GvMenu.SelectedRowIndexArray != null && GvMenu.SelectedRowIndexArray.Length > 0)
            {
                selectedRows = new List<int>(GvMenu.SelectedRowIndexArray);
            }

            for (int i = 0, count = Math.Min(GvMenu.PageSize, (GvMenu.RecordCount - GvMenu.PageIndex * GvMenu.PageSize)); i < count; i++)
            {
                string id = GvMenu.DataKeys[i][0].ToString();
                if (selectedRows.Contains(i))
                {
                    if (!ids.Contains(id))
                    {
                        ids.Add(id);
                    }
                }
                else
                {
                    if (ids.Contains(id))
                    {
                        ids.Remove(id);
                    }
                }

            }

            hfSelectedIDS.Text = new JArray(ids).ToString(Formatting.None);


        }
        private List<string> GetSelectedRowIndexArrayFromHiddenField()
        {
            JArray idsArray = new JArray();

            string currentIDS = hfSelectedIDS.Text.Trim();
            if (!String.IsNullOrEmpty(currentIDS))
            {
                idsArray = JArray.Parse(currentIDS);
            }
            else
            {
                idsArray = new JArray();
            }
            return new List<string>(idsArray.ToObject<string[]>());
        }
        private void UpdateSelectedRowIndexArray()
        {
            List<string> ids = GetSelectedRowIndexArrayFromHiddenField();

            List<int> nextSelectedRowIndexArray = new List<int>();
            for (int i = 0, count = Math.Min(GvMenu.PageSize, (GvMenu.RecordCount - GvMenu.PageIndex * GvMenu.PageSize)); i < count; i++)
            {
                string id = GvMenu.DataKeys[i][0].ToString();
                if (ids.Contains(id))
                {
                    nextSelectedRowIndexArray.Add(i);
                }
            }
            GvMenu.SelectedRowIndexArray = nextSelectedRowIndexArray.ToArray();
        }
        //<summary>
        //关闭窗体
        //</summary>
        //<param name="sender"></param>
        //<param name="e"></param>
        protected void Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #region 乔春羽 搜索
        // 点击 TwinTriggerBox 的搜索按钮
        protected void ttbxMyBox1_Trigger2Click(object sender, EventArgs e)
        {
            // 执行搜索动作
            string searchText = this.tbxMyBox1.Text;
            tbxMyBox1.ShowTrigger1 = true;
            if (searchText != string.Empty)
                searchText = " b.MenuName like '%" + searchText + "%' ";
            BindGrid(searchText);
        }

        // 点击 TwinTriggerBox 的取消按钮
        protected void ttbxMyBox1_Trigger1Click(object sender, EventArgs e)
        {
            // 执行清空动作
            tbxMyBox1.Text = "";
            tbxMyBox1.ShowTrigger1 = false;
        }
        #endregion
    }
}
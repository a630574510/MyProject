using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FineUI;
using System.Data;
namespace Citic_Web.SystemSet
{
    public partial class RoleList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAddRole.OnClientClick = WindowAddRole.GetShowReference("../SystemSet/AddRole.aspx");
                btnDeleteRole.OnClientClick = GvRole.GetNoSelectionAlertReference("请至少选择一项！");
                btnDeleteRole.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", GvRole.GetSelectedCountReference());
                btn_ToMenu.OnClientClick = GvRole.GetNoSelectionAlertReference("请至少选择一项！");
                btn_Modify.OnClientClick = GvRole.GetNoSelectionAlertReference("请至少选择一项！");
                //权限过滤
                RoleValidate();
            }
        }
        protected void btnDeleteRole_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();

            string[] DelRole = hfSelectedIDS.Text.Trim().Replace("[", "").Replace("]", "").Split(',');
            for (int i = 0; i < DelRole.Length; i++)
            {
                RoleBll.Delete(Convert.ToInt32(DelRole[i].Replace("\"", "")));
            }
            BindGrid();
        }
        private void BindGrid()
        {
            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            GvRole.RecordCount = GetTotalCount();

            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(GvRole.PageIndex, GvRole.PageSize);

            // 3.绑定到Grid
            GvRole.DataSource = table;
            GvRole.DataBind();
        }
        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount()
        {
            return RoleBll.GetList("").Tables[0].Rows.Count;
        }

        /// <summary>
        /// 模拟数据库分页
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        {
            DataTable source = RoleBll.GetList("").Tables[0];

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
        protected void GvRole_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();

            GvRole.PageIndex = e.NewPageIndex;
            BindGrid();

            UpdateSelectedRowIndexArray();
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvRole.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            BindGrid();
        }
        private void SyncSelectedRowIndexArrayToHiddenField()
        {
            List<string> ids = GetSelectedRowIndexArrayFromHiddenField();

            List<int> selectedRows = new List<int>();
            if (GvRole.SelectedRowIndexArray != null && GvRole.SelectedRowIndexArray.Length > 0)
            {
                selectedRows = new List<int>(GvRole.SelectedRowIndexArray);
            }

            for (int i = 0, count = Math.Min(GvRole.PageSize, (GvRole.RecordCount - GvRole.PageIndex * GvRole.PageSize)); i < count; i++)
            {
                string id = GvRole.DataKeys[i][0].ToString();
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
            for (int i = 0, count = Math.Min(GvRole.PageSize, (GvRole.RecordCount - GvRole.PageIndex * GvRole.PageSize)); i < count; i++)
            {
                string id = GvRole.DataKeys[i][0].ToString();
                if (ids.Contains(id))
                {
                    nextSelectedRowIndexArray.Add(i);
                }
            }
            GvRole.SelectedRowIndexArray = nextSelectedRowIndexArray.ToArray();
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

        #region 查询--乔春羽(2013.9.3)
        protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {
            // 执行清空动作
            ttbSearch.Text = "";
            ttbSearch.ShowTrigger1 = false;
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
            if (urls.Contains("Search92"))
            {

            }
            if (urls.Contains("Insert92"))
            {
                btnAddRole.Visible = true;
                tbs_Add.Visible = true;
            }
            if (urls.Contains("Delete92"))
            {
                btnDeleteRole.Visible = true;
                tbs_Delete.Visible = true;
            }
            if (urls.Contains("Modify92"))
            {
                btn_Modify.Visible = true;
                tbs_Modify.Visible = true;
            }
            if (urls.Contains("Excel92"))
            {
                //btnExport.Visible = true;
                //hl_ExportExcel.Visible = true;
            }
            if (urls.Contains("Match92"))
            {
                btn_ToMenu.Visible = true;
            }
        }
        #endregion

        #region 修改--乔春羽(2013.9.5)
        protected void btn_Modify_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GvRole.DataKeys[GvRole.SelectedRowIndex][0]);
            string name = GvRole.DataKeys[GvRole.SelectedRowIndex][1].ToString();
            string path = string.Format("~/SystemSet/EditRole.aspx?RoleId={0}&RoleName={1}", id, name);
            WindowEditRole.IFrameUrl = path;
            WindowEditRole.Hidden = false;
        }
        #endregion

        #region 分配权限--乔春羽(2013.9.5)
        protected void btn_ToMenu_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GvRole.DataKeys[GvRole.SelectedRowIndex][0]);
            string name = GvRole.DataKeys[GvRole.SelectedRowIndex][1].ToString();
            string path = string.Format("~/SystemSet/MenuToRole.aspx?RoleId={0}&RoleName={1}", id, name);
            WindowMenuToRole.IFrameUrl = path;
            WindowMenuToRole.Hidden = false;
        }
        #endregion

    }
}
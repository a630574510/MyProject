using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Text;
using System.Data;
using System.Collections;
namespace Citic_Web.SystemSet
{
    public partial class MenuToRole1 : BasePage
    {
        private static Citic.BLL.UserPermission UserPermissionBll = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CBToRoleBind();
            }
        }

        #region PrivateFields--乔春羽(2013.9.3)
        private DataTable _DataSource;
        /// <summary>
        /// 菜单项
        /// </summary>
        public DataTable DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }

        private DataTable dtUrls;

        public DataTable DtUrls
        {
            get { return dtUrls; }
            set { dtUrls = value; }
        }
        #endregion

        #region 递归方法，加载子菜单项--乔春羽(2013.9.3)
        private void AddByTurn(FineUI.TreeNode tn, int parentID)
        {
            foreach (DataRow row in DataSource.Rows)
            {
                if (Convert.ToInt32(row["ParentMenu"]) == parentID)
                {
                    FineUI.TreeNode tnode = new FineUI.TreeNode();
                    tnode.Text = row["MenuName"].ToString();
                    tnode.EnableCheckBox = true;
                    //tnode.SingleClickExpand = true;
                    tnode.Leaf = false;
                    tnode.NodeID = row["MenuId"].ToString();
                    tnode.AutoPostBack = true;
                    //判断是否需要选中
                    tnode.Checked = IsExistsRole(row["MenuId"].ToString());
                    AddByTurn(tnode, Convert.ToInt32(row["MenuId"]));
                    tn.Nodes.Add(tnode);
                }
            }
        }
        #endregion

        #region 加载菜单项，并加载出角色应有的权限--乔春羽(2013.9.3)
        private void CBToRoleBind()
        {
            if (UserPermissionBll == null)
            {
                UserPermissionBll = new Citic.BLL.UserPermission();
            }

            int RoleId = Convert.ToInt32(Request.QueryString["RoleId"]);
            DataSource = MenuBll.GetAllList().Tables[0];
            DtUrls = UserPermissionBll.GetList("RoleId=" + RoleId).Tables[0];
            foreach (DataRow row in DataSource.Rows)
            {
                if (Convert.ToInt32(row["ParentMenu"]) == 0)
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["MenuName"].ToString();
                    node.EnableCheckBox = true;
                    node.SingleClickExpand = true;
                    node.Leaf = false;
                    node.NodeID = row["MenuId"].ToString();
                    node.AutoPostBack = true;
                    //判断是否需要选中
                    node.Checked = IsExistsRole(row["MenuId"].ToString());
                    AddByTurn(node, Convert.ToInt32(row["MenuId"]));
                    Tree1.Nodes.Add(node);
                }
            }


            //string CBToRoleList = "";
            //if (DtUrls.Rows.Count > 0)
            //{
            //    for (int i = 0; i < DtUrls.Rows.Count; i++)
            //    {
            //        CBToRoleList += DtUrls.Rows[i]["MenuId"].ToString() + ",";
            //    }
            //    if (CBToRoleList != "")
            //    {
            //        CBToRoleList = CBToRoleList.Substring(0, CBToRoleList.Length - 1);
            //        Tree1.SelectedNodeIDArray = CBToRoleList.Split(',');
            //    }
            //}
        }

        /// <summary>
        /// 判断用户权限是否存在
        /// </summary>
        /// <returns></returns>
        private bool IsExistsRole(string menuName)
        {
            bool flag = false;
            string where = string.Format("MenuId='{0}'", menuName);
            DataRow[] rows = DtUrls.Select(where);
            flag = rows.Length > 0;
            return flag;
        }
        #endregion

        #region 全选与反选--乔春羽(2013.9.3)
        protected void Tree1_NodeCheck(object sender, TreeCheckEventArgs e)
        {
            if (e.Checked)
            {
                Tree1.CheckAllNodes(e.Node.Nodes);
                if (e.Node.ParentNode != null)
                {
                    e.Node.ParentNode.Checked = true;
                }
            }
            else
            {

                int num = 0;
                if (e.Node.ParentNode != null)
                {
                    foreach (FineUI.TreeNode node in e.Node.ParentNode.Nodes)
                    {
                        if (node.Checked)
                        {
                            num = 1;
                            break;
                        }
                    }
                }
                if (num > 0)
                {
                    Tree1.UncheckAllNodes(e.Node.Nodes);
                }
                else
                {
                    Tree1.UncheckAllNodes(e.Node.Nodes);
                    if (e.Node.ParentNode != null)
                    {
                        e.Node.ParentNode.Checked = false;
                    }
                }
            }
        }
        #endregion

        #region 保存并关闭--乔春羽(2013.9.4)
        /// <summary>
        /// 保存并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑
            SaveMenu();
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        /// <summary>
        /// 保存分配的模块信息修改
        /// </summary>
        private void SaveMenu()
        {
            int roleid = Convert.ToInt32(Request.QueryString["RoleId"]);
            UserPermissionBll.Delete(string.Format(" RoleId={0} ", roleid));
            string[] roles = Tree1.GetCheckedNodeIDs();
            if (roles != null && roles.Length > 0)
            {
                foreach (string role in roles)
                {
                    Citic.Model.UserPermission model = new Citic.Model.UserPermission();
                    model.MenuId = int.Parse(role);
                    model.RoleId = roleid;
                    UserPermissionBll.Add(model);
                }
            }
        }
        #endregion

        #region 展开节点--乔春羽(2013.8.28)
        protected void Tree1_NodeExpand(object sender, TreeExpandEventArgs e)
        {

        }
        #endregion

    }
}
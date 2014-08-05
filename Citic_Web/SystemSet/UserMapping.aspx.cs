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
namespace Citic_Web.SystemSet
{
    public partial class UserMapping : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Type = Request.QueryString["_type"];
                Role = Request.QueryString["_role"];
                UserID = Request.QueryString["_user"];

                BankBind();
                TreeBankDataBind();
                if (Type.Equals(Common.UserMappingType.Bank.ToString()))
                {
                    switch (Role)
                    {
                        case "8":   //银行
                            pnl_Bank.Visible = true;
                            tree_Bank.Visible = false;
                            //如果选择的用户有匹配银行，则在此页面中显示出来。
                            Citic.Model.UserMapping model = UMBLL.GetModelByCondition(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", UserID, Role));
                            if (model != null)
                            {
                                this.hf_BankID.Text = model.MappingID.Value.ToString();
                                this.lbl_BankName.Text = BankBll.GetModel(model.MappingID.Value).BankName;
                                this.lbl_BankName.CssStyle = "font-weight:bold;font-size:18px;color:red";
                            }
                            break;
                        case "5":   //市场专员
                        case "6":   //业务专员
                            pnl_Bank.Visible = false;
                            tree_Bank.Visible = true;
                            DataTable dt = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", UserID, Role)).Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                List<string> ids = new List<string>();
                                foreach (DataRow row in dt.Rows)
                                {
                                    ids.Add(row["MappingID"].ToString());
                                }
                                tree_Bank.SelectedNodeIDArray = ids.ToArray();
                            }
                            break;
                        case "9":   //厂家
                            break;
                    }
                }
                else if (Type.Equals(Common.UserMappingType.Brand.ToString()))
                {

                }
            }
        }

        #region PrivateFields--乔春羽(2014.3.5)
        private string Role
        {
            get { return (string)ViewState["role"]; }
            set { ViewState["role"] = value; }
        }
        private string Type
        {
            get { return (string)ViewState["Type"]; }
            set { ViewState["Type"] = value; }
        }
        private string UserID
        {
            get { return (string)ViewState["UserID"]; }
            set { ViewState["UserID"] = value; }
        }
        private DataTable _DataSource;
        /// <summary>
        /// 银行集合
        /// </summary>
        public DataTable DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }

        private DataTable _UserMapping;

        public DataTable DtUserMapping
        {
            get { return _UserMapping; }
            set { _UserMapping = value; }
        }
        #endregion

        #region 加载信息--乔春羽(2014.3.5)

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("T.IsDelete=0");
            if (this.tb_Bank.Text != string.Empty)
            {
                where.AppendFormat(" and T.BankName like '%{0}%'", this.tb_Bank.Text);
            }
            if (this.rbl_Types.SelectedValue != "-1")
            {
                where.AppendFormat(" and T.BankType={0}", rbl_Types.SelectedValue);
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
            return BankBll.GetRecordCount(where);
        }
        /// <summary>
        /// 绑定银行信息
        /// </summary>
        private void BankBind()
        {
            DataTable dt = null;
            //where条件
            string where = ConditionInit();

            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where);

            if (this.grid_List.PageCount <= this.grid_List.PageIndex)
            {
                this.grid_List.PageIndex = 0;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            try
            {
                dt = BankBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];

                grid_List.DataSource = dt;
                grid_List.DataBind();
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "GridBind()");
            }
        }

        /// <summary>
        /// 绑定合作行信息
        /// 按照合作行的上下级关系
        /// </summary>
        private void TreeBankDataBind()
        {
            DtUserMapping = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", UserID, Role)).Tables[0];
            DataSource = BankBll.GetList(" T.IsDelete=0 ").Tables[0];
            if (DataSource != null && DataSource.Rows.Count > 0)
            {
                foreach (DataRow row in DataSource.Rows)
                {
                    if (row["ParentID"].ToString() == "0")
                    {
                        FineUI.TreeNode tnode = new FineUI.TreeNode();
                        tnode.NodeID = row["BankID"].ToString();
                        tnode.Text = row["BankName"].ToString();
                        tnode.EnableCheckBox = true;
                        tnode.SingleClickExpand = true;
                        tnode.Leaf = false;
                        tnode.AutoPostBack = true;
                        //判断是否需要选中
                        tnode.Checked = isExists(Convert.ToInt32(row["BankID"]));
                        //需要一步递归
                        AddNodeByTurn(tnode, Convert.ToInt32(row["BankID"]));
                        tree_Bank.Nodes.Add(tnode);
                    }
                }
            }
        }

        private bool isExists(int bankID)
        {
            bool flag = false;
            DataRow[] rows = DtUserMapping.Select("MappingID=" + bankID);
            flag = rows == null ? false : rows.Length > 0 ? true : false;
            return flag;
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parentID"></param>
        private void AddNodeByTurn(FineUI.TreeNode parentNode, int parentID)
        {
            DataRow[] rows = DataSource.Select("ParentID=" + parentID);
            if (rows != null && rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.NodeID = row["BankID"].ToString();
                    node.Text = row["BankName"].ToString();
                    node.EnableCheckBox = true;
                    node.SingleClickExpand = true;
                    node.Leaf = false;
                    node.AutoPostBack = true;
                    //判断是否需要选中
                    node.Checked = isExists(Convert.ToInt32(row["BankID"]));
                    //需要一步递归
                    AddNodeByTurn(node, Convert.ToInt32(row["BankID"]));
                    parentNode.Nodes.Add(node);
                }
            }
        }
        #endregion

        #region 查询银行--乔春羽(2014.3.18)
        protected void tb_Bank_TriggerClick(object sender, EventArgs e)
        {
            BankBind();
        }
        #endregion

        #region //保存并关闭--乔春羽(2014.3.5)
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            int result = 0;
            result = UMBLL.DeleteByCondition(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='{2}'", UserID, Role, Type));

            List<Citic.Model.UserMapping> ums = new List<Citic.Model.UserMapping>();
            switch (int.Parse(Role))
            {
                case 8:
                    result = UMBLL.Add(new Citic.Model.UserMapping() { UserID = int.Parse(UserID), RoleID = int.Parse(Role), MappingID = int.Parse(this.hf_BankID.Text), MappingType = Common.UserMappingType.Bank.ToString() });
                    break;
                case 5:
                case 6:
                    string[] bankIDs = tree_Bank.GetCheckedNodeIDs();
                    if (bankIDs != null && bankIDs.Length > 0)
                    {
                        foreach (string bankID in bankIDs)
                        {
                            ums.Add(new Citic.Model.UserMapping() { UserID = int.Parse(UserID), RoleID = int.Parse(Role), MappingID = int.Parse(bankID), MappingType = Common.UserMappingType.Bank.ToString() });
                        }
                        result = UMBLL.AddRange(ums);
                    }
                    else 
                    {
                        result = 1;
                    }
                    break;
                case 9:
                    break;
            }

            if (result > 0)
            {
                AlertShowInTop("匹配成功！");
                PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
            }
            else
            {
                AlertShowInTop("匹配失败！");
            }
        }
        #endregion

        #region 选择树形菜单--乔春羽(2014.3.18)
        protected void tree_Bank_NodeCheck(object sender, TreeCheckEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Checked)
                {
                    tree_Bank.CheckAllNodes(e.Node.Nodes);
                    if (e.Node.ParentNode != null)
                    {
                        e.Node.ParentNode.Checked = true;
                    }
                }
                else
                {
                    tree_Bank.UncheckAllNodes(e.Node.Nodes);
                }
            }
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
            BankBind();
            UpdateSelectedRowIndexArray(grid_List, hfSelectedIDS);
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
            BankBind();
        }
        #endregion

        #region 行绑定事件（银行信息表格）--乔春羽
        protected void grid_List_RowDataBound(object sender, GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                int index = 2;
                int type = Convert.ToInt32(e.Values[index]);
                switch (type)
                {
                    case 0:
                        e.Values[index] = "总行";
                        break;
                    case 1:
                        e.Values[index] = "分行";
                        break;
                    case 2:
                        e.Values[index] = "支行";
                        break;
                }
            }
        }
        #endregion

        #region //表格行单击事件（银行信息表格，选择银行）--乔春羽
        protected void grid_List_RowSelect(object sender, GridRowSelectEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string bankName = grid_List.Rows[e.RowIndex].Values[0].ToString();
                this.lbl_BankName.Text = bankName;
                this.lbl_BankName.CssStyle = "font-weight:bold;font-size:18px;color:red";
                hf_BankID.Text = grid_List.Rows[e.RowIndex].DataKeys[0].ToString();
            }
            else
            {
                AlertShowInTop("请选择行！");
            }
        }
        #endregion
    }
}
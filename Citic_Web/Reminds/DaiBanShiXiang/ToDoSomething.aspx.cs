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

namespace Citic_Web.Reminds.DaiBanShiXiang
{
    public partial class WebForm1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_Sures.OnClientClick = grid_List.GetNoSelectionAlertInTopReference("未选择任何数据！");
                btn_Passes.OnClientClick = grid_List.GetNoSelectionAlertInTopReference("未选择任何数据！");
                btn_Returns.OnClientClick = grid_List.GetNoSelectionAlertInTopReference("未选择任何数据！");
                //3-业务经理，8-银行专员，6-品牌专员，10-监管员
                RoleValidate();
                BankDataBind();
                DealerDataBind();
            }
        }
        #region PrivateFileds--乔春羽
        public List<string> Roles
        {
            get
            {
                return ViewState["roles"] as List<string>;
            }
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
            if (urls.Contains("btn_Sures"))
            {
                btn_Sures.Visible = true;
            }
            if (urls.Contains("btn_Returns"))
            {
                btn_Returns.Visible = true;
            }
            if (urls.Contains("btn_Passes"))
            {
                btn_Passes.Visible = true;
            }
            if (urls.Contains("btn_Deletes"))
            {
                btn_Deletes.Visible = true;
            }
            if (urls.Contains("Search11"))
            {
                btn_Search.Visible = true;
            }
        }
        /// <summary>
        /// 权限过滤--乔春羽
        /// </summary>
        /// <param name="menuUrl">被过滤的功能</param>
        /// <returns></returns>
        private bool RoleFilter(string menuUrl)
        {
            bool flag = false;

            return flag;
        }
        #endregion

        #region 绑定数据--乔春羽
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            //where条件
            string where = ConditionInit();

            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where);

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = DBSXBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];
            ViewState.Add("dt", dt);

            grid_List.DataSource = dt;
            grid_List.DataBind();
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("T.IsDelete=0");
            if (this.ddl_Bank.SelectedValue != null && this.ddl_Bank.SelectedValue != "0")
            {
                where.AppendFormat(" and BankID = {0}", ddl_Bank.SelectedValue);
            }
            if (this.ddl_Dealer.SelectedValue != null && this.ddl_Dealer.SelectedValue != "0")
            {
                if (!string.IsNullOrEmpty(this.txt_DealerName.Text))
                {
                    where.AppendFormat(" and (DealerID = {0} or DealerName like '%{1}%')", ddl_Dealer.SelectedValue, this.txt_DealerName.Text);
                }
                else
                {
                    where.AppendFormat(" and (DealerID = {0})", ddl_Dealer.SelectedValue);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this.txt_DealerName.Text))
                {
                    where.AppendFormat(" and (DealerName like '%{0}%')", this.txt_DealerName.Text);
                }
            }
            if (this.ttb_Search.Text != string.Empty)
            {
                where.AppendFormat(" and Vin like '%{0}%'", this.ttb_Search.Text);
            }
            if (this.ddl_Status.SelectedValue != "-1")
            {
                where.AppendFormat(" and Status = {0}", this.ddl_Status.SelectedValue);
            }
            return where.ToString();
        }

        /// <summary>
        /// 获得查询后结果的总数据数量
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return DBSXBll.GetRecordCount(where);
        }
        #endregion

        #region 加载合作银行信息--乔春羽
        private void BankDataBind()
        {
            DataTable dt = null;
            //登录人是监管员
            if (this.CurrentUser.RoleId == 10)
            {
                dt = Dealer_BankBll.GetBankIDAndNameFilterRole(this.CurrentUser.RelationID.Value).Tables[0];
            }
            else //否则显示所有数据
            {
                dt = BankBll.GetBankIDAndBankName("IsDelete=0");
            }

            ddl_Bank.DataTextField = "BankName";
            ddl_Bank.DataValueField = "BankID";
            ddl_Bank.DataSource = dt;
            ddl_Bank.DataBind();

            ddl_Bank.Items.Insert(0, new FineUI.ListItem("请选择", "0"));

        }
        #endregion

        #region 加载企业信息（经销商）--乔春羽
        private void DealerDataBind()
        {
            string val = ddl_Bank.SelectedValue;
            if (val != null && val != string.Empty)
            {
                DataTable dt = Dealer_BankBll.GetDealerByBankForDataTable(int.Parse(val), string.Empty);

                ddl_Dealer.DataTextField = "DealerName";
                ddl_Dealer.DataValueField = "DealerID";
                ddl_Dealer.DataSource = dt;
                ddl_Dealer.DataBind();
            }
            ddl_Dealer.Items.Insert(0, new FineUI.ListItem("请选择", "0"));
        }
        #endregion

        #region 选择银行，加载企业信息--乔春羽
        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            DealerDataBind();
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
        /// 翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);
            grid_List.PageIndex = e.NewPageIndex;

            //乔春羽
            GridBind();

            UpdateSelectedRowIndexArray(grid_List, hfSelectedIDS);
        }

        #endregion

        #region 数据行绑定事件--乔春羽
        /// <summary>
        /// 行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                int type = Convert.ToInt32(e.Values[3]);
                switch (type)
                {
                    case (int)Common.CarStatus.Move:
                        e.Values[3] = "移动申请";
                        break;
                    case (int)Common.CarStatus.OutStorage:
                        e.Values[3] = "出库申请";
                        break;
                }

                //二级过滤
                type = Convert.ToInt32(e.Values[6]);
                switch (type)
                {
                    case 1: //状态为“通过”
                        e.Values[6] = "通过";
                        //ControlTheButtonVisible(e.RowIndex, 1);
                        break;
                    case 2:
                        e.Values[6] = "处理中";
                        //ControlTheButtonVisible(e.RowIndex, 2);
                        break;
                    case 3:
                        e.Values[6] = "未通过";
                        //ControlTheButtonVisible(e.RowIndex, 3);
                        break;
                }
            }
        }

        private System.Web.UI.WebControls.LinkButton GetLinkButtonByID(int rowIndex, string id)
        {
            return (grid_List.Rows[rowIndex].FindControl(id) as System.Web.UI.WebControls.LinkButton);
        }

        /// <summary>
        /// 控制按钮的显示与隐藏
        /// </summary>
        /// <param name="state"></param>
        private void ControlTheButtonVisible(int rowIndex, int state)
        {
            switch (state)
            {
                case 1: //通过
                case 3: //未通过
                    GetLinkButtonByID(rowIndex, "lb_Sure").Visible = true;
                    GetLinkButtonByID(rowIndex, "lb_Delete").Visible = false;
                    GetLinkButtonByID(rowIndex, "lb_ApplyPass").Visible = false;
                    GetLinkButtonByID(rowIndex, "lb_ApplyReturn").Visible = false;
                    break;
                case 2: //处理中
                    if (this.CurrentUser.RoleId == 8)   //银行专员
                    {
                        GetLinkButtonByID(rowIndex, "lb_Sure").Visible = false;
                        GetLinkButtonByID(rowIndex, "lb_Delete").Visible = false;
                        GetLinkButtonByID(rowIndex, "lb_ApplyPass").Visible = true;
                        GetLinkButtonByID(rowIndex, "lb_ApplyReturn").Visible = true;
                    }
                    else if (this.CurrentUser.RoleId == 3) //业务经理
                    {
                        GetLinkButtonByID(rowIndex, "lb_Sure").Visible = false;
                        GetLinkButtonByID(rowIndex, "lb_Delete").Visible = true;
                        GetLinkButtonByID(rowIndex, "lb_ApplyPass").Visible = false;
                        GetLinkButtonByID(rowIndex, "lb_ApplyReturn").Visible = false;
                    }
                    break;
            }
        }
        #endregion

        #region 查询--乔春羽
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 业务操作事件（确定&删除&申请通过&申请退回）--乔春羽
        protected void Operate_Click(object sender, EventArgs e)
        {
            int rowIndex = grid_List.SelectedRowIndex;
            if (rowIndex > -1)
            {
                int id = Convert.ToInt32(grid_List.DataKeys[rowIndex][0]);
                System.Web.UI.WebControls.LinkButton lb = sender as System.Web.UI.WebControls.LinkButton;
                bool flag = false;
                if (lb != null)
                {
                    switch (lb.ID)
                    {
                        //“确定”操作
                        case "lb_Sure":
                            //监管员
                            if (this.CurrentUser.RoleId == 10)
                            {
                                flag = DBSXBll.ModifyIsLook(10, new Citic.Model.DBSX() { ID = id, OperateID = this.CurrentUser.UserId, OperateTime = DateTime.Now });
                            }
                            //业务经理
                            else if (this.CurrentUser.RoleId == 3)
                            {
                                flag = DBSXBll.ModifyIsLook(3, new Citic.Model.DBSX() { ID = id, OperateID = this.CurrentUser.UserId, OperateTime = DateTime.Now });
                            }
                            break;
                        //“删除”操作
                        case "lb_Delete":
                            flag = DBSXBll.Delete(id);
                            break;
                        //“申请通过”操作
                        case "lb_ApplyPass":
                            flag = DBSXBll.Update(new Citic.Model.DBSX() { ID = id, Status = 1, OperateID = this.CurrentUser.UserId, OperateTime = DateTime.Now });
                            break;
                        //“申请退回”操作
                        case "lb_ApplyReturn":
                            flag = DBSXBll.Update(new Citic.Model.DBSX() { ID = id, Status = 3, OperateID = this.CurrentUser.UserId, OperateTime = DateTime.Now });
                            break;
                    }
                }
            }
        }
        #endregion

        #region 行命令事件--乔春羽(2013.11.28)
        protected void grid_List_RowCommand(object sender, GridCommandEventArgs e)
        {

        }
        #endregion

        #region “通过”申请操作（业务经理的操作）--乔春羽(2013.12.30)
        protected void btn_Passes_Click(object sender, EventArgs e)
        {
            int[] indexs = grid_List.SelectedRowIndexArray;
            if (indexs != null && indexs.Length > 0)
            {
                List<Citic.Model.Car> cars = new List<Citic.Model.Car>();
                foreach (int index in indexs)
                {
                    //申请事项
                    int reqType = Convert.ToInt32(grid_List.DataKeys[index][4]);
                    //信息
                    string message = string.Format("操作ID:{0};操作人:{1};姓名:{4};操作时间:{2};操作结果:{3};角色:业务经理", this.CurrentUser.UserId, this.CurrentUser.UserName, DateTime.Now, "通过", this.CurrentUser.TrueName);
                    //待办事项状态改为通过
                    int id = Convert.ToInt32(grid_List.DataKeys[index][0]);
                    Citic.Model.DBSX model = DBSXBll.GetModel(id);
                    model.OperateID = this.CurrentUser.UserId;
                    model.OperateTime = DateTime.Now;
                    model.IsBMLook = message;
                    model.Status = 1;
                    bool flag = DBSXBll.Update(model);
                    if (flag)
                    {
                        //修改“车辆状态”
                        string tbName = string.Format("tb_Car_{0}_{1}", grid_List.DataKeys[index][2], grid_List.DataKeys[grid_List.SelectedRowIndex][3]);
                        string vin = grid_List.DataKeys[index][1].ToString();

                        cars.Add(new Citic.Model.Car() { TableName = tbName, Vin = vin, Statu = reqType });
                    }
                }
                int num = CarBll.UpdateRange(cars.ToArray());
                if (num > 0)
                {
                    Alert.ShowInTop("操作成功！");
                    GridBind();
                }
                else
                {
                    Alert.ShowInTop("操作失败！");
                }
            }
        }
        #endregion

        #region "退回"申请操作（业务经理的操作）--乔春羽(2013.12.30)
        protected void btn_Returns_Click(object sender, EventArgs e)
        {
            int[] indexs = grid_List.SelectedRowIndexArray;
            if (indexs != null && indexs.Length > 0)
            {
                List<Citic.Model.Car> cars = new List<Citic.Model.Car>();
                foreach (int index in indexs)
                {
                    //申请事项
                    int reqType = Convert.ToInt32(grid_List.DataKeys[index][4]);
                    int status = 0;
                    //信息
                    string message = string.Format("操作ID:{0};操作人:{1};姓名:{4};操作时间:{2};操作结果:{3};角色:业务经理", this.CurrentUser.UserId, this.CurrentUser.UserName, DateTime.Now, "驳回", this.CurrentUser.TrueName);
                    if (reqType == 0 || reqType == 2) status = 1;
                    //待办事项状态改为通过
                    int id = Convert.ToInt32(grid_List.DataKeys[index][0]);
                    Citic.Model.DBSX model = DBSXBll.GetModel(id);
                    model.OperateID = this.CurrentUser.UserId;
                    model.OperateTime = DateTime.Now;
                    model.IsBMLook = message;
                    model.Status = 3;
                    bool flag = DBSXBll.Update(model);
                    if (flag)
                    {
                        //修改“车辆状态”
                        string tbName = string.Format("tb_Car_{0}_{1}", grid_List.DataKeys[index][2], grid_List.DataKeys[grid_List.SelectedRowIndex][3]);
                        string vin = grid_List.DataKeys[index][1].ToString();
                        cars.Add(new Citic.Model.Car() { TableName = tbName, Vin = vin, Statu = status });
                    }
                }
                int num = CarBll.UpdateRange(cars.ToArray());
                if (num > 0)
                {
                    Alert.ShowInTop("操作成功！");
                    GridBind();
                }
                else
                {
                    Alert.ShowInTop("操作失败！");
                }
            }
        }
        #endregion

        #region "确定"申请操作，表示监管员“看过了”--乔春羽(2013.12.30)
        protected void btn_Sures_Click(object sender, EventArgs e)
        {
            int[] indexs = grid_List.SelectedRowIndexArray;
            if (indexs != null && indexs.Length > 0)
            {
                foreach (int index in indexs)
                {
                    //信息
                    string message = string.Format("操作ID:{0};操作人:{1};姓名:{4};操作时间:{2};操作结果:{3};角色:监管员", this.CurrentUser.UserId, this.CurrentUser.UserName, DateTime.Now, "该监管员已经看过该信息", this.CurrentUser.TrueName);
                    //待办事项状态改为监管员看过了的类型
                    int id = Convert.ToInt32(grid_List.DataKeys[index][0]);
                    Citic.Model.DBSX model = DBSXBll.GetModel(id);
                    model.OperateID = this.CurrentUser.UserId;
                    model.OperateTime = DateTime.Now;
                    model.IsSupervisorLook = message;
                    bool flag = DBSXBll.Update(model);
                    if (flag)
                    {
                        Alert.ShowInTop("操作成功！");
                        GridBind();
                    }
                    else
                    {
                        Alert.ShowInTop("操作成功！");
                    }
                }
            }
        }
        #endregion
    }
}
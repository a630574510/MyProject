using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Citic_Web.Common;

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
            try
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
                DataTable dt = DBSXBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];

                grid_List.DataSource = dt;
                grid_List.DataBind();
            }
            catch (Exception ex)
            {
                AlertShowInTop(ex.Message);
            }
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("T.IsDelete = 0 ");

            //权限过滤
            switch (this.CurrentUser.RoleId)
            {
                case 8:     //银行
                    where.Append(" AND T.Status = 2 AND (IsBMLook = '' or IsBMLook is null) ");
                    DataSet ds = this.UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            where.AppendFormat(" And BankID = '{0}' ", dt.Rows[0]["MappingID"].ToString());

                            Citic.Model.Bank bankModel = BankBll.GetModel(Convert.ToInt32(dt.Rows[0]["MappingID"]));
                            if (bankModel != null)
                            {
                                StringBuilder searchBankWhere = new StringBuilder(" T.CollaborateType = 1 ");
                                string bankLevel = bankModel.ConnectID;
                                if (bankLevel == Common.Common.GuangDaString)
                                {
                                    searchBankWhere.Append(" AND ( GD_ID IS NOT NULL OR GD_ID <> '' )");
                                }
                                else if (bankLevel == Common.Common.ZhongXinString)
                                {
                                    searchBankWhere.Append(" AND ( ZX_ID IS NOT NULL OR ZX_ID <> '' )");
                                }
                                else { }
                                DataSet dealerDs = Dealer_BankBll.GetDealers(searchBankWhere.ToString());
                                if (dealerDs != null && dealerDs.Tables.Count > 0 && dealerDs.Tables[0] != null)
                                {
                                    DataTable tempDt = dealerDs.Tables[0];
                                    if (tempDt.Rows.Count > 0)
                                    {
                                        string[] dealerIDs = new string[tempDt.Rows.Count];
                                        for (int i = 0; i < dealerIDs.Length; i++)
                                        {
                                            dealerIDs[i] = tempDt.Rows[i]["DealerID"].ToString();
                                        }
                                        where.AppendFormat(" AND DealerID not in ({0})", string.Join(",", dealerIDs));
                                    }
                                }
                            }
                        }
                        else
                        {
                            where.Append(" And BankID = '0' ");
                        }
                    }
                    else { where.Append(" And BankID = '0' "); }
                    break;
                case 5: //市场专员
                case 6: //业务专员
                    StringBuilder ids = new StringBuilder(string.Empty);
                    DataTable _dt = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId)).Tables[0];
                    if (_dt != null && _dt.Rows.Count > 0)
                    {
                        ids.Append(" AND BankID in (");
                        foreach (DataRow row in _dt.Rows)
                        {
                            ids.AppendFormat("{0},", row["MappingID"].ToString());
                        }
                        ids.Remove(ids.Length - 1, 1);
                        ids.Append(")");
                        where.Append(ids);
                    }
                    else
                    {
                        ids.Append(" AND BankID in (0) ");
                    }
                    break;
                case 10:
                    where.Append(" AND (IsSupervisorLook = '' or IsSupervisorLook is null) ");

                    string[] tempDealerIDs = this.DealerBll.GetDealerIDsBySupervisorID(this.CurrentUser.RelationID.Value);
                    if (tempDealerIDs != null && tempDealerIDs.Length > 0)
                    {
                        where.AppendFormat(" AND DealerID IN ({0}) ", string.Join(",", tempDealerIDs));
                    }
                    else
                    {
                        where.Append(" AND DealerID IN (0) ");
                    }
                    break;
            }

            if (this.ddl_Bank.SelectedValue != null && this.ddl_Bank.SelectedValue != "-1")
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
            //监管员
            if (this.CurrentUser.RoleId == 10)
            {
                dt = Dealer_BankBll.GetBankIDAndNameFilterRole(this.CurrentUser.RelationID.Value).Tables[0];
            }
            //银行
            else if (this.CurrentUser.RoleId == 8)
            {
                Citic.Model.UserMapping model = UMBLL.GetModelByCondition(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                if (model != null)
                {
                    dt = BankBll.GetList(string.Format(" BankID='{0}' ", model.MappingID.Value.ToString())).Tables[0];
                }
            }
            //5.市场专员，6.品牌专员
            else if (this.CurrentUser.RoleId == 5 || this.CurrentUser.RoleId == 6)
            {
                StringBuilder ids = new StringBuilder(string.Empty);
                DataTable _dt = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId)).Tables[0];
                if (_dt != null && _dt.Rows.Count > 0)
                {
                    ids.Append(" T.BankID in (");
                    foreach (DataRow row in _dt.Rows)
                    {
                        ids.AppendFormat("{0},", row["MappingID"].ToString());
                    }
                    ids.Remove(ids.Length - 1, 1);
                    ids.Append(")");
                    dt = BankBll.GetList(ids.ToString()).Tables[0];
                }
            }
            else
            {
                dt = BankBll.GetList("IsDelete=0").Tables[0];
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl_Bank.DataTextField = "BankName";
                ddl_Bank.DataValueField = "BankID";
                ddl_Bank.DataSource = dt;
                ddl_Bank.DataBind();
            }
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }
        #endregion

        #region 加载企业信息（经销商）--乔春羽
        private void DealerDataBind()
        {
            string val = ddl_Bank.SelectedValue;
            if (val != null && val != string.Empty)
            {
                string where = string.Empty;
                //监管员
                if (this.CurrentUser.RoleId == 10)
                {
                    where = string.Format(" DealerID in (select DealerID from tb_Dealer_List where SupervisorID='{0}')", this.CurrentUser.RelationID.Value);
                }
                else if (this.CurrentUser.RoleId == 8)  //银行
                {
                    Citic.Model.UserMapping model = UMBLL.GetModelByCondition(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                    Citic.Model.Bank bankModel = BankBll.GetModel(model.MappingID.Value);
                    if (bankModel != null)
                    {
                        string bankLevel = bankModel.ConnectID;
                        if (bankLevel == Common.Common.GuangDaString)
                        {
                            where = string.Format(" BankID = '{0}' AND ( GD_ID is null OR GD_ID = '' ) ", model.MappingID.Value);
                        }
                        else if (bankLevel == Common.Common.ZhongXinString)
                        {
                            where = string.Format(" BankID = '{0}' AND ( ZX_ID is null OR ZX_ID = '' ) ", model.MappingID.Value);
                        }
                    }
                }
                else
                {

                }
                DataTable dt = Dealer_BankBll.GetDealerByBankForDataTable(int.Parse(val), where);

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
                int type = 0;
                //二级过滤
                type = Convert.ToInt32(e.Values[5]);
                switch (type)
                {
                    case 1: //状态为“通过”
                        e.Values[5] = "通过";
                        //ControlTheButtonVisible(e.RowIndex, 1);
                        break;
                    case 2:
                        e.Values[5] = "处理中";
                        //ControlTheButtonVisible(e.RowIndex, 2);
                        break;
                    case 3:
                        e.Values[5] = "未通过";
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
            int num = 0;
            if (indexs != null && indexs.Length > 0)
            {
                List<Citic.Model.Car> cars = new List<Citic.Model.Car>();
                foreach (int index in indexs)
                {
                    //信息
                    string message = string.Format("操作ID:{0};操作人:{1};姓名:{4};操作时间:{2};操作结果:{3};角色:{5}", this.CurrentUser.UserId, this.CurrentUser.UserName, DateTime.Now, "通过", this.CurrentUser.TrueName, this.CurrentUser.Post);
                    //待办事项状态改为通过
                    int id = Convert.ToInt32(grid_List.DataKeys[index][0]);
                    Citic.Model.DBSX model = DBSXBll.GetModel(id);
                    model.OperateID = this.CurrentUser.UserId;
                    model.OperateTime = DateTime.Now;
                    model.IsBMLook = message;
                    model.IsSupervisorLook = string.Empty;
                    model.Status = 1;
                    bool flag = DBSXBll.Update(model);
                    if (flag)
                    {
                        num++;
                    }
                }
            }
            if (num == indexs.Length)
            {
                AlertShowInTop("操作成功！");
                GridBind();
            }
            else
            {
                AlertShowInTop("操作失败！");
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
                    //申请之前的状态，该状态需要更新到车辆中
                    int reqType = Convert.ToInt32(grid_List.DataKeys[index][4]);

                    //信息
                    string message = string.Format("操作ID:{0};操作人:{1};姓名:{4};操作时间:{2};操作结果:{3};角色:{5}", this.CurrentUser.UserId, this.CurrentUser.UserName, DateTime.Now, "通过", this.CurrentUser.TrueName, this.CurrentUser.Post);

                    //待办事项状态改为通过
                    int id = Convert.ToInt32(grid_List.DataKeys[index][0]);
                    Citic.Model.DBSX model = DBSXBll.GetModel(id);
                    model.OperateID = this.CurrentUser.UserId;
                    model.OperateTime = DateTime.Now;
                    model.IsBMLook = message;
                    model.IsSupervisorLook = string.Empty;
                    model.Status = 3;
                    bool flag = DBSXBll.Update(model);
                    if (flag)
                    {
                        //修改“车辆状态”
                        string tbName = string.Format("tb_Car_{0}_{1}", grid_List.DataKeys[index][2], grid_List.DataKeys[grid_List.SelectedRowIndex][3]);
                        string vin = grid_List.DataKeys[index][1].ToString();
                        cars.Add(new Citic.Model.Car() { TableName = tbName, Vin = vin, Statu = reqType, ReturnCost = "0.00" });
                    }
                }
                int num = CarBll.UpdateRange(cars.ToArray());
                if (num > 0)
                {
                    AlertShowInTop("操作成功！");
                    GridBind();
                }
                else
                {
                    AlertShowInTop("操作失败！");
                }
            }
        }
        #endregion

        #region "确定"申请操作，表示监管员“看过了”--乔春羽(2013.12.30)
        protected void btn_Sures_Click(object sender, EventArgs e)
        {
            int[] indexs = grid_List.SelectedRowIndexArray;
            DataTable dt = null;
            if (indexs != null && indexs.Length > 0)
            {
                foreach (int index in indexs)
                {
                    int bankID = Convert.ToInt32(this.grid_List.DataKeys[index][2]);
                    int dealerID = Convert.ToInt32(this.grid_List.DataKeys[index][3]);
                    int status = Convert.ToInt32(this.grid_List.Rows[index].DataKeys[5]);
                    dt = this.Dealer_BankBll.GetList(1, string.Format(" BankID = '{0}' and DealerID = '{1}' ", bankID, dealerID), "ID").Tables[0];
                    if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0]["GD_ID"].ToString()) && dt.Rows[0]["GD_ID"].ToString() != "-1")
                    {
                        continue;
                    }
                    //上级是否同意！
                    string IsBMLook = this.grid_List.Rows[index].DataKeys[7] == null ? string.Empty : this.grid_List.Rows[index].DataKeys[7].ToString();
                    if (string.IsNullOrEmpty(IsBMLook))
                    {
                        AlertShowInTop("银行尚未审批，不能操作！");
                        return;
                    }
                    if (status == 2)
                    {
                        AlertShowInTop("状态为 “处理中” 的数据不可再次操作！");
                        return;
                    }
                }

                List<Citic.Model.DBSX> dbsxList = new List<Citic.Model.DBSX>();
                List<string> draftNoList = new List<string>();
                StringBuilder q408 = new StringBuilder("<CHANNEL_CODE>0231J001</CHANNEL_CODE>");
                int q408Count = q408.Length;
                StringBuilder execSql = new StringBuilder();
                foreach (int index in indexs)
                {
                    string tbName = string.Empty;
                    int bankID = Convert.ToInt32(this.grid_List.DataKeys[index][2]);
                    int dealerID = Convert.ToInt32(this.grid_List.DataKeys[index][3]);
                    tbName = string.Format("tb_Car_{0}_{1}", bankID, dealerID);
                    int status = Convert.ToInt32(this.grid_List.Rows[index].DataKeys[5]);

                    //具体内容
                    string content = grid_List.DataKeys[index][6].ToString();
                    //dt = this.Dealer_BankBll.GetList(string.Format(" A.BankID = '{0}' and DealerID = '{1}' ", bankID, dealerID)).Tables[0];
                    dt = this.Dealer_BankBll.GetList(1, string.Format(" BankID = '{0}' and DealerID = '{1}' ", bankID, dealerID), "ID").Tables[0];

                    //信息
                    string message = string.Format("操作ID:{0};操作人:{1};姓名:{4};操作时间:{2};操作结果:{3};角色:{5}", this.CurrentUser.UserId, this.CurrentUser.UserName, DateTime.Now, "该监管员已经看过该信息", this.CurrentUser.TrueName, this.CurrentUser.Post);
                    //待办事项状态改为监管员看过了的类型
                    int id = Convert.ToInt32(grid_List.DataKeys[index][0]);
                    Citic.Model.DBSX model = DBSXBll.GetModel(id);
                    model.OperateID = this.CurrentUser.UserId;
                    model.OperateTime = DateTime.Now;
                    model.IsSupervisorLook = message;
                    if (!draftNoList.Contains(model.DraftNo))
                    {
                        draftNoList.Add(model.DraftNo);
                    }

                    #region 待办事项，通过审核
                    //车架号
                    string vin = grid_List.DataKeys[index][1].ToString();
                    //回款金额!!!!
                    string returnCost = content.Substring(content.LastIndexOf(":") + 1);

                    //如果数据中存在“与光大接口对接了得经销商与光大银行”的待办事项
                    //直接将该待办事项的状态改掉，改为1
                    //并且，要向toGDMessage表中插入一条信息。
                    if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0]["GD_ID"].ToString()) && dt.Rows[0]["GD_ID"].ToString() != "-1")
                    {
                        model.Status = 1;
                        string GD_ID = string.Empty;
                        try
                        {

                            //DataSet ds = this.CarBll.GetValueByColumns(tbName, vin, "GD_ID");
                            DataTable dtPI_ID = this.Dealer_BankBll.Query(string.Format("select PI_ID from GD_DispatchCarInfo where DJ_NO = '{0}'", vin));
                            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                            if (dtPI_ID != null && dtPI_ID.Rows.Count > 0)
                            {
                                //GD_ID = ds.Tables[0].Rows[0]["GD_ID"].ToString();
                                GD_ID = dtPI_ID.Rows[0]["PI_ID"].ToString();
                            }

                        }
                        catch
                        {
                            GD_ID = string.Empty;
                        }
                        q408.Append(string.Format("<Frame><PI_ID>{0}</PI_ID><PI_STATUS>1</PI_STATUS><CAR_STATUS>1</CAR_STATUS></Frame>", GD_ID));

                        model.CarModel = new Citic.Model.Car() { TableName = tbName, Vin = vin, Statu = 0, OutTime = DateTime.Now, ReturnCost = returnCost };
                        model.Type = "out";
                    }
                    else
                    {                 //取要移到的二网的ID
                        string newStorageID = this.grid_List.DataKeys[index][8] == null ? string.Empty : this.grid_List.DataKeys[index][8].ToString();
                        //待办事项，通过审核
                        if (status == 1)
                        {
                            //修改质押物信息
                            //申请事项
                            string type = content.Substring(0, 2);

                            if (type == "出库")
                            {
                                model.CarModel = new Citic.Model.Car() { TableName = tbName, Vin = vin, Statu = 0, OutTime = DateTime.Now, ReturnCost = returnCost };
                                model.Type = "out";
                            }
                            else if (type == "移库")
                            {
                                string toStorage = content.Split(',')[1].Split(':')[1];
                                if (toStorage == "本库")
                                {
                                    model.CarModel = new Citic.Model.Car() { TableName = tbName, Vin = vin, Statu = 1, MoveTime = DateTime.Now, StorageID = int.Parse(newStorageID), StorageName = toStorage, ReturnCost = returnCost };
                                }
                                else
                                {
                                    model.CarModel = new Citic.Model.Car() { TableName = tbName, Vin = vin, Statu = 2, MoveTime = DateTime.Now, StorageID = int.Parse(newStorageID), StorageName = toStorage, ReturnCost = returnCost };
                                }
                                model.Type = "move";
                            }
                        }
                        else if (status == 3)   //未通过
                        {
                            int reqType = int.Parse(grid_List.DataKeys[index][4].ToString());
                            model.CarModel = new Citic.Model.Car() { TableName = tbName, Vin = vin, Statu = reqType };
                            model.Type = "ReturnBack";
                        }
                    }
                    #endregion

                    dbsxList.Add(model);
                }
                string toGDMessage = string.Empty;
                if (q408.Length > q408Count)
                {
                    toGDMessage = string.Format(@"Insert into [tb_ToGDMessage] (FTranCode,TrmSeqNum,RequestSource,RequestPe_ID,Status,RequestDate,insertValue) Values ('Q408',CONVERT(VARCHAR(4),DATEPART(YEAR,GETDATE()))+''+CONVERT(NVARCHAR(2),DATEPART(MONTH,GETDATE()))+''+CONVERT(NVARCHAR(2),DATEPART(DAY,GETDATE()))+CONVERT(VARCHAR(4),DATEPART(HOUR,GETDATE()))+''+CONVERT(VARCHAR(4),DATEPART(MINUTE,GETDATE()))+''+CONVERT(VARCHAR(4),DATEPART(SECOND,GETDATE()))+''+CONVERT(VARCHAR(8),DATEPART(MS,GETDATE())),'{0}','{1}','0',GETDATE(),'')", q408.ToString(), this.CurrentUser.UserId);
                }

                try
                {
                    int num = DBSXBll.UpdateRange(toGDMessage, dbsxList.ToArray());
                    if (num > 0)
                    {
                        AlertShowInTop("操作成功！");
                        int draftResult = DraftBll.UpdateDraftMoney(draftNoList.ToArray());
                        if (draftResult == -1)
                        {
                            Exception ex = new Exception("更新汇票的已押、未押、敞口金额出问题");
                            Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "待办事项，更新汇票的金额，DraftBll.UpdateDraftMoney(draftNoList.ToArray());");
                        }
                        GridBind();
                    }
                    else
                    {
                        AlertShowInTop("操作失败！");
                    }
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "btn_Sures_Click()");
                }
            }
        }
        #endregion
    }
}
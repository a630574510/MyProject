using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Citic_Web.DealerManagement.DealerInfo
{
    public partial class EditDealer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //清空ViewState
                ViewState.Clear();
                WUC_Address.Init();
                string dealerIDStr = Request.QueryString["DealerID"];
                if (dealerIDStr != null && dealerIDStr != string.Empty)
                {
                    Session["DealerID"] = dealerIDStr;
                }
                //打开修改银行界面
                btn_ModifyBank.OnClientClick = grid_BankList.GetNoSelectionAlertInParentReference("请选择一条数据！");

                //显示经销商的详细信息
                DealerDataBind();

                //加载内存中的数据
                LoadDataInViewState();
            }
        }

        #region PrivateFields--乔春羽
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int DealerID
        {
            get
            {
                return Convert.ToInt32(Session["DealerID"]);
            }
        }
        private string OrganizationCode
        {
            get
            {
                string value = string.Empty;
                if (!string.IsNullOrEmpty(this.txt_OrganizationCode.Text.Trim()))
                {
                    value = this.txt_OrganizationCode.Text.Trim();

                    if (value.Length == 10 && value.IndexOf('-') > 0 && value.IndexOf('-') == 8 && value.LastIndexOf('-') == 8)
                    {
                        value = this.txt_OrganizationCode.Text.Trim();
                    }
                    else if (value.Length == 9 && value.IndexOf('-') <= 0)
                    {
                        value = string.Format("{0}-{1}", value.Substring(0, 8), value.Substring(8, 1));
                    }
                    else { value = string.Empty; }
                }
                return value;
            }
        }
        #endregion

        #region 显示经销商的详细信息--乔春羽
        /// <summary>
        /// 显示经销商的详细信息
        /// </summary>
        private void DealerDataBind()
        {
            Citic.Model.Dealer model = null;
            Citic.Model.Dealer sessionModel = Session["model"] as Citic.Model.Dealer;
            try
            {
                model = DealerBll.GetModel(DealerID);
            }
            catch (Exception e) { Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "DealerDataBind()"); }
            if (model != null)
            {
                this.txt_DealerName.Text = model.DealerName;

                //显示简称
                if (sessionModel == null)
                {
                    DataTable dt = this.Dealer_BankBll.GetList(1, string.Format(" DealerID = '{0}' ", model.DealerID), "DealerName").Tables[0];
                    if (dt != null && dt.Rows.Count > 0) { model.JC = dt.Rows[0]["JC"].ToString(); }
                    Session.Add("model", model);
                }
                else
                {
                    model.JC = sessionModel.JC;
                    model.Address = sessionModel.Address;
                    model.DealerPayCode = sessionModel.DealerPayCode;
                    model.DealerName = sessionModel.DealerName;
                    model.DealerType = sessionModel.DealerType;
                    model.IsGroup = sessionModel.IsGroup;
                    model.HasOtherIndustries = sessionModel.HasOtherIndustries;
                    model.GotoworkTime = sessionModel.GotoworkTime;
                    model.GoffworkTime = sessionModel.GoffworkTime;
                    model.ConnectID = sessionModel.ConnectID;
                    model.Address = sessionModel.Address;
                    model.Remarks = sessionModel.Remarks;
                    Session.Add("model", model);
                }

                this.txt_OrganizationCode.Text = model.DealerPayCode;

                this.cbl_DealerType.SelectedValueArray = model.DealerType.Split(',');
                this.chk_IsGroup.Checked = model.IsGroup;
                this.txt_OtherIndustries.Text = model.HasOtherIndustries;
                this.txt_YWZ.Text = model.ConnectID;

                this.ddl_GotoworkTime.SelectedValue = model.GotoworkTime;
                this.ddl_GoffworkTime.SelectedValue = model.GoffworkTime;

                //显示地址信息
                if (model.Address != null && model.Address != string.Empty)
                {
                    string[] adds = model.Address.Split('-');
                    if (adds.Length >= 3)
                    {
                        WUC_Address.Province = adds[0];
                        WUC_Address.City = adds[1];
                        WUC_Address.Address = adds[2];
                    }
                    else
                    {
                        WUC_Address.Address = model.Address;
                    }
                }

                this.txt_Remark.Text = model.Remarks;

                //显示联系人信息
                DealerLinkmanDataBind(model.DealerID);
                DealerBankLinkmanDataBind(model.DealerID);

                //显示合作行信息
                DealerBankDataBind();
            }
        }

        /// <summary>
        /// 显示经销商联系人--乔春羽
        /// </summary>
        /// <param name="dealerID"></param>
        private void DealerLinkmanDataBind(int dealerID)
        {
            DataTable dt = LinkmanBll.GetList(string.Format(" RelationID={0} and LinkType={1} and IsDelete=0", dealerID, Convert.ToInt32(Citic_Web.Common.LinkType.DealerLinkman))).Tables[0];
            if (dt != null)
            {
                grid_List1.DataSource = dt;
                grid_List1.DataBind();
            }
        }
        /// <summary>
        /// 显示与经销商关联的银行负责人--乔春羽
        /// </summary>
        /// <param name="dealerID"></param>
        private void DealerBankLinkmanDataBind(int dealerID)
        {
            DataTable dt = LinkmanBll.GetList(string.Format(" RelationID={0} and LinkType={1} and IsDelete=0", dealerID, Convert.ToInt32(Citic_Web.Common.LinkType.DealerBankLinkman))).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                grid_List2.DataSource = dt;
                grid_List2.DataBind();
            }
        }

        /// <summary>
        /// 显示与经销商合作的合作行信息--乔春羽
        /// </summary>
        private void DealerBankDataBind()
        {
            DataTable dt = Dealer_BankBll.GetList(string.Format(" A.DealerID={0} AND A.CollaborateType=1", DealerID)).Tables[0];
            if (dt != null)
            {
                grid_BankList.DataSource = dt;
                grid_BankList.DataBind();
            }
        }
        #endregion

        #region 根据品牌的ID，获取该品牌对应的厂商的ID--乔春羽
        private string GetFactoryIDByBrandID(int brandID)
        {
            string idstr = string.Empty;
            try
            {
                Citic.Model.Brand model = BrandBll.GetModel(brandID);
                idstr = model.FactoryID.ToString();
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "GetFactoryIDByBrandID()");
            }
            return idstr;
        }
        #endregion

        #region 行命令事件（联系人）--乔春羽
        protected void grid_List_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            FineUI.Grid grid = sender as FineUI.Grid;
            if (grid != null)
            {
                if (e.CommandName != null && e.CommandName != string.Empty)
                {
                    if (e.CommandName == "delete")
                    {
                        int lkid = Convert.ToInt32(grid.DataKeys[e.RowIndex][0]);

                        try
                        {
                            bool flag = LinkmanBll.DeleteOnLogic(new Citic.Model.Linkman() { LinkmanID = lkid, DeleteID = this.CurrentUser.UserId, DeleteTime = DateTime.Now });
                            if (flag)
                            {
                                AlertShowInTop("删除成功！");
                                if (grid.ID == "grid_List1")
                                {
                                    DealerLinkmanDataBind(DealerID);
                                }
                                else if (grid.ID == "grid_List2")
                                {
                                    DealerBankLinkmanDataBind(DealerID);
                                }
                            }
                            else
                            {
                                AlertShowInTop("删除失败！");
                            }
                        }
                        catch (Exception ex) { Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "grid_List_RowCommand()"); }
                    }
                }
            }
        }
        #endregion

        #region 选择银行时，保存页面数据--乔春羽
        protected void btn_ChoiseBank_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_DealerName.Text.Trim()))
            {
                AlertShowInTop("请填写经销商的名字!");
                return;
            }
            if (string.IsNullOrEmpty(this.OrganizationCode))
            {
                AlertShowInTop("请填写正确的组织机构代码!");
                return;
            }
            SaveDataInViewState();

            WindowShowBank.IFrameUrl = "~/DealerManagement/DealerInfo/ChoiseBank.aspx?DealerID=" + this.DealerID + "&isAdd=0";
            WindowShowBank.Hidden = false;
        }
        private void SaveDataInViewState()
        {
            Citic.Model.Dealer model = null;
            if (Session["model"] != null)
            {
                model = Session["model"] as Citic.Model.Dealer;
            }
            else
            {
                model = new Citic.Model.Dealer();
            }
            //经销商名
            model.DealerName = this.txt_DealerName.Text;
            model.JC = this.txt_JC.Text;
            //组织机构代码
            model.DealerPayCode = this.OrganizationCode;
            //地址
            model.Address = GetAddress();
            //备注
            model.Remarks = this.txt_Remark.Text;
            //经销商属性
            model.DealerType = string.Join(",", cbl_DealerType.SelectedValueArray);
            //是否是集团属性
            model.IsGroup = this.chk_IsGroup.Checked;
            //其他产业
            model.HasOtherIndustries = this.txt_OtherIndustries.Text;
            //上下班时间
            model.GotoworkTime = this.ddl_GotoworkTime.Text;
            model.GoffworkTime = this.ddl_GoffworkTime.Text;
            //经销商业务章
            model.ConnectID = this.txt_YWZ.Text;

            Session["model"] = model;
        }
        #endregion

        #region 加载内存中的数据--乔春羽
        private void LoadDataInViewState()
        {
            if (Session["model"] != null)
            {
                Citic.Model.Dealer model = Session["model"] as Citic.Model.Dealer;
                //经销商名
                this.txt_DealerName.Text = model.DealerName;
                this.txt_JC.Text = model.JC;
                //组织机构代码
                this.txt_OrganizationCode.Text = model.DealerPayCode;
                //地址
                if (model.Address != null && model.Address != string.Empty)
                {
                    string[] adds = model.Address.Split('-');
                    if (adds.Length >= 3)
                    {
                        WUC_Address.Province = adds[0];
                        WUC_Address.City = adds[1];
                        WUC_Address.Address = adds[2];
                    }
                    else
                    {
                        WUC_Address.Address = model.Address;
                    }
                }
                //备注
                this.txt_Remark.Text = model.Remarks;
                //经销商属性
                this.cbl_DealerType.SelectedValueArray = model.DealerType.Split(',');
                //是否是集团性质
                this.chk_IsGroup.Checked = model.IsGroup;
                //其他产业
                this.txt_OtherIndustries.Text = model.HasOtherIndustries;
                //上下班时间
                this.ddl_GotoworkTime.SelectedValue = model.GotoworkTime;
                this.ddl_GoffworkTime.SelectedValue = model.GoffworkTime;
            }
        }
        #endregion

        #region 行数据绑定事件（合作行）--乔春羽
        protected void grid_BankList_RowDataBound(object sender, GridRowEventArgs e)
        {
            int index = 0;
            if (e.DataItem != null)
            {
                index = 2;
                //业务模式
                int businessMode = Convert.ToInt32(e.Values[index]);
                switch (businessMode)
                {
                    case 1:
                        e.Values[index] = "车证模式";
                        break;
                    case 2:
                        e.Values[index] = "合格证模式";
                        break;
                    case 3:
                        e.Values[index] = "巡库模式";
                        break;
                    default:
                        e.Values[index] = "无效";
                        break;
                }

                //支付周期
                index = 5;
                int paymentCycle = Convert.ToInt32(e.Values[index]);
                switch (paymentCycle)
                {
                    case 1:
                        e.Values[index] = "月";
                        break;
                    case 2:
                        e.Values[index] = "季";
                        break;
                    case 3:
                        e.Values[index] = "半年";
                        break;
                    case 4:
                        e.Values[index] = "年";
                        break;
                    default:
                        e.Values[index] = "无效";
                        break;
                }

                //是否合作
                index = 7;
                int coll = Convert.ToInt32(e.Values[index]);
                switch (coll)
                {
                    case 1:
                        e.Values[index] = "正常合作";
                        break;
                }
            }
        }
        #endregion

        #region 行命令事件（合作行）--乔春羽
        protected void grid_BankList_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName != null && e.CommandName != string.Empty)
            {
                //停止合作
                if (e.CommandName.Equals("stop"))
                {
                    int id = Convert.ToInt32(grid_BankList.DataKeys[e.RowIndex][0]);
                    string dealerID = grid_BankList.DataKeys[e.RowIndex][2].ToString();
                    string bankID = grid_BankList.DataKeys[e.RowIndex][1].ToString();
                    string carTbName = string.Format("tb_Car_{0}_{1}", bankID, dealerID);
                    try
                    {
                        //当前店的已清票的汇票的数量
                        int clearcount = DraftBll.GetRecordCount(string.Format(" BankID = '{0}' and DealerID = '{1}' and DraftType = 0 ", bankID, dealerID));
                        //当前店汇票的总数量
                        int alldraftcount = DraftBll.GetRecordCount(string.Format(" BankID = '{0}' and DealerID = '{1}' ", bankID, dealerID));
                        if (clearcount != alldraftcount)
                        {
                            AlertShowInTop("当前店尚有未清票的汇票，不能停止合作！");
                            return;
                        }

                        int num = Dealer_BankBll.ModifyCollaborateType(new Citic.Model.Dealer_Bank() { ID = id, CollaborateType = 0, StopTime = DateTime.Now });
                        if (num > 0)
                        {
                            AlertShowInTop("已停止合作！");
                            DealerBankDataBind();
                        }
                        else
                        {
                            AlertShowInTop("停止合作失败！");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "grid_BankList_RowCommand()");
                    }
                }
            }
        }
        #endregion

        #region 添加联系人--乔春羽
        /// <summary>
        /// 添加联系人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add(object sender, EventArgs e)
        {
            FineUI.Button btn = sender as FineUI.Button;
            if (btn != null)
            {
                Citic.Model.Linkman model = new Citic.Model.Linkman();
                model.IsDelete = false;
                model.IsPort = false;
                model.CreateID = this.CurrentUser.UserId;
                model.CreateTime = DateTime.Now;
                model.ConnectID = string.Empty;
                model.RelationID = DealerID;

                if (btn.ID == "btn_AddLinkman1")
                {
                    model.LinkmanName = txt_LinkmanName1.Text;
                    model.Phone = num_Phone1.Text;
                    model.Fax = this.txt_Fax1.Text;
                    model.Email = this.txt_Email1.Text;
                    model.LinkType = Convert.ToInt32(Citic_Web.Common.LinkType.DealerLinkman);
                }
                else if (btn.ID == "btn_AddLinkman2")
                {
                    model.LinkmanName = txt_LinkmanName2.Text;
                    model.Phone = num_Phone2.Text;
                    model.Fax = this.txt_Fax2.Text;
                    model.Email = this.txt_Email2.Text;
                    model.LinkType = Convert.ToInt32(Citic_Web.Common.LinkType.DealerBankLinkman);
                }
                int lkid = 0;
                try
                {
                    lkid = LinkmanBll.Add(model);
                    if (lkid > 0)
                    {
                        if (btn.ID == "btn_AddLinkman1")
                        {
                            DealerLinkmanDataBind(DealerID);
                        }
                        else if (btn.ID == "btn_AddLinkman2")
                        {
                            DealerBankLinkmanDataBind(DealerID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "btn_Add()");
                }
            }
        }

        #endregion

        #region 保存经销商--乔春羽
        protected void btn_SaveDeader_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_DealerName.Text.Trim()))
            {
                AlertShowInTop("请填写经销商的名字!");
                return;
            }
            if (string.IsNullOrEmpty(this.OrganizationCode))
            {
                AlertShowInTop("请填写正确的组织机构代码!");
                return;
            }
            SaveDealer();
        }

        /// <summary>
        /// 保存经销商--乔春羽
        /// </summary>
        private void SaveDealer()
        {
            Citic.Model.Supervisor_History sh = new Citic.Model.Supervisor_History();
            //判断是否修改过监管员，如果修改过则需要记录。
            bool isChangeSupervisor = false;
            Citic.Model.Dealer model = Session["model"] as Citic.Model.Dealer;
            if (model != null)
            {
                sh = Super_HistoryBll.GetModelByMaxID(" DealerID=" + model.DealerID + " and SupervisorID=" + model.SupervisorID + "");
                model.Address = GetAddress();
                model.DealerName = this.txt_DealerName.Text;
                model.DealerType = string.Join(",", cbl_DealerType.SelectedValueArray);
                model.IsGroup = chk_IsGroup.Checked;
                model.HasOtherIndustries = this.txt_OtherIndustries.Text;
                model.GotoworkTime = ddl_GotoworkTime.SelectedText;
                model.GoffworkTime = ddl_GoffworkTime.SelectedText;
                model.IsDelete = false;
                model.IsPort = false;
                model.DealerPayCode = this.OrganizationCode;
                model.Remarks = this.txt_Remark.Text;
                model.ConnectID = this.txt_YWZ.Text;
                model.UpdateID = this.CurrentUser.UserId;
                model.UpdateTime = DateTime.Now;
                model.JC = this.txt_JC.Text;
                model.DeleteID = 0;

                try
                {
                    bool flag = DealerBll.Update(model);
                    if (flag)
                    {
                        if (isChangeSupervisor && sh != null)
                        {
                            sh.Time_End = DateTime.Now;
                            flag = Super_HistoryBll.Update(sh);
                            if (flag)
                            {
                                Citic.Model.Supervisor_History newSh = new Citic.Model.Supervisor_History();
                                newSh.DealerID = model.DealerID;
                                newSh.DealerName = model.DealerName;
                                newSh.SupervisorID = model.SupervisorID.Value;
                                newSh.SupervisorName = model.SupervisorName;
                                newSh.Time_Start = DateTime.Now;
                                Super_HistoryBll.Add(newSh);
                            }
                        }
                        AlertShowInTop("修改成功！");
                    }
                    else
                    {
                        AlertShowInTop("修改失败！");
                    }
                }
                catch (Exception e)
                {
                    AlertShowInTop("服务器正忙，请联系管理员！");
                    Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "SaveDealer()");
                }
            }
        }


        /// <summary>
        /// 获取地址--乔春羽
        /// </summary>
        /// <returns></returns>
        private string GetAddress()
        {
            return WUC_Address.Value;
        }

        #endregion

        #region 关闭本页面，并刷新父页面--乔春羽
        protected void btn_Close_Click(object sender, EventArgs e)
        {
            //清空Session中的存值
            Session.Remove("BankIDs");
            Session.Remove("BankNames");
            Session.Remove("DealerID");
            Session.Remove("model");
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
        }
        #endregion

        #region 修改所选择的合作行信息--乔春羽(2014.3.14)
        protected void btn_ModifyBank_Click(object sender, EventArgs e)
        {
            string bankID = this.grid_BankList.Rows[this.grid_BankList.SelectedRowIndex].DataKeys[1].ToString();
            string url = string.Format("~/DealerManagement/DealerInfo/ChoiseBank.aspx?_bankid={0}&DealerID={1}&isAdd=0", bankID, DealerID);
            SaveDataInViewState();
            WindowShowBank.IFrameUrl = url;
            WindowShowBank.Hidden = false;
        }
        #endregion
    }
}
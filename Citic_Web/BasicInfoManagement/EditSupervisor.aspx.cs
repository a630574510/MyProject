using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;
using Newtonsoft.Json;
using Newtonsoft;
using Citic.BLL;

namespace Citic_Web.BasicInfoManagement
{
    public partial class EditSupervisor : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //乔春羽
                int supervisorID = 0;
                string superIDStr = Request.QueryString["SupervisorID"];
                if (superIDStr != null && superIDStr != string.Empty)
                {
                    supervisorID = int.Parse(superIDStr);
                    DataBind(supervisorID);
                }
                //乔春羽
            }
        }

        private Citic.Model.Supervisor Model
        {
            get { return ViewState["Model"] as Citic.Model.Supervisor; }
            set { ViewState["Model"] = value; }
        }

        private void DataBind(int superID)
        {
            Model = SupervisorBll.GetSupervisorWithCode(superID);
            this.hidden_SupervisorID.Text = Model.SupervisorID.ToString();
            this.txt_IDCard.Text = Model.IDCard;
            this.num_LinkPhone.Text = Model.LinkPhone;
            this.txt_Name.Text = Model.SupervisorName;
            this.num_QQ.Text = Model.QQ;
            this.txt_UrgencyConnect.Text = Model.UrgencyConnect;
            this.txt_UrgencyMan.Text = Model.UrgencyMan;
            this.num_UrgencyPhone.Text = Model.UrgencyPhone;
            this.rbl_Gender.SelectedValue = Model.Gender.ToString();
            this.rbl_WorkSoruce.SelectedValue = Model.WorkSource.ToString();
            this.rbl_WorkType.SelectedValue = Model.WorkType.ToString();
            this.ddl_Education.SelectedValue = Model.Education;
            this.dp_EntryTime.SelectedDate = Model.EntryTime;
            this.num_Age.Text = Model.Age.ToString();

            this.txt_Pass.Text = this.txt_PassA.Text = Model.Password;
        }

        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            SaveSupervisor();
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        /// <summary>
        /// 修改监管员--乔春羽
        /// </summary>
        private void SaveSupervisor()
        {
            Model.Age = Convert.ToInt32(num_Age.Text);
            Model.UpdateID = this.CurrentUser.UserId;
            Model.UpdateTime = DateTime.Now;
            Model.Education = this.ddl_Education.SelectedValue;
            Model.EntryTime = this.dp_EntryTime.SelectedDate;
            Model.Gender = int.Parse(this.rbl_Gender.SelectedValue);
            Model.IDCard = this.txt_IDCard.Text;
            Model.IsDelete = false;
            Model.IsPort = false;
            Model.LinkPhone = this.num_LinkPhone.Text;
            Model.QQ = this.num_QQ.Text;
            Model.SupervisorName = this.txt_Name.Text;
            Model.UrgencyConnect = this.txt_UrgencyConnect.Text;
            Model.UrgencyMan = this.txt_UrgencyMan.Text;
            Model.UrgencyPhone = this.num_UrgencyPhone.Text;
            Model.WorkSource = int.Parse(this.rbl_WorkSoruce.SelectedValue);
            Model.WorkType = int.Parse(this.rbl_WorkType.SelectedValue);
            Model.SupervisorID = int.Parse(hidden_SupervisorID.Text);

            Model.Password = this.txt_Pass.Text;
            try
            {
                bool flag = SupervisorBll.ModifySupervisor(Model) > 0;
                if (flag)
                {
                    AlertShowInTop("修改成功！");
                }
                else
                {
                    AlertShowInTop("修改失败！");
                }
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "SaveSupervisor()");
            }
        }
    }
}
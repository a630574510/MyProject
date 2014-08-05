using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Citic.BLL;

namespace Citic_Web.BasicInfoManagement
{
    public partial class AddSupervisor : BasePage
    {
        //PrivateField--乔春羽

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        /// <summary>
        /// 保存并关闭--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            if (CheckNameIsExists(this.txt_Name.Text))
            {
                AlertShowInTop("监管员姓名已存在！\r\n为了监管员对应的账号的唯一性，请另行修改监管员的姓名。");
            }
            else
            {
                SaveSupervisor();
                // 2. 关闭本窗体，然后刷新父窗体
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
        }

        /// <summary>
        /// 检测监管员的名字是否存在--乔春羽(2013.11.27)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckNameIsExists(string name)
        {
            bool flag = false;
            flag = SupervisorBll.CheckNameIsExists(name);
            return flag;
        }

        /// <summary>
        /// 添加新的监管员--乔春羽
        /// </summary>
        private void SaveSupervisor()
        {
            Citic.Model.Supervisor model = new Citic.Model.Supervisor();
            model.Age = Convert.ToInt32(num_Age.Text);
            model.CreateID = this.CurrentUser.UserId;
            model.CreateTime = DateTime.Now;
            model.Education = this.ddl_Education.SelectedValue;
            model.EntryTime = this.dp_EntryTime.SelectedDate;
            model.Gender = int.Parse(this.rbl_Gender.SelectedValue);
            model.IDCard = this.txt_IDCard.Text;
            model.IsDelete = false;
            model.IsPort = false;
            model.LinkPhone = this.num_LinkPhone.Text;
            model.QQ = this.num_QQ.Text;
            model.SupervisorName = this.txt_Name.Text.Trim();
            model.UrgencyConnect = this.txt_UrgencyConnect.Text;
            model.UrgencyMan = this.txt_UrgencyMan.Text;
            model.UrgencyPhone = this.num_UrgencyPhone.Text;
            model.WorkSource = int.Parse(this.rbl_WorkSoruce.SelectedValue);
            model.WorkType = int.Parse(this.rbl_WorkType.SelectedValue);

            model.Password = this.txt_Pass.Text.Trim();
            try
            {
                int num = SupervisorBll.CreateSupervisor(model);
                if (num > 0)
                {
                    AlertShowInTop("添加成功！");
                }
                else
                {
                    AlertShowInTop("添加失败！");
                }
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "SaveSupervisor()");
            }
        }

        #region 输入身份证号之后，自动计算出年龄与性别--乔春羽(2014.3.21)
        protected void txt_IDCard_TextChanged(object sender, EventArgs e)
        {
            string idCard = this.txt_IDCard.Text;
            if (!string.IsNullOrEmpty(idCard) && (idCard.Length == 15 || idCard.Length == 18))
            {
                //年龄计算
                int year = int.Parse(idCard.Substring(6, 4));
                int result = DateTime.Now.Year - year;
                this.num_Age.Text = result.ToString();
                //性别计算
                string sexFlag = idCard.Substring(idCard.Length - 2, 1);
                if (int.Parse(sexFlag) / 2 == 0)
                {
                    this.rbl_Gender.SelectedValue = "0";
                }
                else
                {
                    this.rbl_Gender.SelectedValue = "1";
                }
            }
        }
        #endregion
    }
}
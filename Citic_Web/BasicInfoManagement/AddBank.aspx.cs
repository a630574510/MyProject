using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FineUI;

namespace Citic_Web.BasicInfoManagement
{
    public partial class AddBank : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_ParentBank.Enabled = false;
                WUC_Address.Init();
            }
        }

        /// <summary>
        /// 单选按钮选择事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rbl_BankType_onSelectedIndexChanged(object sender, EventArgs e)
        {
            FineUI.RadioButtonList rbls = sender as FineUI.RadioButtonList;
            ddl_ParentBank.Items.Clear();
            if (rbls != null)
            {
                int val = Convert.ToInt32(rbls.SelectedValue);
                switch (val)
                {
                    //CompareType="String" CompareValue="0" CompareOperator="NotEqual" CompareMessage="请选择上级银行！"
                    //表示分行，要求显示出总行列表
                    case 1:
                        DropDownListDataBind(ddl_ParentBank, " BankType=0");
                        break;
                    //表示支行，要求显示出分行列表
                    case 2:
                        DropDownListDataBind(ddl_ParentBank, "BankType=1");
                        break;
                    //表示总行
                    default:
                        ddl_ParentBank.Items.Clear();
                        ddl_ParentBank.Items.Add("请选择", "0");
                        ddl_ParentBank.Required = false;
                        ddl_ParentBank.RequiredMessage = "";
                        ddl_ParentBank.Enabled = false;
                        break;
                }
            }
        }

        /// <summary>
        /// 绑定下拉框数据--乔春羽
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="where"></param>
        private void DropDownListDataBind(FineUI.DropDownList ddl, string where)
        {
            ddl.Enabled = true;

            ddl.Items.Clear();
            ddl.DataSource = null;
            DataTable dt = BankBll.GetList(where).Tables[0];
            ddl.DataTextField = "BankName";
            ddl.DataValueField = "BankID";
            ddl.DataSource = dt;
            ddl.DataBind();
        }


        /// <summary>
        /// 保存并关闭--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            Save();
        }

        /// <summary>
        /// 获取地址--乔春羽
        /// </summary>
        /// <returns></returns>
        private string GetAddress()
        {
            return WUC_Address.Value;
        }
        /// <summary>
        /// 保存银行信息--乔春羽
        /// </summary>
        private void Save()
        {
            DataTable dt = this.BankBll.GetList(string.Format("BankName = '{0}'", this.txt_Name.Text)).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                AlertShowInTop("该合作行已存在！");
                return;
            }
            int bankID = 0;
            try
            {
                Citic.Model.Bank model = new Citic.Model.Bank();
                model.CreateID = this.CurrentUser.UserId;
                model.CreateTime = DateTime.Now;
                model.Address = GetAddress();
                model.BankName = this.txt_Name.Text;
                model.BankType = int.Parse(this.rbl_BankType.SelectedValue);
                model.IsDelete = false;
                model.IsPort = false;
                model.ParentID = int.Parse(ddl_ParentBank.SelectedValue);
                bankID = BankBll.Add(model);
                int LinkmanID = 0;
                if (bankID > 0)
                {
                    if (ValidateLinkman())
                    {
                        Citic.Model.Linkman lkmodel = new Citic.Model.Linkman();
                        lkmodel.CreateID = this.CurrentUser.UserId;
                        lkmodel.CreateTime = DateTime.Now;
                        lkmodel.Email = this.txt_Email.Text;
                        lkmodel.IsDelete = false;
                        lkmodel.IsPort = false;
                        lkmodel.LinkmanName = this.txt_LinkmanName.Text;
                        lkmodel.LinkType = Convert.ToInt32(Common.LinkType.BankLinkman);   //表示是银行联系人
                        lkmodel.Phone = this.num_Phone.Text;
                        lkmodel.Post = this.txt_Post.Text;
                        lkmodel.RelationID = bankID;
                        LinkmanID = LinkmanBll.Add(lkmodel);
                    }
                }
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "Save()");
            }
            if (bankID > 0)
            {
                AlertShowInTop("添加成功！");
            }
            else
            {
                AlertShowInTop("添加失败！");
            }

            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        /// <summary>
        /// 验证联系人信息是否填写
        /// </summary>
        /// <returns></returns>
        private bool ValidateLinkman()
        {
            if (this.txt_LinkmanName.Text == string.Empty)
            {
                return false;
            }
            return true;
        }
    }
}
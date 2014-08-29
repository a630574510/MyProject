using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FineUI;
namespace Citic_Web.BasicInfoManagement
{
    public partial class ShowLinkmanInfo : BasePage
    {
        //PrivateFields--乔春羽
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                string lkidstr = Request.QueryString["lkid"];
                if (lkidstr != null && lkidstr != string.Empty)
                {
                    id = int.Parse(lkidstr);
                    ViewState.Clear();
                    ViewState.Add("ID", id);
                }
                GridBind();
            }
        }

        /// <summary>
        /// 初始化页面中的成员变量（ID）--乔春羽
        /// </summary>
        private int GetID()
        {
            int ID = 0;
            if (ID == 0)
            {
                ID = Convert.ToInt32(ViewState["ID"]);
            }
            return ID;
        }

        private Citic.Model.Linkman Model
        {
            get { return ViewState["Model"] as Citic.Model.Linkman; }
            set { ViewState["Model"] = value; }
        }

        /// <summary>
        /// 显示数据--乔春羽
        /// </summary>
        private void GridBind()
        {
            Model = LinkmanBll.GetModel(GetID());
            if (Model != null)
            {
                this.txt_Name.Text = Model.LinkmanName;
                this.txt_Phone.Text = Model.Phone;
                this.txt_Post.Text = Model.Post;
                this.txt_Email.Text = Model.Email;
            }
        }

        /// <summary>
        /// 保存并关闭--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            SaveLinkmanInfo();
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        /// <summary>
        /// 保存联系人信息--乔春羽
        /// </summary>
        private void SaveLinkmanInfo()
        {
            if (Model != null)
            {
                try
                {
                    Model.Email = this.txt_Email.Text;
                    Model.LinkmanName = this.txt_Name.Text;
                    Model.Post = this.txt_Post.Text;
                    Model.Phone = this.txt_Phone.Text;
                    Model.UpdateID = this.CurrentUser.UserId;
                    Model.UpdateTime = DateTime.Now;
                    bool flag = LinkmanBll.Update(Model);
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
                    Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "SaveLinkmanInfo()");
                }
            }
            else
            {
                AlertShowInTop("系统出现异常，请联系管理员。");
            }
        }
    }
}
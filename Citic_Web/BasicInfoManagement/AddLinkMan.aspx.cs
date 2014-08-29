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
    public partial class AddLinkman : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //乔春羽
            if (!IsPostBack)
            {
                string bankIDStr = Request.QueryString["BankID"];
                if (bankIDStr != null && bankIDStr != string.Empty)
                {
                    BankID = int.Parse(bankIDStr);
                }
            }
        }

        private int BankID 
        {
            get { return (int)ViewState["BankID"]; }
            set { ViewState["BankID"] = value; }
        }

        /// <summary>
        /// 保存并关闭--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            SaveLinkman();
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        /// <summary>
        /// 保存联系人--乔春羽
        /// </summary>
        private void SaveLinkman()
        {
            Citic.Model.Linkman model = new Citic.Model.Linkman();
            model.LinkType = 2;
            model.RelationID = Convert.ToInt32(BankID);
            model.CreateID = this.CurrentUser.UserId;
            model.CreateTime = DateTime.Now;
            model.Email = this.txt_Email.Text;
            model.IsPort = false;
            model.IsDelete = false;
            model.LinkmanName = this.txt_LinkmanName.Text;
            model.Post = this.txt_Post.Text;
            model.Phone = this.num_Phone.Text;
            int lid = LinkmanBll.Add(model);
            if (lid > 0)
            {
                AlertShowInTop("添加成功！");
            }
            else
            {
                AlertShowInTop("添加失败！");
            }
        }
    }
}
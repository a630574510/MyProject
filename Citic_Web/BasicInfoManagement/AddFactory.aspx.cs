using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Citic_Web.BasicInfoManagement
{
    public partial class AddFactory : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //清除ViewState的所有值
                ViewState.Clear();
                WUC_Address.Init();
            }
        }

        #region Private Fields--乔春羽(2014.1.2)
        private int FactoryID
        {
            get { return (int)ViewState["ID"]; }
            set { ViewState["ID"] = value; }
        }
        #endregion

        #region 保存操作--乔春羽
        /// <summary>
        /// 验证ViewState中是否存有新增加的工厂ID
        /// </summary>
        /// <returns></returns>
        private bool ValidateFactoryID()
        {
            return FactoryID == 0 ? true : false;
        }
        /// <summary>
        /// 保存品牌
        /// </summary>
        private void SaveBrand()
        {
            if (ValidateFactoryID())
            {
                return;
            }

            Citic.Model.Brand model = new Citic.Model.Brand();
            model.BrandName = this.txt_BrandName.Text;
            model.CreateID = this.CurrentUser.UserId;
            model.CreateTime = DateTime.Now;
            model.FactoryID = FactoryID;
            model.IsDelete = false;
            model.IsPort = false;
            model.Remark = this.txt_Remark.Text;

            try
            {
                int num = BrandBll.Add(model);
                if (num > 0)
                {
                    AlertShowInTop("添加成功！");
                }
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "SaveBrand()");
            }
        }
        /// <summary>
        /// 保存联系人
        /// </summary>
        private void SaveLinkman()
        {
            if (ValidateFactoryID())
            {
                return;
            }
            Citic.Model.Linkman model = new Citic.Model.Linkman();
            model.CreateID = CurrentUser.UserId;
            model.CreateTime = DateTime.Now;
            model.LinkmanName = this.txt_LinkManName.Text;
            model.Phone = this.num_Phone.Text;
            model.RelationID = FactoryID;
            model.LinkType = Convert.ToInt32(Citic_Web.Common.LinkType.FactoryLinkman);

            try
            {
                int num = LinkmanBll.Add(model);
                if (num > 0)
                {
                    AlertShowInTop("添加成功！");
                }
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "SaveLinkman()");
            }
        }

        /// <summary>
        /// 保存厂商信息--乔春羽
        /// </summary>
        private void SaveFactory()
        {
            Citic.Model.Factory model = new Citic.Model.Factory();
            model.FactoryName = this.txt_FactoryName.Text;
            model.IsDelete = false;
            model.IsPort = false;
            model.CreateID = this.CurrentUser.UserId;
            model.CreateTime = DateTime.Now;
            model.Address = GetAddress();
            try
            {
                FactoryID = FactoryBll.Add(model);
                if (FactoryID > 0)
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
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "SaveFactory()");
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

        /// <summary>
        /// 保存并且关闭页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            SaveFactory();
            SaveLinkman();
            SaveBrand();
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        #endregion

    }
}
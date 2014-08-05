using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class RiskQuesEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                string str = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(str)) 
                {
                    ShowDate(int.Parse(str));
                }
            }
        }
        #region 显示数据--乔春羽(2013.8.7)
        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="id"></param>
        private void ShowDate(int id) 
        {
            Citic.Model.RiskQuestion model = RQBLL.GetModel(id);
            if (model != null) 
            {
                _ID.Value = model.ID.ToString();
                No.Text = model.No;
                CC_AP.Value = model.CC_AP;
                CC_Content.Value = model.CC_Content;
                CC_Date.Value = model.CC_Date == null ? "" : model.CC_Date.Value.ToShortDateString();
                CC_P.Value = model.CC_P;
                CC_Post.Value = model.CC_Post;
                CC_PPhone.Value = model.CC_PPhone;
                CC_Unit.Value = model.CC_Unit;
                SQ_Brand.Value = model.SQ_Brand;
                SQ_Content.Value = model.SQ_Content;
                SQ_FBP.Value = model.SQ_FBP;
                SQ_FBPP.Value = model.SQ_FBPP;
                SQ_Name.Value = model.SQ_Name;
                SQ_Phone.Value = model.SQ_Phone;
                SQ_Shop.Value = model.SQ_Shop;
                S_P.Value = model.S_P;
                S_Phone.Value = model.S_Phone;
                S_Result.Value = model.S_Result;
                GD.Value = model.GD;
                WTCLBF.Value = model.WTCLBF;
                QCJRZXYJ.Value = model.QCJRZXYJ;
                QCJRZXQZ.Value = model.QCJRZXQZ;
                GLZXYJ.Value = model.GLZXYJ;
                GLZXQZ.Value = model.GLZXQZ;
            }
        }
        #endregion
    }
}
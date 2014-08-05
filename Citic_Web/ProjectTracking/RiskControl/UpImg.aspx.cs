using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class UpImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {

            }
        }

        #region 图片上传--乔春羽
        protected void btn_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Button btn = sender as System.Web.UI.WebControls.Button;
            string savePath = "~/UploadImage/";
            string exten = "jpg";
            if (btn != null)
            {
                if (btn.ID == "btn_S")
                {
                    if (P_S.HasFile)
                    {
                        exten = P_S.FileName.Substring(P_S.FileName.LastIndexOf('.'));
                        string filename = "监管员照片_" + getFileNameByTimeSpan() + exten;
                        P_S.SaveAs(Server.MapPath(savePath + filename));
                        this.img_S.ImageUrl = savePath + filename;
                    }
                }
                else if (btn.ID == "btn_SB")
                {
                    if (P_SB.HasFile)
                    {
                        exten = P_SB.FileName.Substring(P_SB.FileName.LastIndexOf('.'));
                        string filename = "保险柜照_" + getFileNameByTimeSpan() + exten;
                        P_SB.SaveAs(Server.MapPath(savePath + filename));
                        this.img_SB.ImageUrl = savePath + filename;
                    }
                }
                else if (btn.ID == "btn_WP")
                {
                    if (P_WP.HasFile)
                    {
                        exten = P_WP.FileName.Substring(P_WP.FileName.LastIndexOf('.'));
                        string filename = "工位照_" + getFileNameByTimeSpan() + exten;
                        P_WP.SaveAs(Server.MapPath(savePath + filename));
                        this.img_WP.ImageUrl = savePath + filename;
                    }
                }
                else if (btn.ID == "btn_HGZ")
                {
                    if (P_HGZ.HasFile)
                    {
                        exten = P_HGZ.FileName.Substring(P_HGZ.FileName.LastIndexOf('.'));
                        string filename = "合格证保存照_" + getFileNameByTimeSpan() + exten;
                        P_HGZ.SaveAs(Server.MapPath(savePath + filename));
                        this.img_HGZ.ImageUrl = savePath + filename;
                    }
                }
                else if (btn.ID == "btn_Keys")
                {
                    if (P_Keys.HasFile)
                    {
                        exten = P_Keys.FileName.Substring(P_Keys.FileName.LastIndexOf('.'));
                        string filename = "钥匙保存照_" + getFileNameByTimeSpan() + exten;
                        P_Keys.SaveAs(Server.MapPath(savePath + filename));
                        this.img_Keys.ImageUrl = savePath + filename;
                    }
                }
                else if (btn.ID == "btn_Forms")
                {
                    if (P_Forms.HasFile)
                    {
                        exten = P_Forms.FileName.Substring(P_Forms.FileName.LastIndexOf('.'));
                        string filename = "表单保存照_" + getFileNameByTimeSpan() + exten;
                        P_Forms.SaveAs(Server.MapPath(savePath + filename));
                        this.img_Forms.ImageUrl = savePath + filename;
                    }
                }
                else if (btn.ID == "btn_Shop")
                {
                    if (P_Shop.HasFile)
                    {
                        exten = P_Shop.FileName.Substring(P_Shop.FileName.LastIndexOf('.'));
                        string filename = "店面照_" + getFileNameByTimeSpan() + exten;
                        P_Shop.SaveAs(Server.MapPath(savePath + filename));
                        this.img_Shop.ImageUrl = savePath + filename;
                    }
                }
                else if (btn.ID == "btn_SR")
                {
                    if (P_SR.HasFile)
                    {
                        exten = P_SR.FileName.Substring(P_SR.FileName.LastIndexOf('.'));
                        string filename = "展厅照_" + getFileNameByTimeSpan() + exten;
                        P_SR.SaveAs(Server.MapPath(savePath + filename));
                        this.img_SR.ImageUrl = savePath + filename;
                    }
                }
                else if (btn.ID == "btn_CK")
                {
                    if (P_CK.HasFile)
                    {
                        exten = P_CK.FileName.Substring(P_CK.FileName.LastIndexOf('.'));
                        string filename = "车库照_" + getFileNameByTimeSpan() + exten;
                        P_CK.SaveAs(Server.MapPath(savePath + filename));
                        this.img_CK.ImageUrl = savePath + filename;
                    }
                }
                else if (btn.ID == "btn_CK2")
                {
                    if (P_CK2.HasFile)
                    {
                        exten = P_CK2.FileName.Substring(P_CK2.FileName.LastIndexOf('.'));
                        string filename = "车库2照_" + getFileNameByTimeSpan() + exten;
                        P_CK2.SaveAs(Server.MapPath(savePath + filename));
                        this.img_CK2.ImageUrl = savePath + filename;
                    }
                }
                else if (btn.ID == "btn_SS")
                {
                    if (P_SS.HasFile)
                    {
                        exten = P_SS.FileName.Substring(P_SS.FileName.LastIndexOf('.'));
                        string filename = "宿舍照_" + getFileNameByTimeSpan() + exten;
                        P_SS.SaveAs(Server.MapPath(savePath + filename));
                        this.img_SS.ImageUrl = savePath + filename;
                    }
                }
                else if (btn.ID == "btn_DFRY")
                {
                    if (P_DFRY.HasFile)
                    {
                        exten = P_DFRY.FileName.Substring(P_DFRY.FileName.LastIndexOf('.'));
                        string filename = "店方荣誉照_" + getFileNameByTimeSpan() + exten;
                        P_DFRY.SaveAs(Server.MapPath(savePath + filename));
                        this.img_DFRY.ImageUrl = savePath + filename;
                    }
                }
            }
        }

        /// <summary>
        /// 根据时间戳获取文件名，以此避免文件名重复问题
        /// </summary>
        /// <returns></returns>
        private string getFileNameByTimeSpan()
        {
            string fileName = string.Empty;
            fileName = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second;
            return fileName;
        }
        #endregion
    }
}
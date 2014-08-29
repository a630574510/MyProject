using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class XDBG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = Request.QueryString["ID"];
                if (!string.IsNullOrEmpty(str))
                {
                    ID.Value = str;
                    Citic.Model.DealerXDReports model = XDBLL.GetModel(int.Parse(str));
                    ViewState.Add("XDBG", model);

                    ShowBasic();
                    ShowCCS();
                    ShowPIC();
                    ShowSGAB();
                    ShowCWS();
                    ShowBIS();
                    ShowP();
                }
                else
                {
                    //显示基础数据--乔春羽
                    ShowData();
                }
            }
        }
        #region PrivateFields--乔春羽(2013.8.1)
        private Citic.Model.M_XunDianReport _Model;

        public Citic.Model.M_XunDianReport Model
        {
            get
            {
                if (Session["XDBG"] != null)
                {
                    _Model = Session["XDBG"] as Citic.Model.M_XunDianReport;
                }
                return _Model;
            }
        }
        private Citic.Model.DealerXDReports _XDBG;

        public Citic.Model.DealerXDReports DealerXDReports
        {
            get
            {
                if (ViewState["XDBG"] != null)
                {
                    _XDBG = ViewState["XDBG"] as Citic.Model.DealerXDReports;
                }
                return _XDBG;
            }
        }

        private Citic.BLL.DealerXDReports _XDBLL = null;

        public Citic.BLL.DealerXDReports XDBLL
        {
            get
            {
                if (_XDBLL == null)
                {
                    _XDBLL = new Citic.BLL.DealerXDReports();
                }
                return _XDBLL;
            }
        }
        #endregion

        #region 显示基础数据--乔春羽(2013.8.1)
        /// <summary>
        /// 显示基础数据
        /// </summary>
        private void ShowData()
        {
            ID.Value = Model.ID.ToString();
            Title_DealerName.Text = Model.DealerName;
            DealerName.Text = Model.DealerName;
            DealerName1.Text = Model.DealerName;
            DealerID.Value = Model.DealerID.ToString();
            BankID.Value = Model.BankID.ToString();
            BankName.Text = Model.BankName;
            BrandIDs.Value = Model.BrandIDs;
            BrandName.Text = Model.BrandName;
            Address.Text = Model.Address;
            DispatchTime.Text = Model.DispatchTime.ToShortDateString();
            IsGroup.Text = Model.IsGroup;
            IsSingleStore.Text = Model.IsSingleStore;
            Banks.Text = Model.Banks.ToString();
            AllSSMoney.Text = Model.AllSSMoney.ToString();
            DealerType.Text = Model.DealerType;
        }
        #endregion

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
                        if (!string.IsNullOrEmpty(hf_S.Value))
                        {
                            DropPhoto(hf_S.Value);
                        }
                        exten = P_S.FileName.Substring(P_S.FileName.LastIndexOf('.'));
                        string filename = "监管员照片_" + getFileNameByTimeSpan() + exten;
                        P_S.SaveAs(Server.MapPath(savePath + filename));
                        this.img_S.ImageUrl = savePath + filename;
                        this.hf_S.Value = filename;
                    }
                }
                else if (btn.ID == "btn_SB")
                {
                    if (P_SB.HasFile)
                    {
                        if (!string.IsNullOrEmpty(hf_SB.Value))
                        {
                            DropPhoto(hf_SB.Value);
                        }
                        exten = P_SB.FileName.Substring(P_SB.FileName.LastIndexOf('.'));
                        string filename = "保险柜照_" + getFileNameByTimeSpan() + exten;
                        P_SB.SaveAs(Server.MapPath(savePath + filename));
                        this.img_SB.ImageUrl = savePath + filename;
                        this.hf_SB.Value = filename;
                    }
                }
                else if (btn.ID == "btn_WP")
                {
                    if (P_WP.HasFile)
                    {
                        if (!string.IsNullOrEmpty(hf_WP.Value))
                        {
                            DropPhoto(hf_WP.Value);
                        }
                        exten = P_WP.FileName.Substring(P_WP.FileName.LastIndexOf('.'));
                        string filename = "工位照_" + getFileNameByTimeSpan() + exten;
                        P_WP.SaveAs(Server.MapPath(savePath + filename));
                        this.img_WP.ImageUrl = savePath + filename;
                        this.hf_WP.Value = filename;
                    }
                }
                else if (btn.ID == "btn_HGZ")
                {
                    if (P_HGZ.HasFile)
                    {
                        if (!string.IsNullOrEmpty(hf_HGZ.Value))
                        {
                            DropPhoto(hf_HGZ.Value);
                        }
                        exten = P_HGZ.FileName.Substring(P_HGZ.FileName.LastIndexOf('.'));
                        string filename = "合格证保存照_" + getFileNameByTimeSpan() + exten;
                        P_HGZ.SaveAs(Server.MapPath(savePath + filename));
                        this.img_HGZ.ImageUrl = savePath + filename;
                        this.hf_HGZ.Value = filename;
                    }
                }
                else if (btn.ID == "btn_Keys")
                {
                    if (P_Keys.HasFile)
                    {
                        if (!string.IsNullOrEmpty(hf_Keys.Value))
                        {
                            DropPhoto(hf_Keys.Value);
                        }
                        exten = P_Keys.FileName.Substring(P_Keys.FileName.LastIndexOf('.'));
                        string filename = "钥匙保存照_" + getFileNameByTimeSpan() + exten;
                        P_Keys.SaveAs(Server.MapPath(savePath + filename));
                        this.img_Keys.ImageUrl = savePath + filename;
                        this.hf_Keys.Value = filename;
                    }
                }
                else if (btn.ID == "btn_Forms")
                {
                    if (P_Forms.HasFile)
                    {
                        if (!string.IsNullOrEmpty(hf_Forms.Value))
                        {
                            DropPhoto(hf_Forms.Value);
                        }
                        exten = P_Forms.FileName.Substring(P_Forms.FileName.LastIndexOf('.'));
                        string filename = "表单保存照_" + getFileNameByTimeSpan() + exten;
                        P_Forms.SaveAs(Server.MapPath(savePath + filename));
                        this.img_Forms.ImageUrl = savePath + filename;
                        this.hf_Forms.Value = filename;
                    }
                }
                else if (btn.ID == "btn_Shop")
                {
                    if (P_Shop.HasFile)
                    {
                        if (!string.IsNullOrEmpty(hf_Shop.Value))
                        {
                            DropPhoto(hf_Shop.Value);
                        }
                        exten = P_Shop.FileName.Substring(P_Shop.FileName.LastIndexOf('.'));
                        string filename = "店面照_" + getFileNameByTimeSpan() + exten;
                        P_Shop.SaveAs(Server.MapPath(savePath + filename));
                        this.img_Shop.ImageUrl = savePath + filename;
                        this.hf_Shop.Value = filename;
                    }
                }
                else if (btn.ID == "btn_SR")
                {
                    if (P_SR.HasFile)
                    {
                        if (!string.IsNullOrEmpty(hf_SR.Value))
                        {
                            DropPhoto(hf_SR.Value);
                        }
                        exten = P_SR.FileName.Substring(P_SR.FileName.LastIndexOf('.'));
                        string filename = "展厅照_" + getFileNameByTimeSpan() + exten;
                        P_SR.SaveAs(Server.MapPath(savePath + filename));
                        this.img_SR.ImageUrl = savePath + filename;
                        this.hf_SR.Value = filename;
                    }
                }
                else if (btn.ID == "btn_CK")
                {
                    if (P_CK.HasFile)
                    {
                        if (!string.IsNullOrEmpty(hf_CK.Value))
                        {
                            DropPhoto(hf_CK.Value);
                        }
                        exten = P_CK.FileName.Substring(P_CK.FileName.LastIndexOf('.'));
                        string filename = "车库照_" + getFileNameByTimeSpan() + exten;
                        P_CK.SaveAs(Server.MapPath(savePath + filename));
                        this.img_CK.ImageUrl = savePath + filename;
                        this.hf_CK.Value = filename;
                    }
                }
                else if (btn.ID == "btn_CK2")
                {
                    if (P_CK2.HasFile)
                    {
                        if (!string.IsNullOrEmpty(hf_CK2.Value))
                        {
                            DropPhoto(hf_CK2.Value);
                        }
                        exten = P_CK2.FileName.Substring(P_CK2.FileName.LastIndexOf('.'));
                        string filename = "车库2照_" + getFileNameByTimeSpan() + exten;
                        P_CK2.SaveAs(Server.MapPath(savePath + filename));
                        this.img_CK2.ImageUrl = savePath + filename;
                        this.hf_CK2.Value = filename;
                    }
                }
                else if (btn.ID == "btn_SS")
                {
                    if (P_SS.HasFile)
                    {
                        if (!string.IsNullOrEmpty(hf_SS.Value))
                        {
                            DropPhoto(hf_SS.Value);
                        }
                        exten = P_SS.FileName.Substring(P_SS.FileName.LastIndexOf('.'));
                        string filename = "宿舍照_" + getFileNameByTimeSpan() + exten;
                        P_SS.SaveAs(Server.MapPath(savePath + filename));
                        this.img_SS.ImageUrl = savePath + filename;
                        this.hf_SS.Value = filename;
                    }
                }
                else if (btn.ID == "btn_DFRY")
                {
                    if (P_DFRY.HasFile)
                    {
                        if (!string.IsNullOrEmpty(hf_DFRY.Value))
                        {
                            DropPhoto(hf_DFRY.Value);
                        }
                        exten = P_DFRY.FileName.Substring(P_DFRY.FileName.LastIndexOf('.'));
                        string filename = "店方荣誉照_" + getFileNameByTimeSpan() + exten;
                        P_DFRY.SaveAs(Server.MapPath(savePath + filename));
                        this.img_DFRY.ImageUrl = savePath + filename;
                        this.hf_DFRY.Value = filename;
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

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="contain"></param>
        private void DropPhoto(string contain)
        {
            string path = "~/UploadImage/";
            DirectoryInfo di = new DirectoryInfo(Server.MapPath(path));
            if (contain.IndexOf('.') >= 0)
            {
                foreach (FileInfo fi in di.GetFiles())
                {
                    if (fi.Name.Equals(contain))
                    {
                        string fileName = path + fi.Name;
                        if (File.Exists(Server.MapPath(fileName)))
                        {
                            File.Delete(Server.MapPath(fileName));
                        }
                    }
                }
            }
            else
            {
                foreach (FileInfo fi in di.GetFiles())
                {
                    if (fi.Name.Contains(contain))
                    {
                        string fileName = path + fi.Name;
                        if (File.Exists(Server.MapPath(fileName)))
                        {
                            File.Delete(Server.MapPath(fileName));
                        }
                    }
                }
            }
        }
        #endregion

        #region 保存信息--乔春羽(2013.8.1)
        protected void btn_CSS_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Button btn = sender as System.Web.UI.WebControls.Button;
            if (btn != null)
            {
                if (btn.ID == "btn_CCS")
                {
                    string css11 = CCS_1_1.Text;
                    string css12 = CCS_1_2.Text;
                    string css13 = CCS_1_3.Text;
                    string css14 = CCS_1_4.Text;
                    string css21 = CCS_2_1.Text;
                    string css22 = CCS_2_2.Text;
                    string css23 = CCS_2_3.Text;
                    string css31 = CCS_3_1.Text;
                    string css32 = CCS_3_2.Text;
                    string css33 = CCS_3_3.Text;
                    string css41 = CCS_4_1.Text;
                    string css42 = CCS_4_2.Text;
                    string css43 = CCS_4_3.Text;
                    string css51 = CCS_5_1.Text;
                    string css52 = CCS_5_2.Text;
                    string css53 = CCS_5_3.Text;
                    string css61 = CCS_6_1.Text;
                    string css62 = CCS_6_2.Text;
                    string css63 = CCS_6_3.Text;
                    string css71 = CCS_7_1.Text;
                    string css72 = CCS_7_2.Text;
                    string css73 = CCS_7_3.Text;
                    string css81 = CCS_8_1.Text;
                    string css82 = CCS_8_2.Text;
                    string css83 = CCS_8_3.Text;
                    string css91 = CCS_9_1.Text;
                    string css101 = CCS_10_1.Text;
                    string css111 = CCS_11_1.Text;
                    string css121 = CCS_12_1.Text;
                    string css122 = CCS_12_2.Text;
                    string css123 = CCS_12_3.Text;
                    string css131 = CCS_13_1.Text;
                    string css133 = CCS_13_3.Text;
                    string css141 = CCS_14_1.Text;
                    string css142 = CCS_14_2.Text;
                    string css143 = CCS_14_3.Text;
                    string css153 = CCS_15_3.Text;

                    string css161 = CCS_16_1.Text;
                    string css162 = CCS_16_2.Text;
                    string css163 = CCS_16_3.Text;
                    string css171 = CCS_17_1.Text;
                    string css172 = CCS_17_2.Text;
                    string css173 = CCS_17_3.Text;
                    string css181 = CCS_18_1.Text;
                    string css182 = CCS_18_2.Text;
                    string css183 = CCS_18_3.Text;
                    string css191 = CCS_19_1.Text;
                    string css192 = CCS_19_2.Text;
                    string css193 = CCS_19_3.Text;
                    string css201 = CCS_20_1.Text;
                    string css202 = CCS_20_2.Text;
                    string css203 = CCS_20_3.Text;


                    Citic.Model.DealerXDReports model = new Citic.Model.DealerXDReports();
                    model.ID = int.Parse(ID.Value);
                    model.CCS_1_1 = css11;
                    model.CCS_1_2 = css12;
                    model.CCS_1_3 = css13;
                    model.CCS_2_1 = css21;
                    model.CCS_2_2 = css22;
                    model.CCS_2_3 = css23;
                    model.CCS_3_1 = css31;
                    model.CCS_3_2 = css32;
                    model.CCS_3_3 = css33;
                    model.CCS_4_1 = css41;
                    model.CCS_4_2 = css42;
                    model.CCS_4_3 = css43;
                    model.CCS_5_1 = css51;
                    model.CCS_5_2 = css52;
                    model.CCS_5_3 = css53;
                    model.CCS_6_1 = css61;
                    model.CCS_6_2 = css62;
                    model.CCS_6_3 = css63;
                    model.CCS_7_1 = css71;
                    model.CCS_7_2 = css72;
                    model.CCS_7_3 = css73;
                    model.CCS_8_1 = css81;
                    model.CCS_8_2 = css82;
                    model.CCS_8_3 = css83;
                    model.CCS_9_1 = css91;
                    model.CCS_10_1 = css101;
                    model.CCS_11_1 = css111;
                    model.CCS_12_1 = css121;
                    model.CCS_12_2 = css122;
                    model.CCS_12_3 = css123;
                    model.CCS_13_1 = css131;
                    model.CCS_13_3 = css133;
                    model.CCS_14_1 = css141;
                    model.CCS_14_2 = css142;
                    model.CCS_14_3 = css143;
                    model.CCS_15_3 = css153;
                    model.CCS_16_1 = css161;
                    model.CCS_16_2 = css162;
                    model.CCS_16_3 = css163;
                    model.CCS_17_1 = css171;
                    model.CCS_17_2 = css172;
                    model.CCS_17_3 = css173;
                    model.CCS_18_1 = css181;
                    model.CCS_18_2 = css182;
                    model.CCS_18_3 = css183;
                    model.CCS_19_1 = css191;
                    model.CCS_19_2 = css192;
                    model.CCS_19_3 = css193;
                    model.CCS_20_1 = css201;
                    model.CCS_20_2 = css202;
                    model.CCS_20_3 = css203;
                    bool flag = XDBLL.UpdateCCS(model);
                    lbl_MessCSS.ApplyStyleSheetSkin(this);
                    if (flag)
                    {
                        lbl_MessCSS.Text = "保存成功！";
                    }
                    else
                    {
                        lbl_MessCSS.Text = "保存失败！";
                    }
                }
            }
        }
        #endregion

        #region 显示数据--乔春羽(2013.8.5)
        /// <summary>
        /// 显示基本数据
        /// </summary>
        private void ShowBasic()
        {
            Title_DealerName.Text = DealerXDReports.DealerName;
            DealerName.Text = DealerXDReports.DealerName;
            DealerName1.Text = DealerXDReports.DealerName;
            DealerID.Value = DealerXDReports.DealerID.ToString();
            Address.Text = DealerXDReports.Address;
            BankID.Value = DealerXDReports.BankID.ToString();
            BankName.Text = DealerXDReports.BankName;
            BrandIDs.Value = DealerXDReports.BrandID;
            BrandName.Text = DealerXDReports.BrandName;
            DispatchTime.Text = DealerXDReports.DispatchTime.Value.ToShortDateString();
            txt_CaoZuoMoShi.Text = DealerXDReports.OperationMode;
            txt_CheckDate.Text = DealerXDReports.CheckDate.Value.ToShortDateString();
            txt_CheckInTime.Text = DealerXDReports.CheckInTime.ToString();
            if (DealerXDReports.DealerType.Contains("1"))
            {
                DealerXDReports.DealerType = DealerXDReports.DealerType.Replace("1", "民营");
            }
            if (DealerXDReports.DealerType.Contains("2"))
            {
                DealerXDReports.DealerType = DealerXDReports.DealerType.Replace("2", "国营");
            }
            if (DealerXDReports.DealerType.Contains("3"))
            {
                DealerXDReports.DealerType = DealerXDReports.DealerType.Replace("3", "集团");
            }
            if (DealerXDReports.DealerType.Contains("4"))
            {
                DealerXDReports.DealerType = DealerXDReports.DealerType.Replace("4", "单店");
            }
            DealerType.Text = DealerXDReports.DealerType;
            IsGroup.Text = DealerXDReports.IsGroup ? "是" : "否";
            IsSingleStore.Text = DealerXDReports.IsSingleStore ? "是" : "否";
        }
        /// <summary>
        /// 显示检查内容项信息
        /// </summary>
        private void ShowCCS()
        {
            CCS_1_1.Text = DealerXDReports.CCS_1_1;
            CCS_1_2.Text = DealerXDReports.CCS_1_2;
            CCS_1_3.Text = DealerXDReports.CCS_1_3;
            CCS_1_4.Text = DealerXDReports.CCS_1_4;
            CCS_2_1.Text = DealerXDReports.CCS_2_1;
            CCS_2_2.Text = DealerXDReports.CCS_2_2;
            CCS_2_3.Text = DealerXDReports.CCS_2_3;
            CCS_3_1.Text = DealerXDReports.CCS_3_1;
            CCS_3_2.Text = DealerXDReports.CCS_3_2;
            CCS_3_3.Text = DealerXDReports.CCS_3_3;
            CCS_4_1.Text = DealerXDReports.CCS_4_1;
            CCS_4_2.Text = DealerXDReports.CCS_4_2;
            CCS_4_3.Text = DealerXDReports.CCS_4_3;
            CCS_5_1.Text = DealerXDReports.CCS_5_1;
            CCS_5_2.Text = DealerXDReports.CCS_5_2;
            CCS_5_3.Text = DealerXDReports.CCS_5_3;
            CCS_6_1.Text = DealerXDReports.CCS_6_1;
            CCS_6_2.Text = DealerXDReports.CCS_6_2;
            CCS_6_3.Text = DealerXDReports.CCS_6_3;
            CCS_7_1.Text = DealerXDReports.CCS_7_1;
            CCS_7_2.Text = DealerXDReports.CCS_7_2;
            CCS_7_3.Text = DealerXDReports.CCS_7_3;
            CCS_8_1.Text = DealerXDReports.CCS_8_1;
            CCS_8_2.Text = DealerXDReports.CCS_8_2;
            CCS_8_3.Text = DealerXDReports.CCS_8_3;
            CCS_9_1.Text = DealerXDReports.CCS_9_1;
            CCS_10_1.Text = DealerXDReports.CCS_10_1;
            CCS_11_1.Text = DealerXDReports.CCS_11_1;
            CCS_12_1.Text = DealerXDReports.CCS_12_1;
            CCS_12_2.Text = DealerXDReports.CCS_12_2;
            CCS_12_3.Text = DealerXDReports.CCS_12_3;
            CCS_13_1.Text = DealerXDReports.CCS_13_1;
            CCS_13_3.Text = DealerXDReports.CCS_13_3;
            CCS_14_1.Text = DealerXDReports.CCS_14_1;
            CCS_14_2.Text = DealerXDReports.CCS_14_2;
            CCS_14_3.Text = DealerXDReports.CCS_14_3;
            CCS_15_3.Text = DealerXDReports.CCS_15_3;
            CCS_16_1.Text = DealerXDReports.CCS_16_1;
            CCS_16_2.Text = DealerXDReports.CCS_16_2;
            CCS_16_3.Text = DealerXDReports.CCS_16_3;
            CCS_17_1.Text = DealerXDReports.CCS_17_1;
            CCS_17_2.Text = DealerXDReports.CCS_17_2;
            CCS_17_3.Text = DealerXDReports.CCS_17_3;
            CCS_18_1.Text = DealerXDReports.CCS_18_1;
            CCS_18_2.Text = DealerXDReports.CCS_18_2;
            CCS_18_3.Text = DealerXDReports.CCS_18_3;
            CCS_19_1.Text = DealerXDReports.CCS_19_1;
            CCS_19_2.Text = DealerXDReports.CCS_19_2;
            CCS_19_3.Text = DealerXDReports.CCS_19_3;
            CCS_20_1.Text = DealerXDReports.CCS_20_1;
            CCS_20_2.Text = DealerXDReports.CCS_20_2;
            CCS_20_3.Text = DealerXDReports.CCS_20_3;
        }

        /// <summary>
        /// 显示“检查过程中发现的问题”信息
        /// </summary>
        private void ShowPIC()
        {
            PIC_1_1.Text = DealerXDReports.PIC_1_1;
            PIC_1_2.Text = DealerXDReports.PIC_1_2;
            PIC_2_1.Text = DealerXDReports.PIC_2_1;
            PIC_2_2.Text = DealerXDReports.PIC_2_2;
            PIC_3_1.Text = DealerXDReports.PIC_3_1;
            PIC_3_2.Text = DealerXDReports.PIC_3_2;
            PIC_4_1.Text = DealerXDReports.PIC_4_1;
            PIC_4_2.Text = DealerXDReports.PIC_4_2;
            PIC_5_1.Text = DealerXDReports.PIC_5_1;
            PIC_5_2.Text = DealerXDReports.PIC_5_2;
            PIC_6_1.Text = DealerXDReports.PIC_6_1;
            PIC_6_2.Text = DealerXDReports.PIC_6_2;
            PIC_7_1.Text = DealerXDReports.PIC_7_1;
            PIC_7_2.Text = DealerXDReports.PIC_7_2;
        }

        /// <summary>
        /// 显示“监管员优缺点”信息
        /// </summary>
        private void ShowSGAB()
        {
            SGAB_1.Text = DealerXDReports.SGAB_1;
            SGAB_2.Text = DealerXDReports.SGAB_2;
        }

        /// <summary>
        /// 显示“与店方沟通”信息
        /// </summary>
        private void ShowCWS()
        {
            CWS_Content.Text = DealerXDReports.CWS_Content;
            CWS_Name.Text = DealerXDReports.CWS_Name;
            CWS_Post.Text = DealerXDReports.CWS_Post;
            CheckResults.Text = DealerXDReports.CheckResults;
        }

        /// <summary>
        /// 显示“监管员基本情况介绍”信息
        /// </summary>
        private void ShowBIS()
        {
            BIS_Age.Text = DealerXDReports.BIS_Age.ToString();
            BIS_BRSJSX.Text = DealerXDReports.BIS_BRSJSX;
            BIS_CS.Text = DealerXDReports.BIS_CS;
            BIS_Eat.Text = DealerXDReports.BIS_Eat;
            BIS_Edu.Text = DealerXDReports.BIS_Edu;
            BIS_EFS.Text = DealerXDReports.BIS_EFS;
            BIS_GSRKSX.Text = DealerXDReports.BIS_GSRKSX;
            BIS_HA.Text = DealerXDReports.BIS_HA;
            BIS_JGSTime.Text = DealerXDReports.BIS_JGSTime == null ? "" : DealerXDReports.BIS_JGSTime.Value.ToShortDateString();
            BIS_Name.Text = DealerXDReports.BIS_Name;
            BIS_Phone_JJ.Text = DealerXDReports.BIS_Phone_JJ;
            BIS_Phone_PF.Text = DealerXDReports.BIS_Phone_PF;
            BIS_Sex.Text = DealerXDReports.BIS_Sex;
            BIS_SGTime.Text = DealerXDReports.BIS_SGTime == null ? "" : DealerXDReports.BIS_SGTime.Value.ToShortDateString();
            BIS_Stay.Text = DealerXDReports.BIS_Stay;
            BIS_WB.Text = DealerXDReports.BIS_WB;
            BIS_WE.Text = DealerXDReports.BIS_WE;
            BIS_WS.Text = DealerXDReports.BIS_WS;
        }

        /// <summary>
        /// 显示“店面拍照”与“检查人”信息
        /// </summary>
        private void ShowP()
        {
            string path = "~/UploadImage/";
            this.img_CK.ImageUrl = path + DealerXDReports.P_CK;
            this.img_CK2.ImageUrl = path + DealerXDReports.P_CK2;
            this.img_DFRY.ImageUrl = path + DealerXDReports.P_DFRY;
            this.img_Forms.ImageUrl = path + DealerXDReports.P_Forms;
            this.img_HGZ.ImageUrl = path + DealerXDReports.P_HGZ;
            this.img_Keys.ImageUrl = path + DealerXDReports.P_Keys;
            this.img_S.ImageUrl = path + DealerXDReports.P_S;
            this.img_SB.ImageUrl = path + DealerXDReports.P_SB;
            this.img_Shop.ImageUrl = path + DealerXDReports.P_Shop;
            this.img_SR.ImageUrl = path + DealerXDReports.P_SR;
            this.img_SS.ImageUrl = path + DealerXDReports.P_SS;
            this.img_WP.ImageUrl = path + DealerXDReports.P_WP;

            Checkman.Text = DealerXDReports.Checkman;
            CheckDate2.Text = DealerXDReports.CheckDate2 == null ? "" : DealerXDReports.CheckDate2.Value.ToShortDateString();
        }
        #endregion
    }
}
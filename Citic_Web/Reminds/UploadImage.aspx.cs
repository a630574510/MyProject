using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

using FineUI;
namespace Citic_Web.Reminds
{
    public partial class UploadImage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DealerDataBind();
                BankDataBind();
            }
        }

        #region 上传文件--乔春羽(2013.12.23)
        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            if (file_Upload.HasFile)
            {
                string fileName = file_Upload.ShortFileName;

                //得到文件扩展名
                string ext = fileName.Substring(fileName.LastIndexOf(".") + 1);

                //创建文件夹
                string dealerID = this.ddl_Dealer.SelectedValue;
                string bankID = this.ddl_Bank.SelectedValue;
                DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/UploadImage/日查库照片/" + dealerID));
                if (!di.Exists) { di.Create(); }
                di = new DirectoryInfo(Server.MapPath("~/UploadImage/日查库照片/" + dealerID + "/" + bankID));
                if (!di.Exists) { di.Create(); }
                //di = new DirectoryInfo(Server.MapPath("~/UploadImage/日查库照片/" + dealerID + "/" + bankID + "/" + this.CurrentUser.UserName));
                //if (!di.Exists) { di.Create(); }
                //if (!ValidateFileType(fileName))
                //{
                //    Alert.Show("无效的文件类型！");
                //    return;
                //}

                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                fileName = string.Format("{0}_{1}_{2}.{3}", dealerID, bankID, this.ConvertShortDateTimeToUI(DateTime.Now), ext);

                string path = string.Format("{0}\\{1}", di.FullName, fileName);

                file_Upload.SaveAs(path);

                if (File.Exists(path))
                {
                    Alert.Show("上传成功！");
                    if (this.CurrentUser.RoleId == 10)
                    {
                        Logging.WriteLog(string.Format("监管员：{0} 于 {1} 上传一张图片，上传后图片文件名为：{2}", this.CurrentUser.UserName, DateTime.Now, fileName));
                    }
                }

                // 清空
                SimpleForm1.Reset();
            }
        }
        #endregion

        #region 加载经销商--乔春羽(2013.12.23)
        private void DealerDataBind()
        {
            ddl_Dealer.Items.Clear();
            StringBuilder where = new StringBuilder(" 1=1 ");
            //权限过滤
            int roleID = this.CurrentUser.RoleId;
            switch (roleID)
            {
                case 10:    //监管员
                    //根据监管员ID，查询其所监管的经销商
                    where.AppendFormat(" and SupervisorID={0}", this.CurrentUser.RelationID);
                    break;
            }
            DataTable dt = DealerBll.GetList(where.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl_Dealer.DataTextField = "DealerName";
                ddl_Dealer.DataValueField = "DealerID";
                ddl_Dealer.DataSource = dt;
                ddl_Dealer.DataBind();
            }
            AddItemByInsert(ddl_Dealer, "请选择", "-1", 0);
        }
        protected void ddl_Dealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            BankDataBind();
        }
        #endregion

        #region 加载合作行--乔春羽(2013.12.23)
        private void BankDataBind()
        {
            ddl_Bank.Items.Clear();
            string dealerID = this.ddl_Dealer.SelectedValue;
            if (!string.IsNullOrEmpty(dealerID) && dealerID != "-1")
            {
                string where = string.Format(" T.DealerID='{0}' ", dealerID);
                DataTable dt = Dealer_BankBll.GetBanks(where).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    ddl_Bank.DataTextField = "BankName";
                    ddl_Bank.DataValueField = "BankID";
                    ddl_Bank.DataSource = dt;
                    ddl_Bank.DataBind();
                }
            }
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }

        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ddl_Bank.SelectedValue) && this.ddl_Bank.SelectedValue != "-1")
            {
                DataTable dt = Dealer_BankBll.GetBrands(string.Format(" DealerID={0} and BankID='{1}' ", ddl_Dealer.SelectedValue, this.ddl_Bank.SelectedValue)).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.lbl_Brand.Text = dt.Rows[0]["BrandName"].ToString();
                }
            }
        }
        #endregion
    }
}
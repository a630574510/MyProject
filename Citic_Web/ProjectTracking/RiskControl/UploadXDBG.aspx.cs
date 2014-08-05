using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;

using FineUI;
namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class UploadXDBG : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState.Clear();
                dp_Time.SelectedDate = DateTime.Now;
                AddItemByInsert(ddl_Files, "请选择", "-1", 0);
                AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
                AreaDataBind();
            }
        }
        #region Private Fields--乔春羽(2013.12.25)
        /// <summary>
        /// 经销商地址
        /// </summary>
        private string Address
        {
            get { return (string)ViewState["Address"]; }
            set { ViewState["Address"] = value; }
        }
        #endregion

        #region 上传文件--乔春羽(2013.12.23)
        /// <summary>
        /// 验证上传文件的后缀名
        /// </summary>
        /// <param name="ext"></param>
        /// <returns></returns>
        private bool ValidateUpload(string ext)
        {
            return ext.Equals("doc") || ext.Equals("docx");
        }

        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            if (file_Upload.HasFile)
            {
                //控件所去到的文件的名字
                string fileName = file_Upload.ShortFileName;
                //得到文件扩展名
                string ext = fileName.Substring(fileName.LastIndexOf(".") + 1);
                //验证上传的文件是否为word文档
                if (!ValidateUpload(ext))
                {
                    Alert.ShowInTop("文件格式有误，请重新上传Word文档！");
                    // 清空文件上传组件
                    file_Upload.Reset();
                    return;
                }

                //“时间”
                string dateDir = ConvertShortDateTimeToUI(dp_Time.SelectedDate.Value);

                string dealerID = this.txt_Dealer.Text.Split('_')[1];
                string dealerName = this.txt_Dealer.Text.Split('_')[0];
                string bankID = this.ddl_Bank.SelectedValue;
                string bankName = this.ddl_Bank.SelectedText;

                //存放文档的路径，在Web.config中有设置
                string filePath = Common.OperateConfigFile.getValue("xdbg_path");

                //去掉文件名中的特殊字符
                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                //重新设置文件名的格式：用户名_经销商名_合作行名_时间（精确到秒）
                fileName = string.Format("{0}_{1}_{2}_{3}.{4}", this.CurrentUser.UserName, dealerName, bankName, dateDir + DateTime.Now.ToString("HHmmss"), ext);
                //文件的整路径（带文件夹带文件名）
                string path = string.Format("{0}\\{1}", filePath, fileName);
                //开始上传文件
                file_Upload.SaveAs(Server.MapPath(path));
                //如果存在该文件，则表示文件上传成功！
                if (File.Exists(Server.MapPath(path)))
                {
                    int result = 0;
                    //如果选择的是“旧文件修改”，则删除旧文件
                    if (rbl_Type.SelectedValue == "old")
                    {
                        string oldFilePath = string.Format("{0}/{1}", filePath, ddl_Files.SelectedText);
                        if (File.Exists(Server.MapPath(oldFilePath)))
                        {
                            File.Delete(Server.MapPath(oldFilePath));
                        }

                        if (!File.Exists(Server.MapPath(oldFilePath)))
                        {
                            //删除文件成功后，将该数据更新
                            Citic.Model.XDBG model = XDBGBBLL.GetModel(int.Parse(this.ddl_Files.SelectedValue));
                            model.FileName = fileName;
                            model.UpdateID = this.CurrentUser.UserId;
                            model.UpdateName = this.CurrentUser.UserName;
                            model.UpdateTime = DateTime.Now;
                            model.Field1 = string.Empty;
                            model.Field2 = string.Empty;
                            model.Remark = this.txt_Remark.Text;
                            model.TrueName = this.CurrentUser.TrueName;
                            result = XDBGBBLL.UpdateXDBG(model);
                        }
                    }
                    else
                    {
                        //上传成功后，入库一条数据
                        Citic.Model.XDBG model = new Citic.Model.XDBG();
                        model.DealerID = int.Parse(dealerID);
                        model.DealerName = this.txt_Dealer.Text.Split('_')[0];
                        model.BankID = int.Parse(bankID);
                        model.BankName = bankName;
                        model.Address = Address;
                        model.Area = this.ddl_Area.SelectedValue;
                        model.FileName = fileName;
                        model.FilePath = filePath;
                        model.CreateID = this.CurrentUser.UserId;
                        model.CreateName = this.CurrentUser.UserName;
                        model.CreateTime = DateTime.Now;
                        model.InspectTime = this.dp_Time.SelectedDate.Value;
                        model.UpdateID = 0;
                        model.UpdateName = string.Empty;
                        model.UpdateTime = null;
                        model.TrueName = this.CurrentUser.TrueName;
                        model.Field1 = string.Empty;
                        model.Field2 = string.Empty;
                        model.Remark = this.txt_Remark.Text;
                        result = XDBGBBLL.AddXDBG(model);
                    }
                    //首先要文件成功上传，其次是数据入库成功。
                    //二者兼备，才是“文件上传成功！”。
                    if (result > 0)
                    {
                        Alert.Show("上传成功！");
                    }
                }

                // 清空文件上传组件
                file_Upload.Reset();
            }
        }
        #endregion

        #region 选择上传类型，即“新文件上传还是旧文件修改”--乔春羽(2013.12.24)
        protected void rbl_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUploadedFiles();
        }

        /// <summary>
        /// 加载用户已上传了的文件
        /// </summary>
        private void LoadUploadedFiles()
        {
            ddl_Files.Items.Clear();
            if (!string.IsNullOrEmpty(rbl_Type.SelectedValue) && rbl_Type.SelectedValue == "old")
            {
                //加载该用户上传过的文件列表
                string filePath = Common.OperateConfigFile.getValue("xdbg_path");
                int userid = this.CurrentUser.UserId;
                DateTime selectedDate = this.dp_Time.SelectedDate.Value;
                string area = this.ddl_Area.SelectedValue;
                DataTable dt = XDBGBBLL.GetList(string.Format(" CreateID={0} and (InspectTime between '{1}' and '{2}') and Area = '{3}'", userid, selectedDate, selectedDate.AddDays(1), area)).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.ddl_Files.DataTextField = "FileName";
                    //this.ddl_Files.DataValueField = "FileName";
                    this.ddl_Files.DataValueField = "ID";
                    this.ddl_Files.DataSource = dt;
                    this.ddl_Files.DataBind();
                }
            }
            AddItemByInsert(ddl_Files, "请选择", "-1", 0);
        }
        #endregion

        #region 加载银行信息--乔春羽(2013.12.25)
        public void BankDataBind()
        {
            ddl_Bank.Items.Clear();
            string dealerID = this.txt_Dealer.Text.Split('_')[1];
            string where = string.Format(" DealerID='{0}'", dealerID);
            DataTable dt = Dealer_BankBll.GetList(where).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl_Bank.DataTextField = "BankName";
                ddl_Bank.DataValueField = "BankID";
                ddl_Bank.DataSource = dt;
                ddl_Bank.DataBind();
            }
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }
        #endregion

        #region 选择经销商，联动出合作行和该经销商的地址--乔春羽(2013.12.25)
        protected void txt_Dealer_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txt_Dealer.Text) && this.txt_Dealer.Text.IndexOf('_') > 0)
            {
                //查询经销商
                BankDataBind();

                //找地址
                int id = int.Parse(this.txt_Dealer.Text.Split('_')[1]);
                Address = DealerBll.GetModel(id).Address;
            }
        }
        #endregion

        #region 加载区域--乔春羽(2013.12.25)
        public void AreaDataBind()
        {
            ddl_Area.Items.Clear();
            string path = "~/ProjectTracking/RiskControl/区域名称.txt";
            FileStream fs = new FileStream(Server.MapPath(path), FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                string value = sr.ReadLine();
                AddItemByInsert(ddl_Area, value, value, -1);
            }
            sr.Close();
            fs.Close();
            AddItemByInsert(ddl_Area, "请选择", "-1", 0);
            ddl_Area.SelectedIndex = 0;
        }
        #endregion

        #region 选择时间时，也要加载一下用户已上传文件--乔春羽(2013.12.25)
        protected void dp_Time_DateSelect(object sender, EventArgs e)
        {
            if (this.dp_Time.SelectedDate > DateTime.Now) 
            {
                Alert.ShowInTop("日期不能大于今日！");
                return;
            }
            LoadUploadedFiles();
        }
        #endregion

    }
}
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

using FineUI;
using Newtonsoft.Json.Linq;
namespace Citic_Web.ProjectTracking.rcquesbyday
{
    public partial class AddRCQuesByDay : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_Delete_Row.OnClientClick = grid_List.GetNoSelectionAlertReference("请至少选择一项！") + GetDeleteScript();
                //btn_Add_Row.OnClientClick = "checkDealer();" + AddGridRows();

                WCBind();
                AreaBind();
            }
        }

        #region PrivateFields--乔春羽(2013.12.11)
        public DataTable DtSource
        {
            get
            {
                if (ViewState["DtSource"] == null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("WorkContent", typeof(string));
                    dt.Columns.Add("Area", typeof(string));
                    dt.Columns.Add("Checkman", typeof(string));
                    dt.Columns.Add("DealerName", typeof(string));
                    dt.Columns.Add("BankName", typeof(string));
                    dt.Columns.Add("BrandName", typeof(string));
                    dt.Columns.Add("SName", typeof(string));
                    dt.Columns.Add("DescProb", typeof(string));
                    dt.Columns.Add("Result", typeof(string));

                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                }
                return ViewState["DtSource"] as DataTable;
            }
            set
            {
                ViewState["DtSource"] = value;
            }
        }
        /// <summary>
        /// 监管员ID
        /// </summary>
        private int SID
        {
            get { return (int)ViewState["SID"]; }
            set { ViewState["SID"] = value; }
        }
        /// <summary>
        /// 监管员名
        /// </summary>
        private string SName
        {
            get { return ViewState["SName"].ToString(); }
            set { ViewState["SName"] = value; }
        }
        private int BrandID
        {
            get { return (int)ViewState["BrandID"]; }
            set { ViewState["BrandID"] = value; }
        }
        private string BrandName
        {
            get { return ViewState["BrandName"].ToString(); }
            set { ViewState["BrandName"] = value; }
        }
        #endregion

        #region 添加Grid行
        /// <summary>
        /// 添加Grid行
        /// </summary>
        /// <returns></returns>
        private string AddGridRows()
        {
            string GridRowsStr = string.Empty;
            JObject o = new JObject();
            o.Add("WorkContent", string.Empty);
            o.Add("Area", string.Empty);
            o.Add("Checkman", string.Empty);
            o.Add("DealerName", string.Empty);
            o.Add("BankName", string.Empty);
            o.Add("BrandName", string.Empty);
            o.Add("SName", string.Empty);
            o.Add("DescProb", string.Empty);
            o.Add("Result", string.Empty);
            return GridRowsStr = grid_List.GetAddNewRecordReference(o, true);
        }
        #endregion

        #region 删除选中行的脚本--乔春羽(2013.12.9)
        /// <summary>
        /// 删除选中行的脚本
        /// </summary>
        /// <returns></returns>
        private string GetDeleteScript()
        {
            return Confirm.GetShowReference("删除选中行？", String.Empty, MessageBoxIcon.Question, grid_List.GetDeleteSelectedReference(), String.Empty);
        }
        #endregion

        #region 添加数据--乔春羽(2013.12.10)
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            //Dictionary<int, Dictionary<string, string>> modifiedDict = grid_List.GetModifiedDict();
            List<Dictionary<string, string>> modifiedDict = grid_List.GetNewAddedList();
            List<Citic.Model.RiskQuesDay> models = new List<Citic.Model.RiskQuesDay>();
            foreach (Dictionary<string, string> row in modifiedDict)
            {
                int bankID = int.Parse(this.ddl_Bank.SelectedValue);
                //int bankID = int.Parse(row["BankName"].Split('_')[1]);
                string bankName = row["BankName"];
                int dealerID = int.Parse(row["DealerName"].Split('_')[1]);
                string dealerName = row["DealerName"].Split('_')[0];
                int brandID = int.Parse(row["BrandName"].Split('_')[1]);
                string brandName = row["BrandName"].Split('_')[0];
                models.Add(new Citic.Model.RiskQuesDay()
                {
                    Area = row["Area"],
                    BankID = bankID,
                    BankName = bankName,
                    BrandID = brandID,
                    BrandName = brandName,
                    Checkman = row["Checkman"],
                    CreateID = this.CurrentUser.UserId,
                    CreateTime = DateTime.Now,
                    DealerID = dealerID,
                    DealerName = dealerName,
                    DescProb = row["DescProb"],
                    WorkContent = row["WorkContent"],
                    SID = SID,
                    SName = row["SName"],
                    Result = row["Result"],
                    Status = 0
                });
            }

            int num = RQDBLL.AddRange(models.ToArray());
            if (num > 0)
            {
                AlertShowInTop("添加成功！");
                //List<Dictionary<string, string>> list = grid_List.GetNewAddedList();
                //for (int i = 0, count = list.Count; i < count; count--)
                //{
                //    int[] ids = grid_List.SelectedRowIndexArray;
                //    grid_List.DeleteSelected();
                //}
                grid_List.ClearSelections();
                grid_List.Rows.Clear();
            }
            else
            {
                AlertShowInTop("添加失败！");
            }
        }
        #endregion

        #region 加载工作内容--乔春羽(2013.8.21)
        private void WCBind()
        {
            ddl_WorkContent.Items.Clear();
            string path = "~/ProjectTracking/RiskControl/工作内容.txt";
            FileStream fs = new FileStream(Server.MapPath(path), FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                string value = sr.ReadLine();
                AddItemByInsert(ddl_WorkContent, value, value, -1);
            }
            sr.Close();
            fs.Close();
            AddItemByInsert(ddl_WorkContent, "请选择", "-1", 0);
            ddl_WorkContent.SelectedIndex = 0;
        }
        #endregion

        #region 加载区域名称--乔春羽(2013.8.21)
        private void AreaBind()
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

        #region Grid表格被修改之后--乔春羽(2013.12.11)
        protected void grid_List_AfterEdit(object sender, GridAfterEditEventArgs e)
        {
            //List<Dictionary<string, string>> newAddDict = grid_List.GetNewAddedList();
            //if (newAddDict != null && newAddDict.Count > 0)
            //{
            //    if (e.ColumnID.Equals("BankName"))
            //    {
            //        string value = newAddDict[e.RowIndex][e.ColumnID].ToString();
            //        if (value.IndexOf("_") > 0)
            //        {
            //            int bankID = int.Parse(value.Split('_')[1]);
            //            int dealerID = int.Parse(newAddDict[e.RowIndex]["DealerName"].Split('_')[1]);
            //            string sql = string.Format("SELECT BrandName+'_'+Cast(BrandID as NVARCHAR) BrandName FROM tb_Dealer_Bank_List WHERE DealerID={0} and BankID={1}", dealerID, bankID);

            //            DataTable dt = Dealer_BankBll.Query(sql);
            //            if (dt != null && dt.Rows.Count > 0)
            //            {
            //                txt_BrandName.Text = dt.Rows[0][0].ToString();
            //            }
            //        }
            //        else
            //        {
            //            this.txt_BrandName.Text = string.Empty;
            //        }
            //    }
            //}
        }
        #endregion

        #region 选择经销商，同时加载出合作行、监管员--乔春羽(2013.12.11)
        protected void txt_Dealer_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txt_Dealer.Text) && this.txt_Dealer.Text.IndexOf('_') >= 0)
            {
                int dealerID = int.Parse(this.txt_Dealer.Text.Split('_')[1]);
                string dealerName = this.txt_Dealer.Text.Split('_')[0];

                //取到监管员
                Citic.Model.Dealer model = DealerBll.GetModel(dealerID);
                SName = model.SupervisorName;
                SID = model.SupervisorID.Value;

                //取到合作行
                //string sql = "SELECT BankName+'_'+Cast(BankID AS NVARCHAR) BankName FROM tb_Dealer_Bank_List";
                string sql = "SELECT BankID,BankName FROM tb_Dealer_Bank_List";
                string where = string.Format(" WHERE DealerID={0}", dealerID);
                DataTable dt = Dealer_BankBll.Query(sql + where);
                ddl_Bank.Items.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    ddl_Bank.DataTextField = "BankName";
                    ddl_Bank.DataValueField = "BankID";
                    ddl_Bank.DataSource = dt;
                    ddl_Bank.DataBind();
                }
                AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
            }
        }
        #endregion

        #region 添加行--乔春羽(2013.12.11)
        protected void btn_Add_Row_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_Dealer.Text))
            {
                AlertShowInTop("请选择经销商！");
                return;
            }

            JObject o = new JObject();
            o.Add("WorkContent", string.Empty);
            o.Add("Area", string.Empty);
            o.Add("Checkman", string.Empty);
            o.Add("DealerName", this.txt_Dealer.Text);
            o.Add("BankName", this.ddl_Bank.SelectedText);
            o.Add("BrandName", this.hf_BrandName.Text);
            o.Add("SName", SName);
            o.Add("DescProb", string.Empty);
            o.Add("Result", string.Empty);
            grid_List.AddNewRecord(o);
        }
        #endregion

        #region 选择合作行之后，查询出品牌--乔春羽(2014.2.20)
        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = this.txt_Dealer.Text;
            int bankID = int.Parse(this.ddl_Bank.SelectedValue);
            if (!string.IsNullOrEmpty(val) && bankID != -1)
            {
                int dealerID = int.Parse(this.txt_Dealer.Text.Split('_')[1]);
                if (val.IndexOf("_") > 0)
                {
                    string sql = string.Format("SELECT BrandName+'_'+Cast(BrandID as NVARCHAR) BrandName FROM tb_Dealer_Bank_List WHERE DealerID={0} and BankID={1}", dealerID, bankID);

                    DataTable dt = Dealer_BankBll.Query(sql);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        this.hf_BrandName.Text = dt.Rows[0][0].ToString();
                    }
                }
                else
                {
                    BrandName = string.Empty;
                }
            }
        }
        #endregion
    }
}
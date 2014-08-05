using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using FineUI;
using Newtonsoft.Json.Linq;

namespace Citic_Web.ProjectTracking.RiskProblem
{
    public partial class AddRiskQuestion : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //删除行
                btn_Delete_Table.OnClientClick = grid_List.GetNoSelectionAlertReference("请至少选择一项！") + GetDeleteScript();
                btn_Add.OnClientClick = grid_List.GetNoSelectionAlertReference("没有数据！");
                //添加行
                //btn_Add_Table.OnClientClick = AddGridRows();
                AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
                AddItemByInsert(ddl_Brand, "请选择", "-1", 0);
            }
        }

        #region 添加Grid行
        /// <summary>
        /// 添加Grid行
        /// </summary>
        private string AddGridRows()
        {
            string dealerVal = this.txt_Dealer.Text;
            string bankVal = this.ddl_Bank.SelectedText;
            string brandVal = this.ddl_Brand.SelectedText;
            if (!string.IsNullOrEmpty(dealerVal) && dealerVal.IndexOf('_') <= 0)
            {
                AlertShow("请重新填写经销商！");
                return string.Empty;
            }
            if (bankVal != null && bankVal.Equals("请选择"))
            {
                AlertShow("请选择合作行！");
                return string.Empty;
            }
            if (brandVal != null && brandVal.Equals("请选择"))
            {
                brandVal = string.Empty;
            }

            dealerVal = dealerVal.Split('_')[0];
            string GridRowsStr = string.Empty;
            JObject o = new JObject();
            o.Add("C_Date", DateTime.Now.ToString("yyyy-MM-dd"));
            o.Add("C_AP", string.Empty);
            o.Add("C_Unit", string.Empty);
            o.Add("C_P", string.Empty);
            o.Add("C_Post", string.Empty);
            o.Add("C_PPhone", string.Empty);
            o.Add("C_Content", string.Empty);
            o.Add("SQ_Shop", dealerVal);
            o.Add("SQ_Bank", bankVal);
            o.Add("SQ_Brand", brandVal);
            o.Add("SQ_Content", string.Empty);
            GridRowsStr = grid_List.GetAddNewRecordReference(o, true);
            return GridRowsStr;
        }
        #endregion

        #region 添加数据--乔春羽(2013.12.9)
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            //监管的品牌，监管员的姓名以及联系方式，需要内联出来。
            //Dictionary<int, Dictionary<string, string>> modifiedDict = grid_List.GetModifiedDict();
            List<Dictionary<string, string>> modifiedDict = grid_List.GetNewAddedList();

            List<Citic.Model.RisksSolveDocuments> models = new List<Citic.Model.RisksSolveDocuments>();
            //foreach (DataRow row in DtSource.Rows)
            foreach (Dictionary<string, string> row in modifiedDict)
            {
                //根据经销商的ID，取出与该经销商合作的品牌监管员。
                //先获取品牌
                string dealerName = row["SQ_Shop"];
                string dealerID = row["SQ_ShopID"];
                string brandID = row["SQ_BrandID"];
                string brandName = row["SQ_Brand"];
                string sq_Name = string.Empty;
                string sq_Phone = string.Empty;

                Citic.Model.RisksSolveDocuments model = new Citic.Model.RisksSolveDocuments()
                {
                    C_AP = row["C_AP"].ToString(),
                    C_Content = row["C_Content"].ToString(),
                    C_Date = Convert.ToDateTime(row["C_Date"]),
                    C_P = row["C_P"].ToString(),
                    C_Post = row["C_Post"].ToString(),
                    C_PPhone = row["C_PPhone"].ToString(),
                    C_Unit = row["C_Unit"].ToString(),
                    CreateID = this.CurrentUser.UserId,
                    SQ_Brand = brandName,
                    SQ_BrandID = int.Parse(brandID),
                    SQ_Content = row["SQ_Content"].ToString(),
                    SQ_FBP = this.CurrentUser.UserName,
                    SQ_FBPP = this.CurrentUser.MobileNo,
                    SQ_Name = sq_Name,
                    SQ_Phone = sq_Phone,
                    SQ_Shop = dealerName,
                    SQ_ShopID = int.Parse(dealerID),
                    SQ_Bank = row["SQ_Bank"],
                    SQ_BankID = int.Parse(row["SQ_BankID"])
                };
                model.Status = 0;
                models.Add(model);
            }

            int num = this.RSDBLL.AddRange(models.ToArray());

            if (num > 0)
            {
                AlertShowInTop("添加成功！");
                PageContext.Refresh();
            }
            else
            {
                AlertShow("添加失败！");
            }
        }
        #endregion

        #region 删除选中行的脚本--乔春羽(2013.12.9)
        //删除选中行的脚本
        private string GetDeleteScript()
        {
            return Confirm.GetShowReference("删除选中行？", String.Empty, MessageBoxIcon.Question, grid_List.GetDeleteSelectedReference(), String.Empty);
        }
        #endregion

        #region 选择合作行之后，加载品牌--乔春羽(2014.4.22)
        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dealerVal = this.txt_Dealer.Text;
            if (!string.IsNullOrEmpty(dealerVal) && dealerVal.IndexOf('_') > 0)
            {
                ddl_Brand.Items.Clear();
                string dealerName = dealerVal.Split('_')[0];
                string dealerID = dealerVal.Split('_')[1];
                string bankID = this.ddl_Bank.SelectedValue;
                DataTable dt = this.Dealer_BankBll.GetList(string.Format(" (A.DealerID = '{0}' or A.DealerName like '%{1}%') and A.BankID = '{2}' ", dealerID, dealerName, bankID)).Tables[0];
                this.ddl_Brand.DataTextField = "BrandName";
                this.ddl_Brand.DataValueField = "BrandID";
                this.ddl_Brand.DataSource = dt;
                this.ddl_Brand.DataBind();

                AddItemByInsert(ddl_Brand, "请选择", "-1", 0);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ddl_Brand.SelectedIndex = 1;
                }
            }
            else
            {
                AddItemByInsert(ddl_Brand, "请选择", "-1", 0);
            }
        }
        #endregion

        #region 输入经销商之后，加载合作行信息--乔春羽(2014.4.22)
        protected void txt_Dealer_TextChanged(object sender, EventArgs e)
        {
            ddl_Bank.Items.Clear();
            string val = this.txt_Dealer.Text;
            if (!string.IsNullOrEmpty(val) && val.IndexOf('_') > 0)
            {
                string dealerName = val.Split('_')[0];
                string dealerID = val.Split('_')[1];
                DataTable dt = this.Dealer_BankBll.GetList(string.Format(" A.DealerID = '{0}' or A.DealerName like '%{1}%' ", dealerID, dealerName)).Tables[0];
                ddl_Bank.DataTextField = "BankName";
                ddl_Bank.DataValueField = "BankID";
                ddl_Bank.DataSource = dt;
                ddl_Bank.DataBind();
            }
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }
        #endregion

        #region 添加Grid行--乔春羽(2014.4.22)
        protected void btn_Add_Table_Click(object sender, EventArgs e)
        {
            string dealerVal = this.txt_Dealer.Text;
            string bankName = this.ddl_Bank.SelectedText;
            string bankID = this.ddl_Bank.SelectedValue;
            string brandName = this.ddl_Brand.SelectedText;
            string brandID = this.ddl_Brand.SelectedValue;
            string dealerName = dealerVal.Split('_')[0];
            string dealerID = dealerVal.Split('_')[1];

            string GridRowsStr = string.Empty;
            JObject o = new JObject();
            o.Add("C_Date", DateTime.Now.ToString("yyyy-MM-dd"));
            o.Add("C_AP", string.Empty);
            o.Add("C_Unit", string.Empty);
            o.Add("C_P", string.Empty);
            o.Add("C_Post", string.Empty);
            o.Add("C_PPhone", string.Empty);
            o.Add("C_Content", string.Empty);
            o.Add("SQ_Shop", dealerName);
            o.Add("SQ_ShopID", dealerID);
            o.Add("SQ_Bank", bankName);
            o.Add("SQ_BankID", bankID);
            o.Add("SQ_Brand", brandName);
            o.Add("SQ_BrandID", brandID);
            o.Add("SQ_Content", string.Empty);

            grid_List.AddNewRecord(o);
        }
        #endregion
    }
}
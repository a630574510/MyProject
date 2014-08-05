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
                //添加行
                btn_Add_Table.OnClientClick = AddGridRows() + "; Init()";
            }
        }

        #region PrivateFields--乔春羽(2013.12.9)
        public DataTable DtSource
        {
            get
            {
                if (ViewState["DtSource"] == null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CC_Date", typeof(DateTime));
                    dt.Columns.Add("CC_AP", typeof(String));
                    dt.Columns.Add("CC_Unit", typeof(String));
                    dt.Columns.Add("CC_P", typeof(String));
                    dt.Columns.Add("CC_Post", typeof(String));
                    dt.Columns.Add("CC_PPhone", typeof(String));
                    dt.Columns.Add("CC_Content", typeof(String));
                    dt.Columns.Add("SQ_Shop", typeof(String));
                    dt.Columns.Add("SQ_Brand", typeof(String));
                    dt.Columns.Add("SQ_Name", typeof(String));
                    dt.Columns.Add("SQ_Phone", typeof(String));
                    dt.Columns.Add("SQ_FBP", typeof(String));
                    dt.Columns.Add("SQ_FBPP", typeof(String));
                    dt.Columns.Add("SQ_Content", typeof(String));
                    dt.Columns.Add("S_P", typeof(String));
                    dt.Columns.Add("S_Phone", typeof(String));
                    dt.Columns.Add("S_Result", typeof(String));
                    dt.Columns.Add("GD", typeof(String));
                    dt.Columns.Add("WTCLBF", typeof(String));
                    dt.Columns.Add("FXWTBMQZ", typeof(String));
                    dt.Columns.Add("QCJRZXYJ", typeof(String));

                    dt.Columns.Add("QCJRZXQZ", typeof(String));
                    dt.Columns.Add("GLZXYJ", typeof(String));
                    dt.Columns.Add("GLZXQZ", typeof(String));
                    ViewState["DtSource"] = dt;
                }
                return ViewState["DtSource"] as DataTable;
            }
            set { ViewState["DtSource"] = value; }
        }
        #endregion

        #region 添加Grid行
        /// <summary>
        /// 添加Grid行
        /// </summary>
        private string AddGridRows()
        {
            string GridRowsStr = string.Empty;
            JObject o = new JObject();
            o.Add("CC_Date", DateTime.Now.ToString("yyyy-MM-dd"));
            o.Add("CC_AP", string.Empty);
            o.Add("CC_Unit", string.Empty);
            o.Add("CC_P", string.Empty);
            o.Add("CC_Post", string.Empty);
            o.Add("CC_PPhone", string.Empty);
            o.Add("CC_Content", string.Empty);
            o.Add("SQ_Shop", string.Empty);
            o.Add("SQ_Content", string.Empty);
            o.Add("S_P", string.Empty);
            o.Add("S_Result", string.Empty);
            o.Add("GD", string.Empty);
            return GridRowsStr = grid_List.GetAddNewRecordReference(o, true);
        }
        #endregion

        protected void btn_Checking_Car_Click(object sender, EventArgs e)
        {

        }

        #region 添加数据--乔春羽(2013.12.9)
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            //监管的品牌，监管员的姓名以及联系方式，需要内联出来。
            //Dictionary<int, Dictionary<string, string>> modifiedDict = grid_List.GetModifiedDict();
            List<Dictionary<string, string>> modifiedDict = grid_List.GetNewAddedList();

            //foreach (int rowIndex in modifiedDict.Keys)
            //{
            //    int rowID = Convert.ToInt32(grid_List.DataKeys[rowIndex][0]);
            //    DataRow row = FindRowByID(rowID);

            //    Dictionary<string, string> dict = modifiedDict[rowIndex];
            //    //CC_Date 投诉时间
            //    if (dict.ContainsKey("CC_Date"))
            //    {
            //        row["CC_Date"] = Convert.ToDateTime(dict["CC_Date"]);
            //    }
            //    //CC_AP 投诉接收人
            //    if (dict.ContainsKey("CC_AP"))
            //    {
            //        row["CC_AP"] = dict["CC_AP"];
            //    }
            //    //CC_Unit 投诉单位
            //    if (dict.ContainsKey("CC_Unit"))
            //    {
            //        row["CC_Unit"] = dict["CC_Unit"];
            //    }
            //    //CC_P 投诉人
            //    if (dict.ContainsKey("CC_P"))
            //    {
            //        row["CC_P"] = dict["CC_P"];
            //    }
            //    //CC_Post 投诉人职务
            //    if (dict.ContainsKey("CC_Post"))
            //    {
            //        row["CC_Post"] = dict["CC_Post"];
            //    }
            //    //CC_PPhone 投诉人联系方式
            //    if (dict.ContainsKey("CC_PPhone"))
            //    {
            //        row["CC_PPhone"] = dict["CC_PPhone"];
            //    }
            //    //CC_Content 投诉内容
            //    if (dict.ContainsKey("CC_Content"))
            //    {
            //        row["CC_Content"] = dict["CC_Content"];
            //    }
            //    //SQ_Shop 监管店
            //    if (dict.ContainsKey("SQ_Shop"))
            //    {
            //        row["SQ_Shop"] = dict["SQ_Shop"];
            //    }
            //    string dealerName = dict["SQ_Shop"].ToString().Split('_')[0];
            //    string dealerID = dict["SQ_Shop"].ToString().Split('_')[1];
            //    row["SQ_ShopID"] = dealerID;
            //    //SQ_Content 问题描述
            //    if (dict.ContainsKey("SQ_Content"))
            //    {
            //        row["SQ_Content"] = dict["SQ_Content"];
            //    }
            //    //S_P 调查人
            //    if (dict.ContainsKey("S_P"))
            //    {
            //        row["S_P"] = dict["S_P"];
            //    }
            //    //S_Result 调查结果
            //    if (dict.ContainsKey("S_Result"))
            //    {
            //        row["S_Result"] = dict["S_Result"];
            //    }
            //    //GD 违反的规定
            //    if (dict.ContainsKey("GD"))
            //    {
            //        row["GD"] = dict["GD"];
            //    }

            //    //根据经销商的ID，取出与该经销商合作的品牌监管员。
            //    //先获取品牌
            //    string path = Common.OperateConfigFile.getValue("Dealer_Bank");
            //    DataTable dt_Data = Dealer_BankBll.GetList(1, string.Format(" DealerID={0}", dealerID), string.Empty, "BrandID", "BrandName").Tables[0];
            //    if (dt_Data != null && dt_Data.Rows.Count > 0)
            //    {
            //        row["SQ_BrandID"] = Convert.ToInt32(dt_Data.Rows[0]["BrandID"]);
            //        row["SQ_Brand"] = dt_Data.Rows[0]["BrandName"].ToString();
            //    }
            //    //再获取监管员的信息
            //    string where = string.Format(" DealerID={0}", dealerID);
            //    dt_Data = DealerBll.QuerySqlCommand(Server.MapPath(path), "RQ", where);
            //    if (dt_Data != null && dt_Data.Rows.Count > 0)
            //    {
            //        row["SQ_Name"] = dt_Data.Rows[0]["SupervisorName"].ToString();
            //        row["SQ_Phone"] = dt_Data.Rows[0]["LinkPhone"].ToString();
            //    }
            //    //问题反馈人员为当前登录用户
            //    row["SQ_FBP"] = this.CurrentUser.UserName;
            //    row["SQ_FBPP"] = this.CurrentUser.MobileNo;
            //}

            List<Citic.Model.RiskQuestion> models = new List<Citic.Model.RiskQuestion>();
            //foreach (DataRow row in DtSource.Rows)
            foreach (Dictionary<string, string> row in modifiedDict)
            {
                //根据经销商的ID，取出与该经销商合作的品牌监管员。
                //先获取品牌
                string dealerName = row["SQ_Shop"].ToString().Split('_')[0];
                string dealerID = row["SQ_Shop"].ToString().Split('_')[1];
                int brandID = 0;
                string brandName = string.Empty;
                string sq_Name = string.Empty;
                string sq_Phone = string.Empty;
                string path = Common.OperateConfigFile.getValue("Dealer_Bank");
                DataTable dt_Data = Dealer_BankBll.GetList(1, string.Format(" DealerID={0}", dealerID), string.Empty, "BrandID", "BrandName").Tables[0];
                if (dt_Data != null && dt_Data.Rows.Count > 0)
                {
                    brandID = Convert.ToInt32(dt_Data.Rows[0]["BrandID"]);
                    brandName = dt_Data.Rows[0]["BrandName"].ToString();
                }
                //再获取监管员的信息
                string where = string.Format(" DealerID={0}", dealerID);
                dt_Data = DealerBll.QuerySqlCommand(Server.MapPath(path), "RQ", where);
                if (dt_Data != null && dt_Data.Rows.Count > 0)
                {
                    sq_Name = dt_Data.Rows[0]["SupervisorName"].ToString();
                    sq_Phone = dt_Data.Rows[0]["LinkPhone"].ToString();
                }
                Citic.Model.RiskQuestion model = new Citic.Model.RiskQuestion()
                {
                    CC_AP = row["CC_AP"].ToString(),
                    CC_Content = row["CC_Content"].ToString(),
                    CC_Date = Convert.ToDateTime(row["CC_Date"]),
                    CC_P = row["CC_P"].ToString(),
                    CC_Post = row["CC_Post"].ToString(),
                    CC_PPhone = row["CC_PPhone"].ToString(),
                    CC_Unit = row["CC_Unit"].ToString(),
                    CreateID = this.CurrentUser.UserId,
                    CreateTime = DateTime.Now,
                    SQ_Brand = brandName,
                    SQ_BrandID = brandID,
                    SQ_Content = row["SQ_Content"].ToString(),
                    SQ_FBP = this.CurrentUser.UserName,
                    SQ_FBPP = this.CurrentUser.MobileNo,
                    SQ_Name = sq_Name,
                    SQ_Phone = sq_Phone,
                    SQ_Shop = dealerName,
                    SQ_ShopID = int.Parse(dealerID),
                    S_P = row["S_P"].ToString(),
                    S_Result = row["S_Result"].ToString(),
                    GD = row["GD"].ToString()
                };
                models.Add(model);
            }

            int num = RQBLL.AddRange(models.ToArray());
            if (num > 0)
            {
                Alert.ShowInTop("添加成功！");
                ViewState["DtSource"] = null;
                grid_List.SelectAllRows();
                grid_List.DeleteSelected();
            }
            else
            {
                Alert.ShowInTop("添加失败！");
            }
        }

        private DataRow FindRowByID(int rowID)
        {
            foreach (DataRow row in DtSource.Rows)
            {
                if (Convert.ToInt32(row["ID"]) == rowID)
                {
                    return row;
                }
            }
            return null;
        }
        #endregion

        #region 删除选中行的脚本--乔春羽(2013.12.9)
        //删除选中行的脚本
        private string GetDeleteScript()
        {
            return Confirm.GetShowReference("删除选中行？", String.Empty, MessageBoxIcon.Question, grid_List.GetDeleteSelectedReference(), String.Empty);
        }
        #endregion

    }
}
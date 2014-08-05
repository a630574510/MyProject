using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

using FineUI;

namespace Citic_Web.FinanceInfo
{
    public partial class ImportDrafts : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //加载银行信息
                BankDataBind();
                //加载企业信息
                DealerDataBind();
            }
        }
        private static readonly string Draft_List = "DraftList";
        #region 选择Excel文件--乔春羽
        protected void file_Upload_FileSelected(object sender, EventArgs e)
        {
            string excel_Upload_Path = ConfigurationManager.AppSettings["draft_Upload_Path"].ToString();
            if (ddl_Bank.SelectedValue == null || ddl_Bank.SelectedValue == "0")
            {
                Alert.ShowInTop("请选择合作行！");
                file_Upload.Reset();
                return;
            }
            if (ddl_Dealer.SelectedValue == null || ddl_Dealer.SelectedValue == "0")
            {
                Alert.ShowInTop("请选择经销商！");
                file_Upload.Reset();
                return;
            }
            if (file_Upload.HasFile)
            {
                //string FileName = file_Upload.ShortFileName;
                //string path = Server.MapPath(excel_Upload_Path + "/" + FileName.Split('.')[0] + "_" + DateTime.Now.ToString("yyyymmddhhMMss") + "." + FileName.Split('.')[1]);
                //file_Upload.SaveAs(path);
                //DataTable ds = ExcelToDS(path);
                //this.Grid1.DataSource = ds;
                //this.Grid1.DataBind();

                if (file_Upload.HasFile)     //判断是否有文件
                {
                    ViewState.Remove(Draft_List);
                    //判断是否是excle后缀名
                    if (file_Upload.ShortFileName.Split('.')[1].ToString() == "xlsx" || file_Upload.ShortFileName.Split('.')[1].ToString() == "xls")
                    {
                        //获取文件名称
                        string FileName = DateTime.Now.ToString("yyyyMMdd_HHmmss_") + file_Upload.ShortFileName;
                        //将文件名称保存在服务器上
                        file_Upload.SaveAs(Server.MapPath("~/UpExcel/导入数据库的汇票信息/" + FileName));
                        //取得服务器上文件并解析返回ViewState
                        ViewState[Draft_List] = ExcelToDS(Server.MapPath("~/UpExcel/导入数据库的汇票信息/" + FileName));
                        this.Grid1.DataSource = (DataTable)ViewState[Draft_List];
                        this.Grid1.DataBind();
                        file_Upload.Reset();
                    }
                    else
                    {
                        FineUI.Alert.ShowInTop("文件格式不正确！", FineUI.MessageBoxIcon.Error);
                        file_Upload.Reset();
                    }
                }
            }


        }
        #region 解析Excel文件
        /// <summary>
        /// 按照指定格式解析文件
        /// </summary>
        /// <param name="Path">传入文件路径</param>
        /// <returns></returns>
        public DataTable ExcelToDS(string Path)
        {
            //excle连接
            string strConn1 = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + Path + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn1);
            try
            {
                conn.Open();
                DataSet ds = new DataSet();
                DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);   //获取excle表格里面工作表名称
                string strExcel = "select * from [" + schemaTable.Rows[0]["TABLE_NAME"].ToString() + "]";
                //string strExcel = "select * from [" + schemaTable.Rows[0]["TABLE_NAME"].ToString() + "] where [F2] is not null";
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn1);
                myCommand.Fill(ds);

                ds.Tables[0].Columns[0].ColumnName = "ID1";           //合作行
                ds.Tables[0].Columns[1].ColumnName = "Id2";       //经销商名称
                ds.Tables[0].Columns[2].ColumnName = "PledgeNo";           //承兑汇票协议号/质押号
                ds.Tables[0].Columns[3].ColumnName = "GuaranteeNo";       //保证金帐号
                ds.Tables[0].Columns[4].ColumnName = "Ratio";        //保证金比例
                ds.Tables[0].Columns[5].ColumnName = "DraftNo";    //汇票号
                ds.Tables[0].Columns[6].ColumnName = "BeginTime";       //开票日
                ds.Tables[0].Columns[7].ColumnName = "EndTime";        //到期日
                ds.Tables[0].Columns[8].ColumnName = "DarftMoney";             //票面金额

                return ds.Tables[0];
            }
            catch
            {
                FineUI.Alert.ShowInTop("无法解析！");

            }
            finally
            {
                conn.Close();
            }
            return new DataTable();

        }
        #endregion
        //public DataTable ExcelToDS(string path)
        //{
        //    ExcelEditHelper excel = new ExcelEditHelper();
        //    string[] tableNames = excel.GetDataFromExcelWithAppointSheetName(path);
        //    excel.Open(path);
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        string strConn1 = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + path + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
        //        OleDbConnection conn = new OleDbConnection(strConn1);
        //        conn.Open();
        //        string strExcel = "";
        //        OleDbDataAdapter myCommand = null;
        //        strExcel = "select * from [" + tableNames[0] + "$]";
        //        myCommand = new OleDbDataAdapter(strExcel, strConn1);
        //        myCommand.Fill(dt);
        //        //dt = excel.Excel2DataTable(tableNames[0]);
        //        for (int i = 0; i < dt.Columns.Count; i++)
        //        {
        //            DataColumn dc = dt.Columns[i];
        //            switch (dc.ColumnName)
        //            {
        //                case "保证金帐号":
        //                    dc.ColumnName = "GuaranteeNo";
        //                    break;
        //                case "保证金比例":
        //                    dc.ColumnName = "Ratio";
        //                    break;
        //                case "承兑汇票协议号/质押号":
        //                    dc.ColumnName = "PledgeNo";
        //                    break;
        //                case "票号":
        //                    dc.ColumnName = "DraftNo";
        //                    break;
        //                case "开票日":
        //                    dc.ColumnName = "BeginTime";
        //                    break;
        //                case "到期日":
        //                    dc.ColumnName = "EndTime";
        //                    break;
        //                case "票面金额":
        //                    dc.ColumnName = "DarftMoney";
        //                    break;
        //            }
        //        }
        //        ViewState["dt"] = dt;
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}
        #endregion

        #region 绑定数据--乔春羽
        private void GridBind()
        {
            if (ViewState[Draft_List] != null)
            {
                Grid1.DataSource = ViewState[Draft_List] as DataTable;
                Grid1.DataBind();
            }
        }
        #endregion

        #region 保存修改后的数据--乔春羽
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (Grid1.Rows.Count > 0)
            {
                foreach (GridRow gr in Grid1.Rows)
                {
                    if (gr.Values[1] == string.Empty)
                    {
                        //Alert.ShowInTop(string.Format("请填写第{0}行的保证金比例", (gr.RowIndex + 1)));
                        Alert.ShowInTop("请填写保证金比例！");
                        return;
                    }
                }

                Dictionary<int, Dictionary<string, string>> modifiedDict = Grid1.GetModifiedDict();

                // 更新数据源
                DataTable table = ViewState[Draft_List] as DataTable;
                for (int i = 0, count = Grid1.Rows.Count; i < count; i++)
                {
                    if (modifiedDict.ContainsKey(i))
                    {
                        Dictionary<string, string> rowDict = modifiedDict[i];


                        DataRow rowData = table.Rows[i];

                        if (rowDict.ContainsKey("GuaranteeNo"))
                        {
                            rowData["GuaranteeNo"] = rowDict["GuaranteeNo"];
                        }

                        if (rowDict.ContainsKey("EngineNo"))
                        {
                            rowData["EngineNo"] = rowDict["EngineNo"];
                        }

                        if (rowDict.ContainsKey("Ratio"))
                        {
                            rowData["Ratio"] = rowDict["Ratio"];
                        }

                        if (rowDict.ContainsKey("PledgeNo"))
                        {
                            rowData["PledgeNo"] = rowDict["PledgeNo"];
                        }

                        if (rowDict.ContainsKey("DraftNo"))
                        {
                            rowData["DraftNo"] = rowDict["DraftNo"];
                        }
                        if (rowDict.ContainsKey("BeginTime"))
                        {
                            rowData["BeginTime"] = Convert.ToDateTime(rowDict["BeginTime"]).ToShortDateString();
                        }
                        if (rowDict.ContainsKey("EndTime"))
                        {
                            rowData["EndTime"] = Convert.ToDateTime(rowDict["EndTime"]).ToShortDateString();
                        }
                        if (rowDict.ContainsKey("DarftMoney"))
                        {
                            rowData["DarftMoney"] = Convert.ToDecimal(rowDict["DarftMoney"]);
                        }
                    }
                }
                //GridBind();
                Save();
            }
        }
        #endregion

        #region 保存数据到数据库里--乔春羽
        private void Save()
        {
            DataTable dt = null;
            if (ViewState[Draft_List] != null)
            {
                dt = ViewState[Draft_List] as DataTable;
            }
            List<Citic.Model.Draft> drafts = new List<Citic.Model.Draft>();
            List<string> nos = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                if (!ValidateRowIsNull(row))
                {
                    Citic.Model.Draft model = new Citic.Model.Draft()
                    {
                        BankName = ddl_Bank.SelectedItem.Text,
                        BeginTime = Convert.ToDateTime(row["BeginTime"]),
                        CreateID = this.CurrentUser.UserId,
                        CreateTime = DateTime.Now,
                        DarftMoney = row["DarftMoney"].ToString(),
                        DealerName = ddl_Dealer.SelectedItem.Text,
                        DraftType = true,
                        GuaranteeNo = row["GuaranteeNo"].ToString(),
                        DraftNo = row["DraftNo"].ToString(),
                        EndTime = Convert.ToDateTime(row["EndTime"]),
                        PledgeNo = row["PledgeNo"].ToString(),
                        //保证金比例在这里先给一个默认值
                        Ratio = Convert.ToDecimal(row["Ratio"]),
                        //汇款金额与敞口金额需要公式计算
                        HKMoney = 0,
                        CKMoney = 0,
                        CarAllCount = 0,
                        CarAllMoney = 0,
                        CarILCount = 0,
                        CarILMoney = 0,
                        CarITCount = 0,
                        CarITMoney = 0,
                        CarMoveCount = 0,
                        CarMoveMoney = 0
                    };

                    model.BankID = int.Parse(ddl_Bank.SelectedValue);
                    model.DealerID = int.Parse(ddl_Dealer.SelectedValue);
                    drafts.Add(model);
                    nos.Add("'" + row["DraftNo"].ToString() + "'");
                }
            }
            //检查这些汇票号是否存在重复
            if (!DraftBll.ExistsDraftNos(nos.ToArray()))
            {
                int num = DraftBll.AddRange(drafts.ToArray());
                if (num > 0)
                {
                    Alert.ShowInTop("添加成功！");
                    (ViewState[Draft_List] as DataTable).Rows.Clear();
                    Grid1.Rows.Clear();
                }
                else
                {
                    Alert.ShowInTop("添加失败！");
                }
            }
            else
            {
                Alert.ShowInTop("汇票号已存在！");
            }
        }

        /// <summary>
        /// 验证一整行数据是否为空
        /// </summary>
        /// <param name="row">数据行</param>
        /// <returns></returns>
        private bool ValidateRowIsNull(DataRow row)
        {
            bool flag = false;
            int index = 0;
            foreach (DataColumn dc in row.Table.Columns)
            {
                if (dc == null)
                {
                    index++;
                }
            }
            flag = index >= 6 ? true : false;
            return flag;
        }
        #endregion

        #region 加载合作银行信息--乔春羽
        private void BankDataBind()
        {
            DataTable dt = BankBll.GetList("IsDelete=0").Tables[0];

            ddl_Bank.DataTextField = "BankName";
            ddl_Bank.DataValueField = "BankID";
            ddl_Bank.DataSource = dt;
            ddl_Bank.DataBind();

            ddl_Bank.Items.Insert(0, new FineUI.ListItem("请选择", "0"));

        }
        #endregion

        #region 加载企业信息（经销商）--乔春羽
        private void DealerDataBind()
        {
            string val = ddl_Bank.SelectedValue;
            if (val != null && val != string.Empty && val != "0")
            {
                DataTable dt = Dealer_BankBll.GetList(string.Format("IsDelete=0 and BankID = {0}", val)).Tables[0];

                ddl_Dealer.DataTextField = "DealerName";
                ddl_Dealer.DataValueField = "DealerID";
                ddl_Dealer.DataSource = dt;
                ddl_Dealer.DataBind();
            }
            ddl_Dealer.Items.Insert(0, new FineUI.ListItem("请选择", "0"));
        }
        #endregion

        #region 选择银行，加载企业信息--乔春羽
        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            DealerDataBind();
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Text;

using FineUI;
namespace Citic_Web.FinanceInfo
{
    public partial class ImportDrafts : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        private static readonly string Draft_List = "DraftList";
        #region 选择Excel文件--乔春羽
        protected void file_Upload_FileSelected(object sender, EventArgs e)
        {
            string excel_Upload_Path = ConfigurationManager.AppSettings["draft_Upload_Path"].ToString();

            if (file_Upload.HasFile)
            {
                if (file_Upload.HasFile)     //判断是否有文件
                {
                    ViewState.Remove(Draft_List);
                    //判断是否是excle后缀名
                    if (file_Upload.ShortFileName.Split('.')[1].ToString() == "xlsx" || file_Upload.ShortFileName.Split('.')[1].ToString() == "xls")
                    {
                        //获取文件名称
                        string userInfo = string.Format("{0}{1}", this.CurrentUser.Post, this.CurrentUser.UserName);
                        string FileName = string.Format("{0}_{1}_{2}", DateTime.Now.ToString("yyyyMMdd_HHmmss"), userInfo, file_Upload.ShortFileName);
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
                        AlertShowInTop("文件格式不正确！", FineUI.MessageBoxIcon.Error);
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
            try
            {
                DataTable dt = Common.ExcelToTable.ExcelToDataTable(Path, string.Empty, true, 8, 1);
                dt.Columns[0].ColumnName = "BankName";            //合作行
                dt.Columns[1].ColumnName = "DealerName";          //经销商名称
                dt.Columns[2].ColumnName = "GuaranteeNo";         //保证金帐号
                dt.Columns[3].ColumnName = "PledgeNo";            //承兑汇票协议号/质押号
                dt.Columns[4].ColumnName = "DraftNo";             //汇票号
                dt.Columns[5].ColumnName = "BeginTime";           //开票日
                dt.Columns[6].ColumnName = "EndTime";             //到期日
                dt.Columns[7].ColumnName = "DraftMoney";          //票面金额

                int count = dt.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    DataRow row = dt.Rows[i];
                    if (string.IsNullOrEmpty(row[0].ToString()))
                    {
                        dt.Rows.RemoveAt(i);
                        i--;
                        count--;
                    }
                }

                return dt;
            }
            catch (Exception e)
            {
                AlertShowInTop("无法解析！");
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "ExcelToDS()");
            }
            return new DataTable();

        }
        #endregion

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
            List<string> dealerNames = new List<string>();
            if (Grid1.Rows.Count > 0)
            {
                //先判断有没有已经对接接口了得店


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
                        if (rowDict.ContainsKey("DraftMoney"))
                        {
                            rowData["DraftMoney"] = Convert.ToDecimal(rowDict["DraftMoney"]);
                        }
                    }
                }

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
            if (dt == null || dt.Rows.Count == 0)
            {
                AlertShowInTop("请重新选择要导入的汇票信息");
                return;
            }

            //用来存储“经销商名_合作行名”
            List<string> dbMaps = new List<string>();

            //用来存储BankID，DealerID，BrandID，BrandName等值
            List<Citic.Model.Dealer_Bank> models = new List<Citic.Model.Dealer_Bank>();
            List<Citic.Model.Draft> drafts = new List<Citic.Model.Draft>();

            foreach (DataRow row in dt.Rows)
            {
                if (!ValidateRowIsNull(row))
                {
                    //一开始，判断银行名集合与经销商名集合中是否存在当前的名字
                    //不存在，则分别添加到集合中
                    string bankName = row["BankName"].ToString().Trim();
                    string dealerName = row["DealerName"].ToString().Trim();
                    string temp = string.Format("{0}_{1}", dealerName, bankName);
                    if (!dbMaps.Contains(temp))
                    {
                        dbMaps.Add(temp);
                    }
                    //DateTime time = DateTime.Now;
                    //if (!DateTime.TryParse(row["BeginTime"].ToString(), out time) || DateTime.TryParse(row["EndTime"].ToString(), out time))
                    //{
                    //    AlertShowInTop("日期格式有误！");
                    //    return;
                    //}
                    object beginTimeOjb = row["BeginTime"];
                    object endTimeObj = row["EndTime"];
                    if (beginTimeOjb == null || endTimeObj == null || beginTimeOjb.ToString().IndexOf("/") < 0 || endTimeObj.ToString().IndexOf("/") < 0)
                    {
                        AlertShowInTop("日期格式有误！");
                        return;
                    }
                    //添加汇票集合
                    Citic.Model.Draft model = new Citic.Model.Draft()
                    {
                        BankName = bankName,
                        BeginTime = row.IsNull("BeginTime") ? DateTime.Parse("1900-01-01") : Convert.ToDateTime(row["BeginTime"]),
                        CreateID = this.CurrentUser.UserId,
                        CreateTime = DateTime.Now,
                        DarftMoney = row["DraftMoney"].ToString().Trim(),
                        DealerName = dealerName,
                        DraftType = true,
                        GuaranteeNo = row["GuaranteeNo"].ToString().Trim(),
                        DraftNo = row["DraftNo"].ToString().Trim(),
                        EndTime = row.IsNull("EndTime") ? DateTime.Parse("1900-01-01") : Convert.ToDateTime(row["EndTime"]),
                        PledgeNo = row["PledgeNo"].ToString().Trim(),
                        //保证金比例在这里先给一个默认值
                        //Ratio = Convert.ToDecimal(row["Ratio"]),
                        Ratio = (decimal)0.00,
                        //汇款金额与敞口金额需要公式计算
                        HKMoney = 0,
                        CKMoney = 0,
                        CarAllCount = 0,
                        CarAllMoney = 0,
                        CarILCount = 0,
                        CarILMoney = 0,
                        CarITCount = 0,
                        CarITMoney = 0
                    };
                    model.GuaranteeNo = Common.Common.RemoveSpecialCharacters(model.GuaranteeNo);
                    model.PledgeNo = Common.Common.RemoveSpecialCharacters(model.PledgeNo);
                    model.DraftNo = Common.Common.RemoveSpecialCharacters(model.DraftNo);
                    model.DarftMoney = Common.Common.RemoveSpecialCharacters(model.DarftMoney);
                    //判断，如果银行名集合与经销商名集合中已存在当前遍历的名字
                    //if (banks.Contains(bankName) && dealerName.Contains(dealerName))
                    //temp -->> dealerName_bankName
                    if (dbMaps.Contains(temp))
                    {
                        int index = 0;
                        bankName = temp.Split('_')[1];
                        dealerName = temp.Split('_')[0];
                        //就循环遍历models里是否有对应的值
                        foreach (Citic.Model.Dealer_Bank db in models)
                        {
                            //如果有，则赋值。
                            if (db.BankName == bankName && db.DealerName == dealerName)
                            {
                                index = 1;
                                model.BankID = db.BankID;
                                model.DealerID = db.DealerID;
                                model.BrandID = db.BrandID;
                                model.BrandName = db.BrandName;
                                break;
                            }
                        }
                        //index==0 表示没有
                        //既然没有对应的值，就到数据库中查询出。
                        if (index == 0)
                        {
                            DataTable dtDealer = this.Dealer_BankBll.GetList(string.Format(" A.BankName='{0}' and A.DealerName='{1}' and A.IsDelete=0 and A.CollaborateType = 1", bankName.Trim(), dealerName.Trim())).Tables[0];
                            if (dtDealer != null && dtDealer.Rows.Count > 0)
                            {
                                models.Add(new Citic.Model.Dealer_Bank()
                                {
                                    BankID = Convert.ToInt32(dtDealer.Rows[0]["BankID"]),
                                    BankName = bankName,
                                    DealerID = Convert.ToInt32(dtDealer.Rows[0]["DealerID"]),
                                    DealerName = dealerName,
                                    BrandID = Convert.ToInt32(dtDealer.Rows[0]["BrandID"]),
                                    BrandName = dtDealer.Rows[0]["BrandName"].ToString(),
                                    ZX_ID = dtDealer.Rows[0]["ZX_ID"].ToString(),
                                    GD_ID = dtDealer.Rows[0]["GD_ID"].ToString()
                                });

                                model.BankID = Convert.ToInt32(dtDealer.Rows[0]["BankID"]);
                                model.DealerID = Convert.ToInt32(dtDealer.Rows[0]["DealerID"]);
                                model.BrandID = Convert.ToInt32(dtDealer.Rows[0]["BrandID"]);
                                model.BrandName = dtDealer.Rows[0]["BrandName"].ToString();
                            }
                            else
                            {
                                string message = string.Format("{0}\r\n{1}\r\n上述经销商与银行的名称有误或者二者在系统中没有合作！\r\n请检查！", row["BankName"].ToString().Trim(), row["DealerName"].ToString().Trim());
                                AlertShowInTop(message);
                                return;
                            }
                        }
                    }
                    drafts.Add(model);
                }
            }
            //检查这些汇票号是否存在重复

            //根据经销商与银行判断汇票是否存在
            //即，同一个经销商银行下的汇票号不得重复
            DataTable existsDraftNo = null;
            StringBuilder Mess = null;
            List<string> strs = null;

            #region 监管员判断，判断当前登录的监管员所监管的店与导入的汇票信息中的所属店是否有出入
            if (this.CurrentUser.RoleId == 10)
            {
                DataTable supervisorDt = DealerBll.GetDealerIDAndDealerName(string.Format("SupervisorID = '{0}'", this.CurrentUser.RelationID.Value));
                try
                {
                    if (supervisorDt == null || supervisorDt.Rows.Count == 0)
                    {
                        AlertShowInTop("该监管员没有监管任何经销店，不能录入汇票信息！");
                        return;
                    }
                    Mess = new StringBuilder();
                    int errorCount = 0;
                    foreach (Citic.Model.Dealer_Bank model in models)
                    {
                        foreach (DataRow row in supervisorDt.Rows)
                        {
                            if (row["DealerName"].ToString().Trim() == model.DealerName.Trim())
                            {
                                break;
                            }
                            else
                            {
                                errorCount++;
                            }
                        }
                        if (errorCount == supervisorDt.Rows.Count)
                        {
                            Mess.AppendLine(model.DealerName);
                        }
                        errorCount = 0;
                    }
                }
                catch (Exception e)
                {
                    Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "Save()：监管员判断，判断当前登录的监管员所监管的店与导入的汇票信息中的所属店是否有出入");
                }

                if (Mess.Length > 0)
                {
                    Mess.AppendLine("上述经销商该监管员并没有监管，汇票不能录入！");
                    txt_Message.Text = Mess.ToString();
                    Window_ShowMessage.Title = "信息提示！";
                    Window_ShowMessage.Hidden = false;
                    return;
                }
            }
            #endregion

            #region 找出重复的“店”中已经对接接口的
            try
            {
                Mess = new StringBuilder();
                foreach (Citic.Model.Dealer_Bank db in models)
                {
                    int bankID = db.BankID.Value;
                    Citic.Model.Bank bankModel = this.BankBll.GetModel(bankID);
                    string bankCode = bankModel.ConnectID;

                    switch (bankCode)
                    {
                        case Common.Common.GuangDaString:
                            if (!string.IsNullOrEmpty(db.GD_ID))
                            {
                                Mess.AppendFormat("经销商：{0}\r\n", db.DealerName);
                                Mess.AppendFormat("合作行：{0}\r\n", db.BankName);
                                Mess.AppendLine("已经对接光大接口！\r\n");
                            }
                            break;
                        case Common.Common.ZhongXinString:
                            if (!string.IsNullOrEmpty(db.ZX_ID))
                            {
                                Mess.AppendFormat("经销商：{0}\r\n", db.DealerName);
                                Mess.AppendFormat("合作行：{0}\r\n", db.BankName);
                                Mess.AppendLine("已经对接中信接口！\r\n");
                            }
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "Save()：找出重复的“店”中已经对接接口的");
            }

            if (Mess.Length > 0)
            {
                txt_Message.Text = Mess.ToString();
                Window_ShowMessage.Title = "信息提示！";
                Window_ShowMessage.Hidden = false;
                return;
            }
            #endregion

            #region 找出重复的汇票并拼接出一个提示信息
            Mess = new StringBuilder();
            try
            {
                foreach (Citic.Model.Dealer_Bank db in models)
                {
                    strs = new List<string>();
                    foreach (Citic.Model.Draft draft in drafts)
                    {
                        if (db.BankID == draft.BankID && db.DealerID == draft.DealerID)
                        {
                            strs.Add(string.Format("'{0}'", draft.DraftNo));
                        }
                    }
                    existsDraftNo = this.DraftBll.GetList(string.Format(" DraftNo in ({0}) ", string.Join(",", strs.ToArray()))).Tables[0];
                    //existsDraftNo = this.DraftBll.GetList(string.Format(" DraftNo in ({0}) and BankID='{1}' and DealerID = '{2}'", string.Join(",", strs.ToArray()), db.BankID, db.DealerID)).Tables[0];
                    if (existsDraftNo != null && existsDraftNo.Rows.Count > 0)
                    {
                        Mess.AppendLine(string.Format("经销商：{0}\t合作行：{1}", db.DealerName, db.BankName));
                        Mess.AppendLine("汇票号：");
                        for (int i = 0; i < existsDraftNo.Rows.Count; i++)
                        {
                            Mess.Append(string.Format("'{0}'", existsDraftNo.Rows[i]["DraftNo"].ToString()));
                            if (i < existsDraftNo.Rows.Count - 1)
                            {
                                Mess.Append(",");
                            }
                            Mess.AppendLine();
                        }
                        Mess.AppendLine();
                    }
                }
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "Save()：找出重复的汇票并拼接出一个提示信息");
            }
            if (Mess.Length > 0)
            {
                txt_Message.Text = Mess.ToString();
                Window_ShowMessage.Title = "汇票号已存在！";
                Window_ShowMessage.Hidden = false;
                return;
            }
            #endregion

            if (Mess.Length == 0)
            {
                try
                {
                    int num = DraftBll.AddRange(drafts.ToArray());
                    if (num > 0)
                    {
                        AlertShowInTop("添加成功！");
                        (ViewState[Draft_List] as DataTable).Rows.Clear();
                        Grid1.Rows.Clear();
                    }
                    else
                    {
                        AlertShowInTop("添加失败！");
                    }
                }
                catch (Exception e)
                {
                    Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "Save():int num = DraftBll.AddRange(drafts.ToArray());");
                    AlertShowInTop("有异常！请联系系统开发人员！");
                }
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
                if (dc == null || row[dc] == null)
                {
                    index++;
                }
            }
            flag = index >= 6 ? true : false;
            return flag;
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Text.RegularExpressions;
using Citic.BLL;
using FineUI;
using System.IO;

namespace Citic_Web.Car
{
    public partial class Add_Car : BasePage
    {
        string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        #region Load事件
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCompany();
                // 删除选中行
                btn_Delete_Car.OnClientClick = G_Car_Detail.GetNoSelectionAlertReference("请至少选择一项！");
                btn_Delete_Car.ConfirmText = String.Format("你确定要删除第&nbsp;<b><script>({0}[0]+1)</script></b>&nbsp;行数据吗？", G_Car_Detail.GetSelectedCellReference());
                this.btn_Add_Table.OnClientClick = AddGridRows();
            }
        }
        #endregion

        #region 按钮点击事件
        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add_Car_Clike(object sender, EventArgs e)
        {
            if (this.DDL_Company_Name.SelectedValue == "-1")
            {
                FineUI.Alert.Show("请选择经销商！", FineUI.MessageBoxIcon.Error);
            }
            else if (DDL_Bank.SelectedValue == "-1")
            {
                FineUI.Alert.Show("请选择合作银行！", FineUI.MessageBoxIcon.Error);
            }
            else if (DDL_Number_Order.SelectedValue == "-1")
            {
                FineUI.Alert.Show("请选择汇票号！", FineUI.MessageBoxIcon.Error);
            }
            else
            {
                string ErrorTxt = string.Empty;    //记录错误信息 
                if (ErrorTxt.Length == 0)
                {
                    DataTable dt = GetSourceData();

                    for (int i = 0; i < G_Car_Detail.Rows.Count; i++)
                    {
                        //获取当前行数据集合
                        string[] Values = this.G_Car_Detail.Rows[i].Values;
                        #region 车辆属性验证
                        //车辆金额正则，大于0的浮点数
                        string CheckingCarCost = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
                        if (!Regex.IsMatch(Values[9].ToString(), CheckingCarCost))
                        {
                            dt.Rows[i]["CarCost"] = "0";
                            ErrorTxt = "第" + (i + 1) + "行车辆金额验证不通过，不是金额格式";
                            break;
                        }
                        //else
                        //{
                        //    GetCarCountMoney(Values[9].ToString());
                        //}
                        //车架正则验证，大写26个字母和10个数字
                        //string CheckingVin = @"^[A-Z0-9]+$";
                        string CheckingVin = @"^[A-Z0-9]{17,18}$";     //2014年5月4日 
                        if (!Regex.IsMatch(Values[6].ToString().Trim(), CheckingVin))
                        {
                            ErrorTxt = "第" + (i + 1) + "行车架验证不通过,车架号只能是17位或18位大写字母或数字位";
                            break;
                        }

                        //车辆型号验证
                        if (CheckBadStr(Values[1].ToString().Trim()))
                        {
                            ErrorTxt = "第" + (i + 1) + "行车辆型号验证不通过，包含特殊字符";
                            break;
                        }
                        //车辆分类
                        if (CheckBadStr(Values[2].ToString().Trim()))
                        {
                            ErrorTxt = "第" + (i + 1) + "行车辆分类验证不通过，包含特殊字符";
                            break;
                        }
                        //车辆排量验证
                        if (CheckBadStr(Values[3].ToString().Trim()))
                        {
                            ErrorTxt = "第" + (i + 1) + "行排量验证不通过，包含特殊字符";
                            break;
                        }
                        //颜色验证
                        if (CheckBadStr(Values[4].ToString().Trim()))
                        {
                            ErrorTxt = "第" + (i + 1) + "行颜色验证不通过，包含特殊字符";
                            break;
                        }
                        //发动机验证
                        if (CheckBadStr(Values[5].ToString().Trim()))
                        {
                            ErrorTxt = "第" + (i + 1) + "行发动机验证不通过，包含特殊字符";
                            break;
                        }
                        //合格证验证
                        if (CheckBadStr(Values[7].ToString().Trim()))
                        {
                            ErrorTxt = "第" + (i + 1) + "行合格证验证不通过，包含特殊字符";
                            break;
                        }
                        //钥匙号验证
                        if (CheckBadStr(Values[8].ToString().Trim()))
                        {
                            ErrorTxt = "第" + (i + 1) + "行钥匙号验证不通过，包含特殊字符";
                            break;
                        }
                        //备注验证
                        if (CheckBadStr(Values[10].ToString().Trim()))
                        {
                            ErrorTxt = "第" + (i + 1) + "行备注验证不通过，包含特殊字符";
                            break;
                        }
                        //验证合格证发证日期
                        if (Values[0].ToString().Trim().Length != 0)
                        {
                            if (Values[0].ToString().Trim().Split('-').Length == 3 || Values[0].ToString().Trim().Split('/').Length == 3)
                            {
                                DateTime date;
                                if (!DateTime.TryParse(Values[0].ToString().Trim(), out date))
                                {
                                    ErrorTxt = "第" + (i + 1) + "行备合格证发证日期有误";
                                    break;
                                }
                                else
                                {
                                    int y = Convert.ToDateTime(Values[0].ToString().Trim()).Year;
                                    if (y < 2000)
                                    {
                                        ErrorTxt = "第" + (i + 1) + "行备合格证发证日期有误";
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                ErrorTxt = "第" + (i + 1) + "行备合格证发证日期格式有误,正确格式如:2000-01-01";
                                break;
                            }
                        }
                        #endregion
                        #region 当前车架号重复验证
                        for (int j = 0; j < G_Car_Detail.Rows.Count; j++)
                        {
                            if (i != j)
                            {
                                string[] listValues = G_Car_Detail.Rows[j].Values;
                                //判断当前dt是否存在重复车架号
                                if (Values[6].ToString().Trim() == listValues[6].ToString().Trim())
                                {
                                    ErrorTxt = "第" + (i + 1) + "行车架与第" + (j + 1) + "行车架号重复";
                                    break;
                                }
                            }
                        }
                        if (ErrorTxt.Length != 0)
                        {
                            break;
                        }
                        #endregion

                    }
                    //车辆所有信息验证成功，以下数据库验证
                    if (ErrorTxt.Length == 0)
                    {
                        DataRow[] dr = ((DataTable)ViewState["DealerName"]).Select(string.Format("BankName='{0}' and BankID='{1}' and DealerName='{2}'", this.DDL_Bank.SelectedText.ToString(), this.DDL_Bank.SelectedValue.ToString(), this.DDL_Company_Name.SelectedValue.ToString()));
                        //string[] DealerCount = this.DDL_Bank.SelectedValue.ToString().Split('_');   2014年5月14日
                        string DealerID = dr[0].ItemArray[0].ToString();              //获取经销商id
                        string BankID = dr[0].ItemArray[2].ToString();     //获取银行id
                        string DealerName = DDL_Company_Name.SelectedText.ToString();       //获取经销商名称
                        string BrandID = dr[0].ItemArray[4].ToString();             //获取品牌id
                        string DraftNo = DDL_Number_Order.SelectedText.ToString();      //获取汇票号
                        string BankName = this.DDL_Bank.SelectedText.ToString();     //获取银行名称
                        string BrandName = dr[0].ItemArray[5].ToString();     //获取品牌
                        string Date = DateTime.Now.ToString("yyyy-MM-dd");
                        string UserName = CurrentUser.TrueName;
                        string UserId = CurrentUser.UserId.ToString();

                        string tb_Name = "tb_Car_" + BankID + "_" + DealerID;      //数据库表名
                        List<string> list = new List<string>();

                        string sql = "insert into " + tb_Name + " (Vin,DraftNo,BankID,BankName,Statu,QualifiedNoDate,DealerID,DealerName,BrandID,BrandName,StorageID,StorageName,CarColor,CarModel,EngineNo,QualifiedNo,KeyCount,KeyNumber,CarCost,ReturnCost,Remarks,CreateID,CreateTime,IsDelete,CarClass,Displacement) ";  //添加sql语句
                        for (int i = 0; i < G_Car_Detail.Rows.Count; i++)
                        {
                            //获取当前行数据集合
                            string[] Values = G_Car_Detail.Rows[i].Values;
                            bool bl = CarBll.Exists(Values[6].ToString().Trim(), tb_Name);//判断数据库是否已经存在当前车辆信息
                            if (bl)
                            {
                                ErrorTxt = "第" + (i + 1) + "行车架已经存在";
                                break;
                            }
                            else
                            {
                                string QualifiedNoDate = Values[0].ToString().Trim(); //合格证发证日期
                                string CarClass = Values[2].ToString().Trim(); //类型
                                string CarModel = Values[1].ToString().Trim(); //型号
                                string Displacement = Values[3].ToString().Trim(); //排量
                                string CarColour = Values[4].ToString().Trim(); //颜色
                                string EngineNo = Values[5].ToString().Trim(); //发动机
                                string Vin = Values[6].ToString().Trim(); //车架
                                string QualifiedNo = Values[7].ToString().Trim(); //合格证
                                string KeyNumber = Values[8].ToString().Trim(); //钥匙号
                                string CarCost = Values[9].ToString().Trim();     //车辆金额
                                string Remark = Values[10].ToString().Trim();      //备注
                                sql += string.Format("select '{0}','{1}','{2}','{3}','3','{4}','{5}','{6}','{7}','{8}','-1','本库','{9}','{10}','{11}','{12}','0','{13}','{14}','0','{15}','{16}',GETDATE(),0,'{17}','{18}' union all ", Vin, DraftNo, BankID, BankName, QualifiedNoDate, DealerID, DealerName, BrandID, BrandName, CarColour, CarModel, EngineNo, QualifiedNo, KeyNumber, CarCost, Remark, UserId, CarClass, Displacement);
                                if (dr[0].ItemArray[7].ToString().Length != 0)
                                {
                                    list.Add(string.Format(@"if exists(select * from GD_DispatchCarInfo  where DJ_NO='{0}') Begin update GD_DispatchCarInfo set DJ_NO='{1}' where DJ_NO='{2}' End else Begin  insert into GD_DispatchCarInfo (JXS_ID,DJ_NO,BF_ID,CreateTime,SEND_CAR_ID) values ('{3}','{4}',(select GD_ID from tb_Draft_List where DraftNo='{5}'),getdate(),'{6}') End", Vin, Vin, Vin, dr[0].ItemArray[7].ToString(), Vin, DraftNo, "AAA" + DateTime.Now.ToString("yyyyMMddmmssHHffff")));
                                }
                            }
                        }
                        if (ErrorTxt.Length == 0)
                        {
                            //声明集合，存放需要执行的sql语句


                            sql = sql.Remove(sql.LastIndexOf("union all")); //移除最后一个union all
                            list.Add(sql);
                            int Number = new Citic.BLL.Car().SqlTran(list);
                            if (Number > 0)
                            {
                                FineUI.Alert.Show("添加成功！共添加" + dt.Rows.Count + "台车", FineUI.MessageBoxIcon.Information);
                                GetSourceData().Clear();
                                this.G_Car_Detail.DataSource = GetSourceData();
                                this.G_Car_Detail.DataBind();
                            }
                            else
                            {
                                GetSourceData().Clear();
                                FineUI.Alert.Show("添加失败！", FineUI.MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            FineUI.Alert.ShowInTop(ErrorTxt, FineUI.MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        FineUI.Alert.ShowInTop(ErrorTxt, FineUI.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    FineUI.Alert.ShowInTop(ErrorTxt, FineUI.MessageBoxIcon.Error);

                }
            }
        }
        #endregion

        #region 删除选择行
        protected void btn_Delete_Car_Clike(object sender, EventArgs e)
        {
            if (G_Car_Detail.SelectedCell != null)
            {
                //CheckinVin();  //修改数据源

                int rowIndex = G_Car_Detail.SelectedCell[0];   //获取当前选择单元格索引 
                DataTable dt = GetSourceData();     //获取数据源
                dt.Rows.RemoveAt(rowIndex);     //移除指定索引行
                G_Car_Detail.DataSource = GetSourceData();
                G_Car_Detail.DataBind();
            }
            else
            {
                FineUI.Alert.ShowInTop("没有选中任何单元格！", FineUI.MessageBoxIcon.Warning);
            }
        }
        #endregion
        private static readonly string Car_List = "CarList";

        #region 修改数据源
        /// <summary>
        /// 修改当前数据源信息
        /// 张繁
        /// </summary>
        private void CheckinVin()
        {
            //修改现有数据
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_Car_Detail.GetModifiedDict();
            for (int i = 0, count = G_Car_Detail.Rows.Count; i < count; i++)
            {
                if (modifiedDict.ContainsKey(i))
                {
                    Dictionary<string, string> rowDict = modifiedDict[i];
                    //更新数据源
                    DataTable table = GetSourceData();
                    DataRow rowData = table.Rows[i];
                    UpdateSourceDataRow(rowDict, rowData);

                }
            }
            //新增数据
            List<Dictionary<string, string>> newlist = G_Car_Detail.GetNewAddedList();
            for (int i = 0; i < newlist.Count; i++)
            {
                //更新数据源，其实为创建新的DateTable
                DataTable table = GetSourceData();
                DataRow rowData = table.NewRow();

                UpdateSourceDataRow(newlist[i], rowData);

                table.Rows.InsertAt(rowData, 0);
            }
            //G_Car_Detail.DataSource = GetSourceData();
            //G_Car_Detail.DataBind();
        }
        #endregion

        #region 修改DataRow数据
        /// <summary>
        /// 修改DataRow数据源信息
        /// </summary>
        /// <param name="rowDict"></param>
        /// <param name="rowData"></param>
        private static void UpdateSourceDataRow(Dictionary<string, string> rowDict, DataRow rowData)
        {
            // 合格证发证日期
            if (rowDict.ContainsKey("IssueDate"))
            {
                if (rowDict["IssueDate"].Length == 0)
                {
                    rowDict["IssueDate"] = "";
                }
                else
                {
                    rowData["IssueDate"] = DateTime.Parse(rowDict["IssueDate"]).ToString("yyyy-MM-dd");
                }

            }
            // 车辆型号
            if (rowDict.ContainsKey("CarModel"))
            {
                rowData["CarModel"] = rowDict["CarModel"];
            }
            // 颜色
            if (rowDict.ContainsKey("CarColour"))
            {
                rowData["CarColour"] = rowDict["CarColour"];
            }
            // 发动机号
            if (rowDict.ContainsKey("EngineNo"))
            {
                rowData["EngineNo"] = rowDict["EngineNo"];
            }
            // 车架号
            if (rowDict.ContainsKey("Vin"))
            {
                rowData["Vin"] = rowDict["Vin"];
            }
            // 合格证号
            if (rowDict.ContainsKey("QualifiedNo"))
            {
                rowData["QualifiedNo"] = rowDict["QualifiedNo"];
            }
            // 钥匙号
            if (rowDict.ContainsKey("KeyNumber"))
            {
                if (rowDict["KeyNumber"].Length == 0)
                {
                    rowData["KeyNumber"] = Convert.ToDouble(0);
                }
                else
                {
                    rowData["KeyNumber"] = rowDict["KeyNumber"];
                }

            }
            // 车辆金额
            if (rowDict.ContainsKey("CarCost"))
            {
                //rowData["CarCost"] = rowDict["CarCost"];
                if (rowDict["CarCost"].Length == 0)
                {
                    rowData["CarCost"] = Convert.ToDouble(0);
                }
                else
                {
                    try
                    {
                        rowData["CarCost"] = rowDict["CarCost"];
                    }
                    catch
                    {
                        rowData["CarCost"] = Convert.ToDouble(0);
                    }

                }
            }
            // 备注
            if (rowDict.ContainsKey("Remark"))
            {
                rowData["Remark"] = rowDict["Remark"];
            }
        }

        #endregion

        #region 添加Grid行
        /// <summary>
        /// 添加Grid行
        /// 张繁 2013年6月19日 
        /// </summary>
        private string AddGridRows()
        {
            string GridRowsStr = string.Empty;
            JObject o = new JObject();
            o.Add("IssueDate", DateTime.Now.ToString("yyyy-MM-dd"));
            o.Add("CarModel", "");
            o.Add("CarColour", "");
            o.Add("EngineNo", "");
            o.Add("Vin", "");
            o.Add("QualifiedNo", "");
            o.Add("KeyNumber", "0");
            o.Add("CarCost", "0");
            o.Add("Remark", "");
            return GridRowsStr = G_Car_Detail.GetAddNewRecordReference(o, true);
        }
        #endregion

        #region 读取Excel文件并保存
        /// <summary>
        /// 读取Excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FileExcel_FileSelected(object sender, EventArgs e)
        {
            try
            {
                if (this.DDL_Number_Order.SelectedValue != null && this.DDL_Number_Order.SelectedValue.ToString() != "-1")
                {
                    if (FileExcel.HasFile)  //判断文件是否存在
                    {
                        ViewState.Remove(Car_List);
                        //判断获取文件后缀名是否包含Excel格式名
                        if (FileExcel.ShortFileName.Split('.')[1].ToString() == "xlsx" || FileExcel.ShortFileName.Split('.')[1].ToString() == "xls")
                        {
                            string path = "~/UpExcel/" + DateTime.Now.ToString("yyyy-MM") + "/" + this.DDL_Company_Name.SelectedValue.ToString();    //创建文件
                            DirectoryInfo di = new DirectoryInfo(Server.MapPath(path));
                            if (!di.Exists)     //判断文件夹是否存在
                                di.Create();    //创建文件夹
                            //获取文件名称
                            string FileName = DateTime.Now.ToString("yyyyMMdd_HHmmssffff_") + this.DDL_Company_Name.SelectedValue.ToString() + "_" + CurrentUser.TrueName + "." + FileExcel.ShortFileName.Split('.')[1].ToString();
                            //获取创建文件路径+文件名称 2014年4月16日
                            path = path + "/" + FileName;
                            //将文件名称保存在服务器上
                            FileExcel.SaveAs(Server.MapPath(path));


                            DataTable dt = Common.ExcelToTable.ExcelToDataTable(Server.MapPath(path), "", true, 12, 7);
                            dt.Columns[0].ColumnName = "TabId";           //序号
                            dt.Columns[1].ColumnName = "IssueDate";       //合格证发证日期
                            dt.Columns[2].ColumnName = "CarModel";       //车辆型号
                            dt.Columns[3].ColumnName = "CarClass";        //车辆分类
                            dt.Columns[4].ColumnName = "Displacement";    //排量
                            dt.Columns[5].ColumnName = "CarColour";       //颜色
                            dt.Columns[6].ColumnName = "EngineNo";        //发动机号
                            dt.Columns[7].ColumnName = "Vin";             //车架号
                            dt.Columns[8].ColumnName = "QualifiedNo";     //合格证号
                            dt.Columns[9].ColumnName = "KeyNumber";       //钥匙号
                            dt.Columns[10].ColumnName = "CarCost";         //车辆金额
                            dt.Columns[11].ColumnName = "Remark";          //备注
                            dt.Rows.RemoveAt(0);
                            ViewState[Car_List] = dt;
                            this.G_Car_Detail.DataSource = (DataTable)ViewState[Car_List];
                            this.G_Car_Detail.DataBind();
                            FileExcel.Reset();
                        }
                        else
                        {
                            FineUI.Alert.ShowInTop("文件格式不正确！", FineUI.MessageBoxIcon.Error);
                            FileExcel.Reset();
                        }
                    }
                }
                else
                {
                    FineUI.Alert.ShowInTop("请选择汇票！", FineUI.MessageBoxIcon.Error);
                    FileExcel.Reset();
                }
            }
            catch (Exception)
            {
                FineUI.Alert.ShowInTop("文件格式有误,请检查是否存在Excel公式计算或者将文件类容复制到新的文件中再次提交", FineUI.MessageBoxIcon.Error);
                FileExcel.Reset();
            }
        }
        #endregion

        #region 过滤DataTable获取自定义数据

        /// <summary>
        /// 过滤DataTable
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable FilterTable(DataTable dt)
        {

            return dt;
        }
        #endregion
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
                //string strExcel = "select * from [" + schemaTable.Rows[0]["TABLE_NAME"].ToString() + "]";
                string strExcel = "select * from [" + schemaTable.Rows[0]["TABLE_NAME"].ToString() + "] where [F2] is not null";
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn1);
                myCommand.Fill(ds);
                ds.Tables[0].Columns[0].ColumnName = "TabId";           //序号
                ds.Tables[0].Columns[1].ColumnName = "IssueDate";       //合格证发证日期
                ds.Tables[0].Columns[2].ColumnName = "CarClass";       //车辆分类
                ds.Tables[0].Columns[3].ColumnName = "CarModel";        //车辆型号
                ds.Tables[0].Columns[4].ColumnName = "Displacement";    //排量
                ds.Tables[0].Columns[5].ColumnName = "CarColour";       //颜色
                ds.Tables[0].Columns[6].ColumnName = "EngineNo";        //发动机号
                ds.Tables[0].Columns[7].ColumnName = "Vin";             //车架号
                ds.Tables[0].Columns[8].ColumnName = "QualifiedNo";     //合格证号
                ds.Tables[0].Columns[9].ColumnName = "KeyNumber";       //钥匙号
                ds.Tables[0].Columns[10].ColumnName = "CarCost";         //车辆金额
                ds.Tables[0].Columns[11].ColumnName = "Remark";          //备注
                ds.Tables[0].Rows.RemoveAt(0);

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

        #region Grid行绑定事件
        protected void RowCommand(object sender, FineUI.GridPreRowEventArgs e)
        {
            //Sql_Car_Vin(e);     //查询当前车架数据库是否存在
            //DataRowView row = e.DataItem as DataRowView;    //获取当前行索引

            //FineUI.ImageField imgAction = G_Car_Detail.FindColumn("imgAction") as FineUI.ImageField;   //获取验证列控件
            ////循环判断当前行车架是否与循环行车架重复
            //for (int i = 0; i < row.DataView.Count; i++)
            //{
            //    //判断当前行索引是否与循环行索引重复
            //    if (e.RowIndex != i)
            //    {
            //        //当前行索引车架与循环行车架重复
            //        if (row["Vin"].ToString() == row.DataView.Table.Rows[i]["Vin"].ToString())
            //        {
            //            imgAction.DataImageUrlField = row["Vin"].ToString();
            //            imgAction.DataImageUrlFormatString = "~/icon/decline.png"; //错误图片
            //        }
            //    }
            //}
            ////车辆金额正则，大于0的浮点数
            //string CheckingCarCost = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
            //if (!Regex.IsMatch(row["CarCost"].ToString(), CheckingCarCost))
            //{
            //    imgAction.DataImageUrlField = row["Vin"].ToString();
            //    imgAction.DataImageUrlFormatString = "~/icon/decline.png"; //错误图片
            //    row["CarCost"] = "0";
            //}
            //else
            //{
            //    GetCarCountMoney(row["CarCost"].ToString());
            //}
            ////车架正则验证，大写26个字母和10个数字
            //string CheckingVin = @"^[A-Z0-9]+$";
            //if (!Regex.IsMatch(row["Vin"].ToString(), CheckingVin))
            //{
            //    imgAction.DataImageUrlField = row["Vin"].ToString();
            //    imgAction.DataImageUrlFormatString = "~/icon/decline.png"; //错误图片
            //}
            ////车辆型号验证
            //if (CheckBadStr(row["CarModel"].ToString()))
            //{
            //    imgAction.DataImageUrlField = row["Vin"].ToString();
            //    imgAction.DataImageUrlFormatString = "~/icon/decline.png"; //错误图片
            //    lblMes.Text = lblMes.Text + "第" + (e.RowIndex + 1) + "行-车辆型号  ";
            //}
            ////颜色验证
            //if (CheckBadStr(row["CarColour"].ToString()))
            //{
            //    imgAction.DataImageUrlField = row["Vin"].ToString();
            //    imgAction.DataImageUrlFormatString = "~/icon/decline.png"; //错误图片
            //    lblMes.Text = lblMes.Text + "第" + (e.RowIndex + 1) + "行-颜色  ";
            //}
            ////发动机验证
            //if (CheckBadStr(row["EngineNo"].ToString()))
            //{
            //    imgAction.DataImageUrlField = row["Vin"].ToString();
            //    imgAction.DataImageUrlFormatString = "~/icon/decline.png"; //错误图片
            //    lblMes.Text = lblMes.Text + "第" + (e.RowIndex + 1) + "行-发动机  ";
            //}
            ////合格证验证
            //if (CheckBadStr(row["QualifiedNo"].ToString()))
            //{
            //    imgAction.DataImageUrlField = row["Vin"].ToString();
            //    imgAction.DataImageUrlFormatString = "~/icon/decline.png"; //错误图片
            //    lblMes.Text = lblMes.Text + "第" + (e.RowIndex + 1) + "行-合格证  ";
            //}
            ////钥匙号验证
            //if (CheckBadStr(row["KeyNumber"].ToString()))
            //{
            //    imgAction.DataImageUrlField = row["Vin"].ToString();
            //    imgAction.DataImageUrlFormatString = "~/icon/decline.png"; //错误图片
            //    lblMes.Text = lblMes.Text + "第" + (e.RowIndex + 1) + "行-钥匙号  ";
            //}
            ////备注验证
            //if (CheckBadStr(row["Remark"].ToString()))
            //{
            //    imgAction.DataImageUrlField = row["Vin"].ToString();
            //    imgAction.DataImageUrlFormatString = "~/icon/decline.png"; //错误图片
            //    lblMes.Text = lblMes.Text + "第" + (e.RowIndex + 1) + "行-备注  ";
            //}
        }
        #endregion

        #region 验证当前车架号数据库是否存在
        /// <summary>
        /// 车架验证
        /// </summary>
        /// <param name="e"></param>
        private void Sql_Car_Vin(FineUI.GridPreRowEventArgs e)
        {
            try
            {
                string[] tb_Name_Count = this.DDL_Company_Name.SelectedValue.ToString().Split('_');
                string tb_Name = "tb_Car_" + tb_Name_Count[0] + "_" + tb_Name_Count[1].ToString();
                FineUI.ImageField imgAction1 = G_Car_Detail.FindColumn("imgAction") as FineUI.ImageField; //获取验证列控件
                DataRowView row = e.DataItem as DataRowView;
                //查询当前车架号数据库是否存在
                bool bl = new Citic.BLL.Car().Exists(row.Row["Vin"].ToString(), tb_Name);
                if (bl)
                {
                    imgAction1.DataImageUrlField = row.Row["Vin"].ToString();
                    imgAction1.DataImageUrlFormatString = "~/icon/decline.png";  //错误图片
                }
                else
                {
                    imgAction1.DataImageUrlField = row.Row["Vin"].ToString();
                    imgAction1.DataImageUrlFormatString = "~/icon/accept.png";
                }

            }
            catch
            {
                FineUI.Alert.ShowInTop("与服务器无法连接", FineUI.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 添加车辆信息
        /// <summary>
        /// 添加车辆信息
        /// 张繁 2013年6月20日
        /// </summary>
        private void AddSqlCar()
        {
            string DealerCount = DDL_Bank.SelectedValue.ToString();
            string DealerID = DealerCount.Split('_')[1].ToString();              //获取经销商id
            string BankID = DealerCount.Split('_')[0].ToString();     //获取银行id
            string DealerName = DDL_Company_Name.SelectedText.ToString();       //获取经销商名称
            string tb_Name = "tb_Car_" + BankID + "_" + DealerID;               //sql表名
            string DraftNo = DDL_Number_Order.SelectedText.ToString();      //获取汇票号
            string BankName = DealerCount.Split('_')[2].ToString();     //获取银行名称
            string BrandName = DealerCount.Split('_')[3].ToString();     //获取品牌
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string UserName = CurrentUser.TrueName;
            string UserId = CurrentUser.UserId.ToString();
            string sql = "insert into " + tb_Name + " (Vin,DraftNo,BankID,Statu,QualifiedNoDate,DealerID,DealerName,BrandID,StorageID,StorageName,CarColor,CarModel,EngineNo,QualifiedNo,KeyCount,keyNumber,CarCost,ReturnCost,Remarks,CreateID,CreateTime,IsDelete,BankName,BrandName) ";  //添加sql语句
            int Count = 0; //记录循环行总数
            //获取Gird有多少行，循环多少遍
            for (int i = 0; i < this.G_Car_Detail.Rows.Count; i++)
            {
                string Pic = this.G_Car_Detail.Rows[i].Values[9].Split('/')[2].Split('"')[0].ToString();    //获取验证列图片名称
                //判断验证列图片是否有误
                if (Pic != "accept.png" || Pic.Length == 0)     //错误图片格式
                {
                    FineUI.Alert.Show("第" + (i + 1) + "行数据不合格！");
                    break;
                }
                string QualifiedNoDate = G_Car_Detail.Rows[i].Values[0].ToString(); //合格证发证日期
                string CarModel = G_Car_Detail.Rows[i].Values[2].ToString(); //型号
                string CarColour = G_Car_Detail.Rows[i].Values[3].ToString(); //颜色
                string EngineNo = G_Car_Detail.Rows[i].Values[4].ToString(); //发动机
                string Vin = G_Car_Detail.Rows[i].Values[5].ToString(); //车架
                string QualifiedNo = G_Car_Detail.Rows[i].Values[6].ToString(); //合格证
                string KeyNumber = G_Car_Detail.Rows[i].Values[7].ToString(); //钥匙号
                string CarCost = G_Car_Detail.Rows[i].Values[8].ToString();     //车辆金额
                string Remark = G_Car_Detail.Rows[i].Values[9].ToString();      //备注
                sql += "select '" + Vin + "','" + DraftNo + "','" + BankID + "','3','" + QualifiedNoDate + "','" + DealerID + "','" + DealerName + "','2','-1','本库','" + CarColour + "','" + CarModel + "','" + EngineNo + "','" + QualifiedNo + "','0','" + KeyNumber + "','" + CarCost + "','0','" + Remark + "','" + UserId + "','" + DateTime.Now + "','0','" + BankName + "','" + BrandName + "' union all ";

                Count++;
            }
            if (this.G_Car_Detail.Rows.Count == 0)
            {
                FineUI.Alert.Show("请验证车架！");
            }
            else
            {
                //判断循环行是否与当前Gird行总数相等
                if (Count == this.G_Car_Detail.Rows.Count)
                {
                    //声明集合，存放需要执行的sql语句
                    List<string> list = new List<string>();

                    sql = sql.Remove(sql.LastIndexOf("union all")); //移除最后一个union all
                    list.Add(sql);
                    DataTable dt = (DataTable)ViewState["DraftNoList"];
                    DataRow[] dr = dt.Select("DraftNo='" + DraftNo + "'");
                    string CarCount = (int.Parse(dr[0]["CarAllCount"].ToString()) + Count).ToString();   //原有总数+现有车辆总数
                    string CarMoney = (Convert.ToDouble(TT_CarCountMoney.Text.ToString().Split('：')[1]) + Convert.ToDouble(dr[0]["CarAllMoney"])).ToString();
                    //更新汇票信息表sql
                    string sql1 = "update tb_Draft_List set CarAllCount='" + CarCount + "',CarAllMoney='" + CarMoney + "' where DraftNo='" + DraftNo + "' and BankID='" + BankID + "'";
                    list.Add(sql1);
                    int Number = new Citic.BLL.Car().SqlTran(list);
                    if (Number > 0)
                    {
                        FineUI.Alert.Show("添加成功！共添加" + Count + "台车", FineUI.MessageBoxIcon.Information);
                        //ViewState.Remove(Car_List);   //移除对象中的Key
                        this.G_Car_Detail.DataSource = (DataTable)ViewState[Car_List];    //重新绑定数据源，现在数据源已经空
                        this.G_Car_Detail.DataBind();
                    }
                    else
                    {
                        FineUI.Alert.Show("添加失败！", FineUI.MessageBoxIcon.Error);
                    }

                }
            }

        }
        #endregion

        #region 添加Gird行空数据
        /// <summary>
        /// 获取空数据表
        /// 张繁 2013年6月20日
        /// </summary>
        /// <returns></returns>
        protected DataTable GetEmptyDataTable()
        {
            //创建table对象
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("IssueDate", typeof(String))); //合格证发证日期
            table.Columns.Add(new DataColumn("CarModel", typeof(String)));  //车辆型号
            table.Columns.Add(new DataColumn("CarColour", typeof(String))); //颜色
            table.Columns.Add(new DataColumn("EngineNo", typeof(String)));  //发动机号
            table.Columns.Add(new DataColumn("Vin", typeof(String)));       //车架号
            table.Columns.Add(new DataColumn("QualifiedNo", typeof(String)));   //合格证号
            table.Columns.Add(new DataColumn("KeyNumber", typeof(String)));      //钥匙号
            table.Columns.Add(new DataColumn("CarCost", typeof(String)));       //车辆金额
            table.Columns.Add(new DataColumn("Remark", typeof(String)));        //备注
            return table;
        }
        #endregion

        #region ViewState是否存在
        /// <summary>
        /// 判断当前数据集合是否存在
        /// </summary>
        /// <returns>返回datatabel</returns>
        private DataTable GetSourceData()
        {
            if (ViewState[Car_List] == null)
            {
                ViewState[Car_List] = GetEmptyDataTable();
            }
            return (DataTable)ViewState[Car_List];
        }
        #endregion

        #region 经销商信息
        /// <summary>
        /// 绑定经销商信息 张繁 2013年7月10日
        /// </summary>
        private void BindCompany()
        {
            try
            {
                int RoleId = this.CurrentUser.RoleId;       //获取角色id
                switch (RoleId)
                {
                    case 1:         //1为超级管理员
                        this.DDL_Company_Name.EnableEdit = true;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 order by D_L.DealerName").Tables[0];
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        this.DDL_Company_Name.EnableEdit = true;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 order by D_L.DealerName").Tables[0];
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        int UserID_5 = this.CurrentUser.UserId;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=5 and UserID=" + UserID_5 + ")").Tables[0];
                        break;
                    case 6:         //6为品牌专员
                        int UserID_6 = this.CurrentUser.UserId;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=6 and UserID=" + UserID_6 + ")").Tables[0];
                        break;
                    case 7:         //7为调配专员
                        break;
                    case 8:         //8为银行
                        break;
                    case 9:         //9为厂家
                        break;
                    case 10:         //10为监管员
                        int SupID = this.CurrentUser.RelationID.Value;
                        this.DDL_Number_Order.EnableEdit = true;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and SupervisorID='" + SupID + "' order by D_L.DealerName").Tables[0];
                        break;
                }
                DataTable da = ((DataTable)ViewState["DealerName"]).DefaultView.ToTable(true, "DealerName");
                this.DDL_Company_Name.DataTextField = "DealerName";

                this.DDL_Company_Name.DataValueField = "DealerName";
                this.DDL_Company_Name.DataSource = da;
                this.DDL_Company_Name.DataBind();
                DDL_Company_Name.Items.Insert(0, new FineUI.ListItem("——请选择——", "-1"));


            }
            catch
            {
                int RoleId = this.CurrentUser.RoleId;       //获取角色id
                switch (RoleId)
                {
                    case 1:         //1为超级管理员
                        FineUI.Alert.ShowInTop("超级管理员出错，请联系开发人员", FineUI.MessageBoxIcon.Error);
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        FineUI.Alert.ShowInTop("当前业务经理无法找到对应经销商", FineUI.MessageBoxIcon.Error);
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        FineUI.Alert.ShowInTop("当前市场专员无法找到对应经销商", FineUI.MessageBoxIcon.Error);
                        break;
                    case 6:         //6为业务专员
                        FineUI.Alert.ShowInTop("当前业务专员没有匹配对应银行", FineUI.MessageBoxIcon.Error);
                        break;
                    case 7:         //7为调配专员
                        break;
                    case 8:         //8为银行
                        break;
                    case 9:         //9为厂家
                        break;
                    case 10:         //10为监管员
                        FineUI.Alert.ShowInTop("当前监管员没有匹配经销商", FineUI.MessageBoxIcon.Error);
                        break;
                }

            }

        }
        #endregion

        #region 经销商下拉列表事件
        /// <summary>
        /// 根据经销商获取银行名称 张繁 2013年11月29日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_Company_Name_Changed(object sender, EventArgs e)
        {
            if (DDL_Company_Name.SelectedValue.ToString() == "-1")
            {
                FineUI.Alert.ShowInTop("请选择经销商", FineUI.MessageBoxIcon.Error);
                this.DDL_Bank.SelectedIndex = 0;
                this.DDL_Number_Order.SelectedIndex = 0;
                //汇票信息清空
                this.lbl_BeginTime.Text = "";
                this.lbl_EndTime.Text = "";
                this.TT_DraftMoney.Text = "";
                this.TT_DraftCarCountMoney.Text = "";
                this.TT_DraftNotMoney.Text = "";
            }
            else
            {
                this.DDL_Bank.DataTextField = "BankName";
                this.DDL_Bank.DataValueField = "BankID";
                //ViewState转换DataTable,查找经销商名称返回绑定
                DDL_Bank.DataSource = ((DataTable)ViewState["DealerName"]).Select("DealerName='" + DDL_Company_Name.SelectedValue.ToString() + "'");
                DDL_Bank.DataBind();
                DDL_Bank.Items.Insert(0, new FineUI.ListItem("——请选择——", "-1"));
            }
        }
        #endregion

        #region 删除Grid行
        protected void G_Car_Detail_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                GetSourceData().Rows.RemoveAt(e.RowIndex);
                G_Car_Detail.DataSource = GetSourceData();
                G_Car_Detail.DataBind();
                //FineUI.Alert.ShowInTop("删除第" + (e.RowIndex + 1) + "行数据成功！");
            }
        }
        #endregion

        #region 计算当前添加车辆总额
        /// <summary>
        /// 计算车辆总额 张繁 2013年7月17日 
        /// </summary>
        /// <param name="CarMoney"></param>
        private void GetCarCountMoney(string CarMoney)
        {
            string CountMoney = this.TT_CarCountMoney.Text.ToString().Split('：')[1].ToString();
            string DraftCarCountMoney = this.TT_DraftCarCountMoney.Text.ToString().Split('：')[1].ToString();
            if (CarMoney.Length == 0)
            {
                CountMoney = Convert.ToDouble(0 + CountMoney).ToString();
            }
            else
            {
                CountMoney = (Convert.ToDouble(CountMoney) + Convert.ToDouble(CarMoney)).ToString(); ;
            }
            this.TT_CarCountMoney.Text = "车辆总额：" + Convert.ToDouble(CountMoney);

        }
        #endregion

        #region 查询汇票详细信息
        /// <summary>
        /// 汇票详细信息 张繁 2013年7月17日 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_DraftNo_Changed(object sender, EventArgs e)
        {
            try
            {
                if (this.DDL_Number_Order.SelectedValue.ToString() != "-1")
                {
                    string DraftNo = "DraftNo='" + this.DDL_Number_Order.SelectedValue.ToString() + "'";
                    DataTable dt = (DataTable)ViewState["DraftNoList"];
                    DataRow[] dr = dt.Select(DraftNo);
                    this.lbl_BeginTime.Text = Convert.ToDateTime(dr[0]["BeginTime"]).ToString("yyyy-MM-dd");
                    this.lbl_EndTime.Text = Convert.ToDateTime(dr[0]["EndTime"]).ToString("yyyy-MM-dd");
                    //this.TT_DraftMoney.Text = "汇票总额：" + Convert.ToDouble(dr[0]["DarftMoney"].ToString());
                    //this.TT_DraftCarCountMoney.Text = "已押总额：" + Convert.ToDouble(dr[0]["CarAllMoney"].ToString());
                    //this.TT_DraftNotMoney.Text = "未押总额：" + (Convert.ToDouble(dr[0]["DarftMoney"].ToString()) - Convert.ToDouble(dr[0]["CarAllMoney"].ToString()));
                }
                else
                {
                    FineUI.Alert.ShowInTop("请选择汇票", FineUI.MessageBoxIcon.Error);
                    this.lbl_BeginTime.Text = "";
                    this.lbl_EndTime.Text = "";
                    this.TT_DraftMoney.Text = "";
                    this.TT_DraftCarCountMoney.Text = "";
                    this.TT_DraftNotMoney.Text = "";
                }
            }
            catch
            {
                FineUI.Alert.ShowInTop("读取汇票信息异常", FineUI.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 检查是否有特殊字符
        /// <summary>  
        ///  判断是否有非法字符
        /// </summary>  
        /// <param name="strString"></param>  
        /// <returns>返回TRUE表示有非法字符，返回FALSE表示没有非法字符。</returns>  
        public static bool CheckBadStr(string strString)
        {
            bool outValue = false;
            if (strString != null && strString.Length > 0)
            {
                string[] bidStrlist = new string[24];
                bidStrlist[0] = "'";
                bidStrlist[1] = ";";
                bidStrlist[2] = ":";
                bidStrlist[3] = "%";
                bidStrlist[4] = "@";
                bidStrlist[5] = "&";
                bidStrlist[6] = "#";
                bidStrlist[7] = "\"";
                bidStrlist[8] = "net user";
                bidStrlist[9] = "exec";
                bidStrlist[10] = "net localgroup";
                bidStrlist[11] = "select";
                bidStrlist[12] = "asc";
                bidStrlist[13] = "char";
                bidStrlist[14] = "mid";
                bidStrlist[15] = "insert";
                bidStrlist[16] = "order";
                bidStrlist[17] = "exec";
                bidStrlist[18] = "delete";
                bidStrlist[19] = "drop";
                bidStrlist[20] = "truncate";
                bidStrlist[21] = "xp_cmdshell";
                bidStrlist[22] = "<";
                bidStrlist[23] = ">";
                string tempStr = strString.ToLower();
                for (int i = 0; i < bidStrlist.Length; i++)
                {
                    if (tempStr.IndexOf(bidStrlist[i]) != -1)
                    {
                        outValue = true;
                        break;
                    }
                }
            }
            return outValue;
        }
        #endregion

        #region 检查是否有sql危险字符
        /// <summary>  
        /// 检测是否有Sql危险字符  
        /// </summary>  
        /// <param name="str">要判断字符串</param>  
        /// <returns>判断结果</returns>  
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }
        #endregion

        #region 银行下拉列表事件
        /// <summary>
        /// 银行下拉列表 张繁 2013年11月29日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.DDL_Bank.SelectedValue.ToString() != "-1")
                {
                    DataRow[] dr = ((DataTable)ViewState["DealerName"]).Select(string.Format("BankName='{0}' and BankID='{1}' and DealerName='{2}'", this.DDL_Bank.SelectedText.ToString(), this.DDL_Bank.SelectedValue.ToString(), this.DDL_Company_Name.SelectedValue.ToString()));
                    DataSet ds = new Draft().GetList("DealerID='" + dr[0].ItemArray[0].ToString() + "' and BankID='" + dr[0].ItemArray[2].ToString() + "' and DraftType=1 order by DraftNo desc");
                    this.DDL_Number_Order.DataTextField = "DraftNo";
                    this.DDL_Number_Order.DataValueField = "DraftNo";
                    ViewState["DraftNoList"] = ds.Tables[0];        //将数据集合放入ViewState
                    this.DDL_Number_Order.DataSource = (DataTable)ViewState["DraftNoList"];
                    this.DDL_Number_Order.DataBind();
                    this.DDL_Number_Order.Items.Insert(0, new FineUI.ListItem("——请选择汇票——", "-1"));

                }
                else
                {

                    FineUI.Alert.ShowInTop("请选择银行", FineUI.MessageBoxIcon.Error);
                }

            }
            catch
            {
                FineUI.Alert.ShowInTop("与服务器无法连接", FineUI.MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
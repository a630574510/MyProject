using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
namespace Citic_Web.Ledger
{
    public partial class Select_Ledger : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //清空ViewState中的数据
                ViewState.Clear();
            }
        }

        #region 绑定数据--乔春羽(2013.7.19)
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            //where条件
            string path = Common.OperateConfigFile.getValue("Dealer_Bank");
            string commandStr = Common.OperateConfigFile.getValue("Dealer_BankCommand");

            string[] dealerIDs = null;
            string[] bankIDs = null;
            //得到查询条件

            #region 选择了银行
            if (!string.IsNullOrEmpty(this.txt_Bank.Text))
            {
                if (this.txt_Bank.Text.IndexOf("_") > 0)
                {
                    string bankID = this.txt_Bank.Text.Split('_')[1];
                    bankIDs = new string[] { bankID };
                    dealerIDs = Dealer_BankBll.GetDealerIDsByBankID(int.Parse(bankID));
                }
                else
                {
                    DataSet tempds = null;
                    DataTable tempdt = null;
                    StringBuilder strWhere = new StringBuilder();
                    strWhere.AppendFormat("A.BankName like '%{0}%' ", this.txt_Bank.Text);
                    if (this.CurrentUser.RoleId == 10)  //监管员
                    {
                        string[] tempIDs = this.DealerBll.GetDealerIDsBySupervisorID(this.CurrentUser.RelationID.Value);
                        tempds = Dealer_BankBll.GetList(" A.DealerID in (" + string.Format((tempIDs == null || tempIDs.Length == 0) ? "0" : string.Join(",", tempIDs)) + ")");
                        if (tempds != null && tempds.Tables.Count > 0)
                        {
                            tempdt = tempds.Tables[0];
                            StringBuilder sbuilder = new StringBuilder();
                            sbuilder.Append(" AND A.BankID in (");
                            if (tempdt != null || tempdt.Rows.Count > 0)
                            {
                                foreach (DataRow row in tempdt.Rows)
                                {
                                    string bankID = row["BankID"].ToString();
                                    if (!sbuilder.ToString().Contains(bankID))
                                    {
                                        sbuilder.AppendFormat("{0},", bankID);
                                    }
                                }
                            }
                            else
                            {
                                sbuilder.Append("0");
                            }
                            sbuilder = sbuilder.Remove(sbuilder.ToString().LastIndexOf(","), 1);
                            sbuilder.Append(")");
                            strWhere.Append(sbuilder);
                        }
                    }
                    else if (this.CurrentUser.RoleId == 5 || this.CurrentUser.RoleId == 6)  //市场专员 or 业务专员
                    {
                        tempds = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                        if (tempds != null && tempds.Tables.Count > 0)
                        {
                            tempdt = tempds.Tables[0];
                            if (tempdt != null && tempdt.Rows.Count > 0)
                            {
                                string[] tempBankIDs = new string[tempdt.Rows.Count];
                                for (int i = 0; i < tempdt.Rows.Count; i++)
                                {
                                    tempBankIDs[i] = tempdt.Rows[i]["MappingID"].ToString();
                                }
                                strWhere.AppendFormat(" AND A.BankID in ({0})", (tempBankIDs == null || tempBankIDs.Length == 0) ? "0" : string.Join(",", tempBankIDs));
                            }
                            else
                            {
                                strWhere.Append(" A.BankID = '0' ");
                            }
                        }
                    }
                    else if (this.CurrentUser.RoleId == 8)  //银行
                    {
                        tempds = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                        if (tempds != null && tempds.Tables.Count > 0)
                        {
                            tempdt = tempds.Tables[0];
                            if (tempdt != null && tempdt.Rows.Count > 0)
                            {
                                strWhere.AppendFormat(" A.BankID = '{0}' ", tempdt.Rows[0]["MappingID"].ToString());
                            }
                            else
                            {
                                strWhere.Append(" A.BankID = '0' ");
                            }
                        }
                        else
                        {
                            strWhere.Append(" A.BankID = '0' ");
                        }
                    }

                    DataTable dt = this.Dealer_BankBll.GetList(strWhere.ToString()).Tables[0];

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        List<string> temp_BankIDs = new List<string>();
                        List<string> temp_DealerIDs = new List<string>();
                        foreach (DataRow row in dt.Rows)
                        {
                            if (!temp_BankIDs.Contains(row["BankID"].ToString()))
                            {
                                temp_BankIDs.Add(row["BankID"].ToString());
                            }
                            if (!temp_DealerIDs.Contains(row["DealerID"].ToString()))
                            {
                                temp_DealerIDs.Add(row["DealerID"].ToString());
                            }
                        }
                        bankIDs = temp_BankIDs.ToArray();
                        dealerIDs = temp_DealerIDs.ToArray();
                    }
                }
            }
            #endregion

            #region 选择了经销商
            if (!string.IsNullOrEmpty(this.txt_DealerName.Text))
            {
                if (this.txt_DealerName.Text.IndexOf("_") > 0)
                {
                    string dealerID = this.txt_DealerName.Text.Split('_')[1];
                    dealerIDs = new string[] { dealerID };
                    //bankIDs == null 说明用户在界面上没有选择银行
                    //既然没有选择银行，那就根据选择的经销商查询出所有的合作行
                    if (bankIDs == null)
                    {
                        bankIDs = this.Dealer_BankBll.GetBankIDsBySearch(string.Format("DealerID = '{0}'", dealerID));
                    }
                }
                else
                {
                    //根据输入的经销商名称，从经销商银行合作表中，查询出所有的经销商ID与合作行ID，结合权限过滤
                    DataSet tempds = null;
                    DataTable tempdt = null;
                    StringBuilder strWhere = new StringBuilder();
                    if (this.CurrentUser.RoleId == 10)  //监管员
                    {
                        string[] tempIDs = this.DealerBll.GetDealerIDsBySupervisorID(this.CurrentUser.RelationID.Value);
                        strWhere.AppendFormat(" A.DealerID in ({0}) ", (tempIDs == null || tempIDs.Length == 0) ? "0" : string.Join(",", tempIDs));
                        strWhere.AppendFormat(" AND A.DealerName like '%{0}%'", this.txt_DealerName.Text);
                    }
                    else if (this.CurrentUser.RoleId == 5 || this.CurrentUser.RoleId == 6)  //市场专员 or 业务专员
                    {
                        tempds = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                        if (tempds != null && tempds.Tables.Count > 0)
                        {
                            tempdt = tempds.Tables[0];
                            if (tempdt != null && tempdt.Rows.Count > 0)
                            {
                                string[] tempBankIDs = new string[tempdt.Rows.Count];
                                for (int i = 0; i < tempdt.Rows.Count; i++)
                                {
                                    tempBankIDs[i] = tempdt.Rows[i]["MappingID"].ToString();
                                }
                                strWhere.AppendFormat(" A.BankID in ({0})", (tempBankIDs == null || tempBankIDs.Length == 0) ? "0" : string.Join(",", tempBankIDs));
                            }
                            else
                            {
                                strWhere.Append(" A.BankID = '0' ");
                            }
                        }
                    }
                    else if (this.CurrentUser.RoleId == 8)  //银行
                    {
                        tempds = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                        if (tempds != null && tempds.Tables.Count > 0)
                        {
                            tempdt = tempds.Tables[0];
                            if (tempdt != null && tempdt.Rows.Count > 0)
                            {
                                strWhere.AppendFormat(" A.BankID = '{0}' ", tempdt.Rows[0]["MappingID"].ToString());
                            }
                            else
                            {
                                strWhere.Append(" A.BankID = '0' ");
                            }
                        }
                        else
                        {
                            strWhere.Append(" A.BankID = '0' ");
                        }
                    }

                    DataTable dt = this.Dealer_BankBll.GetList(strWhere.ToString()).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        List<string> temp_DealerIDs = new List<string>();
                        foreach (DataRow row in dt.Rows)
                        {
                            if (!temp_DealerIDs.Contains(row["DealerID"].ToString()))
                            {
                                temp_DealerIDs.Add(row["DealerID"].ToString());
                            }
                        }
                        dealerIDs = temp_DealerIDs.ToArray();

                        //bankIDs == null 说明用户在界面上没有选择银行
                        //既然没有选择银行，那就根据选择的经销商查询出所有的合作行
                        if (bankIDs == null)
                        {
                            List<string> temp_BankIDs = new List<string>();
                            foreach (DataRow row in dt.Rows)
                            {
                                if (!temp_BankIDs.Contains(row["BankID"].ToString()))
                                {
                                    temp_BankIDs.Add(row["BankID"].ToString());
                                }
                            }
                            bankIDs = temp_BankIDs.ToArray();
                        }
                    }
                }
            }
            #endregion

            DataSet dsBank = null;
            //权限过滤
            switch (this.CurrentUser.RoleId)
            {
                case 8: //银行
                    dsBank = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                    if (dsBank != null && dsBank.Tables.Count > 0)
                    {
                        DataTable dt = dsBank.Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            bankIDs = new string[] { dt.Rows[0]["MappingID"].ToString() };
                        }
                        else
                        {
                            bankIDs = new string[0];
                        }
                    }
                    break;
                case 5:
                case 6:
                    dsBank = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                    if (bankIDs == null || bankIDs.Length == 0)
                    {
                        if (dsBank != null && dsBank.Tables[0] != null && dsBank.Tables.Count > 0)
                        {
                            DataTable dt = dsBank.Tables[0];
                            bankIDs = new string[dt.Rows.Count];
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                bankIDs[i] = dt.Rows[i]["MappingID"].ToString();
                            }
                        }
                        else
                        {
                            bankIDs = new string[0];
                        }
                    }
                    break;
                case 10:
                    //根据监管员ID，查询其所监管的经销商
                    //if (dealerIDs == null || dealerIDs.Length == 0)
                    if (string.IsNullOrEmpty(this.txt_DealerName.Text))
                    {
                        dealerIDs = this.DealerBll.GetDealerIDsBySupervisorID(this.CurrentUser.RelationID.Value);
                    }
                    break;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;

            try
            {
                DataSet ds = Dealer_BankBll.LedgerSearch(Server.MapPath(path), commandStr, "1=1", string.Empty, rowbegin, rowend, bankIDs, dealerIDs);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        AlertShowInTop("没有数据！");
                    }
                    this.grid_List.RecordCount = dt.Rows.Count;
                    grid_List.DataSource = dt;
                    grid_List.DataBind();
                }
                else
                {
                    AlertShowInTop("没有数据！");
                    grid_List.DataSource = null;
                    grid_List.DataBind();
                }
            }
            catch (SqlException se)
            {
                AlertShowInTop(se.Message);
                AlertShowInTop("网络连接异常，请稍后再试。");
                Logging.WriteLog(se, HttpContext.Current.Request.Url.AbsolutePath, "GridBind()");
            }
        }

        /// <summary>
        /// 获得查询后结果的总数据数量--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return Dealer_BankBll.GetRecordCount(where);
        }
        #endregion

        #region 查询检索--乔春羽(2013.7.19)
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 加载合作银行信息--乔春羽
        private void BankDataBind()
        {
            DataTable dt = null;
            //监管员
            if (this.CurrentUser.RoleId == 10)
            {
                dt = Dealer_BankBll.GetBankIDAndNameFilterRole(this.CurrentUser.RelationID.Value).Tables[0];
            }
            //银行
            else if (this.CurrentUser.RoleId == 8)
            {
                Citic.Model.UserMapping model = UMBLL.GetModelByCondition(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                if (model != null)
                {
                    dt = BankBll.GetList(string.Format(" BankID='{0}' ", model.MappingID.Value.ToString())).Tables[0];
                }
            }
            //5.市场专员，6.品牌专员
            else if (this.CurrentUser.RoleId == 5 || this.CurrentUser.RoleId == 6)
            {
                StringBuilder ids = new StringBuilder(string.Empty);
                DataTable _dt = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId)).Tables[0];
                if (_dt != null && _dt.Rows.Count > 0)
                {
                    ids.Append(" T.BankID in (");
                    foreach (DataRow row in _dt.Rows)
                    {
                        ids.AppendFormat("{0},", row["MappingID"].ToString());
                    }
                    ids.Remove(ids.Length - 1, 1);
                    ids.Append(")");
                    dt = BankBll.GetList(ids.ToString()).Tables[0];
                }
            }
            else
            {
                dt = BankBll.GetList("IsDelete=0").Tables[0];
            }
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    ddl_Bank.DataTextField = "BankName";
            //    ddl_Bank.DataValueField = "BankID";
            //    ddl_Bank.DataSource = dt;
            //    ddl_Bank.DataBind();
            //}
            //AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }
        #endregion

        #region 导出Excel--乔春羽(2013.7.19)
        protected void btn_BuildExcel_Click(object sender, EventArgs e)
        {
            if (this.grid_List.Rows.Count <= 0)
            {
                AlertShowInTop("没有可导出的数据！");
                return;
            }
            //保存Excel文件
            string sheetName = "总账";
            string titleName = "总账信息";
            DataTable dt = null;
            dt = GetTableForGrid(grid_List);
            string[] headers = new string[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                headers[i] = dt.Columns[i].ColumnName;
            }
            string filePath = string.Empty;
            //保存当前页的数据
            filePath = "~/DownExcel/" + sheetName + ".xlsx";

            NPOIHelper npoi = new NPOIHelper();
            npoi.Create(titleName);

            //创建一行，并设定了行高
            IRow irow = npoi.CreateRow((short)60);
            //========================创建样式与字体================================
            //创建一个样式headerCellStyle
            //大标题样式
            string headerCellStyle = npoi.CreateCellStyle(NPOIAlign.Center, NPOIVAlign.Center, false, false, true);
            //给样式headerCellStyle附加字体对象
            npoi.CreateFont(headerCellStyle, 40, "黑体", NPOIFontBoldWeight.Bold, false, false);
            //创建了一个样式contentCellStyle。
            //表头样式
            string contentCellStyle = npoi.CreateCellStyle(NPOIAlign.Center, NPOIVAlign.Center, false, false, true);
            //给样式contentCellStyle附加了一个字体对象
            npoi.CreateFont(contentCellStyle, 10, "微软雅黑", NPOIFontBoldWeight.Bold, false, false);
            //内容样式
            string contentStyle = npoi.CreateCellStyle(NPOIAlign.Center, NPOIVAlign.Center, false, false, true);
            npoi.CreateFont(contentStyle, 10, "微软雅黑", NPOIFontBoldWeight.Normal, false, false);
            //========================创建样式与字体================================
            //表头大标题
            npoi.CreateCells(headers.Length, irow, headerCellStyle);
            npoi.SetCellValue(irow, 0, titleName);
            npoi.SetCellRangeAddress(0, 0, 0, headers.Length - 1);
            //表头小标题
            IRow rowHeader = npoi.CreateRow();
            npoi.CreateCells(headers, rowHeader, contentCellStyle);

            npoi.DataTableToExcel(dt, contentStyle);

            //保存文件
            filePath = "~/DownExcel/" + sheetName + ".xlsx";
            npoi.Save(Server.MapPath(filePath));

            //显示下载地址
            hl_ExportExcel.NavigateUrl = filePath;

        }
        #endregion

        #region 数据行命令事件--乔春羽(2013.7.19)
        protected void grid_List_RowCommand(object sender, GridCommandEventArgs e)
        {

        }
        #endregion
    }
}
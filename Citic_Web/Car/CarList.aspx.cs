using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using Citic.BLL;

namespace Citic_Web.Car
{
    public partial class CarList : BasePage
    {

        #region Load事件
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDealer();
            }

        }
        #endregion

        #region 状态绑定
        /// <summary>
        /// 根据状态查询多少条数据
        /// </summary>
        /// <param name="Statu">状态</param>
        /// <param name="top">条数</param>
        private void dataBind(string Statu, int top)
        {

            DataRow[] dr = ((DataTable)ViewState["DealerName"]).Select(string.Format("DealerName='{0}' and ID='{1}'", this.ddl_Dealer.SelectedText, this.ddl_Dealer.SelectedValue));

            string tb_Name = "tb_Car_" + dr[0].ItemArray[2].ToString() + "_" + dr[0].ItemArray[0].ToString();  //sql表名拼接    2014年5月14日
            string sql = string.Empty;
            if (top == 0)
            {
                sql = " Statu='" + Statu + "' and IsDelete=0";
            }
            else
            {
                sql = " Statu='" + Statu + "' and IsDelete=0";
            }
            DataSet ds = new Citic.BLL.Car().GetList(sql, tb_Name);
            this.grid_List.DataSource = ds;
            this.grid_List.DataBind();
        }
        #endregion

        #region 下一页
        protected void grid_List_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            grid_List.PageIndex = e.NewPageIndex;
            DataBind_List();
        }
        #endregion

        #region 状态按钮事件
        protected void Btn_Car_All(object sender, EventArgs e)
        {
            FineUI.Button btn = (FineUI.Button)sender;
            switch (btn.ID)
            {
                case "Btn_Store_100":      //在库-1000
                    this.Btn_Batch_OutBound.Enabled = true;
                    dataBind("1", 100);
                    break;
                case "Btn_Move_100":       //移动-1000
                    this.Btn_Batch_OutBound.Enabled = true;
                    dataBind("2", 100);
                    break;
                case "Btn_OutBound_100":     //出库-1000
                    this.Btn_Batch_OutBound.Enabled = false;
                    dataBind("0", 100);
                    break;
                case "Btn_Transit_100":        //在途-1000
                    this.Btn_Batch_OutBound.Enabled = false;
                    dataBind("3", 100);
                    break;
                case "Btn_ApplyFor_100":       //申请中-1000
                    this.Btn_Batch_OutBound.Enabled = false;
                    dataBind("4", 100);
                    break;
                case "Btn_Store_All":           //在库-全部
                    this.Btn_Batch_OutBound.Enabled = true;
                    dataBind("1", 0);
                    break;
                case "Btn_Move_All":            //移动-全部
                    this.Btn_Batch_OutBound.Enabled = true;
                    dataBind("2", 0);
                    break;
                case "Btn_OutBound_All":        //出库-全部
                    this.Btn_Batch_OutBound.Enabled = false;
                    dataBind("0", 0);
                    break;
                case "Btn_Transit_All":         //在途-全部
                    this.Btn_Batch_OutBound.Enabled = false;
                    dataBind("3", 0);
                    break;
                case "Btn_ApplyFor_All":        //申请中-全部
                    this.Btn_Batch_OutBound.Enabled = false;
                    dataBind("4", 0);
                    break;
                case "Btn_Batch_OutBound":      //批量申请出库
                    Car_Batch_OutBound();
                    break;
            }
        }
        #endregion

        #region 批量出库
        /// <summary>
        /// 批量申请车辆出库
        /// </summary>
        private void Car_Batch_OutBound()
        {
            int Select_Count = grid_List.SelectedRowIndexArray.Length; //获取选中行总数
            if (Select_Count > 0)
            {
                string sql = "update ZX_Clxx set PROPERTY=3 where ";   //修改sql语句
                for (int i = 0; i < Select_Count; i++)
                {
                    int Index = grid_List.SelectedRowIndexArray[i];         //获取当前行号索引
                    //string Vin = grid_List.Rows[Index].Values[0].ToString();    //获取多少行的第几个值
                    string Vin = grid_List.Rows[Index].DataKeys[0].ToString();    //获取当前行号绑定Key值
                    sql += "ID_CJ='" + Vin + "' or ";         //拼接批量修改sql语句的条件
                }
                sql = sql.Remove(sql.LastIndexOf("or"));
                SqlConnection con = new SqlConnection("server=.;database=CITIC_Capital_Manage;uid=sa;pwd=sasa;");
                con.Open();
                SqlCommand com = new SqlCommand(sql, con);
                int number = com.ExecuteNonQuery();
                con.Close();
                if (number > 0)
                {
                    FineUI.Alert.Show("申请成功！", FineUI.MessageBoxIcon.Information);
                }
                else
                {
                    FineUI.Alert.Show("申请失败！", FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.Show("没有选择任何行！", FineUI.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 查询按钮事件
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            ViewState.Remove("CatList");    //移除
            try
            {
                DataBind_List();
                
            }
            catch
            {
                //2014年5月23日
                FineUI.Alert.ShowInTop("数据量太大,请选择条件查询", FineUI.MessageBoxIcon.Error);
            }


        }

        private void DataBind_List()
        {
            DataRow[] dr = ((DataTable)ViewState["DealerName"]).Select(string.Format("DealerName='{0}' and ID='{1}'", this.ddl_Dealer.SelectedText, this.ddl_Dealer.SelectedValue));

            string tb_Name = "tb_Car_" + dr[0].ItemArray[2].ToString() + "_" + dr[0].ItemArray[0].ToString();  //sql表名拼接

            StringBuilder sb = new StringBuilder("IsDelete=0 ");
            if (!string.IsNullOrEmpty(this.txt_Vin.Text.Trim()))        //车架号
            {
                string[] Vin = this.txt_Vin.Text.ToString().Split(',');
                sb.Append(" and Vin like '%" + Vin[0].ToString().Trim() + "%'");
                if (Vin.Length > 1)
                {
                    for (int i = 1; i < Vin.Length; i++)
                    {
                        sb.Append(" or Vin like '%" + Vin[i] + "%'");
                    }
                }
            }
            if (!string.IsNullOrEmpty(this.txt_Number_Order.Text.Trim()))      //汇票号 
            {
                sb.Append(" and DraftNo like '%" + this.txt_Number_Order.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_EngineNo.Text.Trim()))      //发动机
            {
                string[] EngineNo = this.txt_EngineNo.Text.ToString().Split(',');
                sb.Append(" and EngineNo like '%" + EngineNo[0].ToString().Trim() + "%'");
                if (EngineNo.Length > 1)
                {
                    for (int i = 1; i < EngineNo.Length; i++)
                    {
                        sb.Append(" or EngineNo like '%" + EngineNo[i] + "%'");
                    }
                }
            }
            if (!string.IsNullOrEmpty(this.txt_QualifiedNo.Text.Trim()))       //合格证
            {
                string[] QualifiedNo = this.txt_QualifiedNo.Text.ToString().Split(',');
                sb.Append(" and QualifiedNo like '%" + QualifiedNo[0].ToString().Trim() + "%'");
                if (QualifiedNo.Length > 1)
                {
                    for (int i = 1; i < QualifiedNo.Length; i++)
                    {
                        sb.Append(" or QualifiedNo like '%" + QualifiedNo[i] + "%'");
                    }
                }
            }
            if (!string.IsNullOrEmpty(this.dp_Release_Begin.Text.Trim()) && !string.IsNullOrEmpty(this.dp_Release_End.Text.Trim()))    //释放时间
            {
                sb.Append(" and OutTime between '" + this.dp_Release_Begin.Text.Trim() + "' and '" + this.dp_Release_End.SelectedDate.Value.AddDays(+1).ToString("yyyy-MM-dd") + "'");
            }
            if (!string.IsNullOrEmpty(this.dp_Access_Begin.Text.Trim()) && !string.IsNullOrEmpty(this.dp_Access_End.Text.Trim()))       //入库时间
            {
                sb.Append(" and TransitTime between '" + this.dp_Access_Begin.Text + "' and '" + this.dp_Access_End.SelectedDate.Value.AddDays(+1).ToString("yyyy-MM-dd") + "'");
            }
            if (this.ddl_Statu.SelectedValue != "-1")
            {
                sb.Append(" and Statu='" + ddl_Statu.SelectedValue.ToString() + "'");
            }

            //指定总记录数
            grid_List.RecordCount = CarBll.GetRecordCount(sb.ToString(), tb_Name);

            if (this.grid_List.RecordCount != 0)
            {
                if (this.grid_List.PageCount < this.grid_List.PageIndex)
                {
                    this.grid_List.PageIndex = 0;
                }

                int pageIndex = grid_List.PageIndex;
                int pageSize = grid_List.PageSize;
                int rowbegin = pageIndex * pageSize + 1;
                int rowend = (pageIndex + 1) * pageSize;
                DataSet ds = CarBll.GetListByPage(sb.ToString(), "", rowbegin, rowend, tb_Name);
                ViewState["CatList"] = ds;
                this.grid_List.DataSource = ViewState["CatList"];
                this.grid_List.DataBind();
                this.Btn_Batch_OutBound.Enabled = false;

            }
            else
            {
                FineUI.Alert.ShowInTop("无法查询到输入条件的车辆信息", FineUI.MessageBoxIcon.Information);
            }

        }
        #endregion

        #region Gird状态绑定事件
        protected void grid_List_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            string Statu = grid_List.Rows[e.RowIndex].Values[11].ToString();
            switch (Statu)
            {
                case "1":
                    grid_List.Rows[e.RowIndex].Values[11] = "在库";
                    break;
                case "2":
                    grid_List.Rows[e.RowIndex].Values[11] = "移动";
                    break;
                case "0":
                    grid_List.Rows[e.RowIndex].Values[11] = "出库";
                    break;
                case "4":
                    grid_List.Rows[e.RowIndex].Values[11] = "申请中";
                    break;
                case "3":
                    grid_List.Rows[e.RowIndex].Values[11] = "在途";
                    break;
            }
        }
        #endregion

        #region 绑定经销商
        /// <summary>
        /// 绑定经销商
        /// </summary>
        private void BindDealer()
        {
            try
            {
                int RoleId = this.CurrentUser.RoleId;       //获取角色id
                switch (RoleId)
                {
                    case 1:         //1为超级管理员
                        this.ddl_Dealer.EnableEdit = true;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 order by D_L.DealerName").Tables[0];
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        this.ddl_Dealer.EnableEdit = true;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 order by D_L.DealerName").Tables[0];
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        this.ddl_Dealer.EnableEdit = true;
                        int UserID_5 = this.CurrentUser.UserId;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=5 and UserID=" + UserID_5 + ")").Tables[0];
                        break;
                    case 6:         //6为品牌专员
                        this.ddl_Dealer.EnableEdit = true;
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
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and SupervisorID='" + SupID + "' order by D_L.DealerName").Tables[0];
                        break;
                }
                this.ddl_Dealer.DataTextField = "DealerName";
                this.ddl_Dealer.DataValueField = "ID";
                this.ddl_Dealer.DataSource = ((DataTable)ViewState["DealerName"]);
                this.ddl_Dealer.DataBind();
                this.ddl_Dealer.SelectedIndex = 0;
                DataRow[] dr = ((DataTable)ViewState["DealerName"]).Select(string.Format("DealerName='{0}' and ID='{1}'", this.ddl_Dealer.SelectedText, this.ddl_Dealer.SelectedValue));
                this.lbl_Cooperation_Bank.Text = dr[0].ItemArray[3].ToString();
                this.lbl_BrandName.Text = dr[0].ItemArray[5].ToString();
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

        #region 根据车架查询所有信息
        /// <summary>
        /// 根据车架查询所有信息
        /// </summary>
        /// <param name="Vin">车架</param>
        /// <returns>返回DataRow</returns>
        private DataRow FindDataRowByVin(string Vin)
        {
            DataTable table = ((DataSet)ViewState["CatList"]).Tables[0];

            foreach (DataRow row in table.Rows)
            {
                if (row["Vin"].ToString() == Vin)
                {
                    return row;
                }
            }
            return null;
        }
        #endregion

        #region 经销商下拉列表事件
        /// <summary>
        /// 经销商下拉列表事件，绑定银行，品牌信息       张繁 2013年11月19日 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_Dealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] dr = ((DataTable)ViewState["DealerName"]).Select(string.Format("DealerName='{0}' and ID='{1}'", this.ddl_Dealer.SelectedText, this.ddl_Dealer.SelectedValue));
            this.lbl_Cooperation_Bank.Text = dr[0].ItemArray[3].ToString();
            this.lbl_BrandName.Text = dr[0].ItemArray[5].ToString();
        }
        #endregion
    }
}
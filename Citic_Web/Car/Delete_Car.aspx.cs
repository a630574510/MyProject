using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Citic.BLL;
using System.Text;
using System.Data.SqlClient;
namespace Citic_Web.Car
{
    public partial class Delete_Car : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DealerBind();
            }
        }
        #region 经销商绑定
        /// <summary>
        /// 经销商绑定 张繁 2013年8月16日
        /// </summary>
        private void DealerBind()
        {
            DataSet ds = new Dealer().GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 order by D_L.DealerName");
            this.ddl_Dealer.DataTextField = "DealerName";
            this.ddl_Dealer.DataValueField = "DealerID";
            this.ddl_Dealer.DataSource = ds;
            this.ddl_Dealer.DataBind();
            this.ddl_Dealer.SelectedIndex = 0;
            this.lbl_Cooperation_Bank.Text = this.ddl_Dealer.SelectedValue.ToString().Split('_')[2].ToString();
        }
        #endregion
        #region 经销商列表事件


        /// <summary>
        /// 经销商事件 张繁 2013年8月16日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_Dealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Values = ddl_Dealer.SelectedValue;
            if (Values != null)
            {
                this.lbl_Cooperation_Bank.Text = Values.Split('_')[2].ToString();
            }

        }
        #endregion
        #region 查询
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            if (ddl_Dealer.SelectedValue != null)
            {
                if (this.txt_Vin.Text.Trim().Length != 0 || txt_Number_Order.Text.Trim().Length != 0 || txt_EngineNo.Text.Trim().Length != 0 || txt_QualifiedNo.Text.Trim().Length != 0)
                {
                    if (this.txt_Vin.Text.Trim().Length >= 5 || txt_Number_Order.Text.Trim().Length >= 5 || txt_EngineNo.Text.Trim().Length >= 5 || txt_QualifiedNo.Text.Trim().Length >= 5)
                    {
                        ViewState.Remove("CatList");    //移除
                        string[] tb_Name_Count = this.ddl_Dealer.SelectedValue.ToString().Split('_');
                        string tb_Name = "tb_Car_" + tb_Name_Count[0] + "_" + tb_Name_Count[1].ToString();

                        StringBuilder sb = new StringBuilder("IsDelete=0 ");
                        if (!string.IsNullOrEmpty(this.txt_Vin.Text.Trim()))        //车架号
                        {
                            sb.Append(" and Vin like '%" + this.txt_Vin.Text.Trim() + "%'");
                        }
                        else if (!string.IsNullOrEmpty(this.txt_Number_Order.Text.Trim()))      //汇票号 
                        {
                            sb.Append(" and DraftNo like '%" + this.txt_Number_Order.Text.Trim() + "%'");
                        }
                        else if (!string.IsNullOrEmpty(this.txt_EngineNo.Text.Trim()))      //发动机
                        {
                            sb.Append(" and EngineNo like '%" + this.txt_EngineNo.Text.Trim() + "%'");
                        }
                        else if (!string.IsNullOrEmpty(this.txt_QualifiedNo.Text.Trim()))       //合格证
                        {
                            sb.Append(" and QualifiedNo like '%" + this.txt_QualifiedNo.Text.Trim() + "%'");
                        }
                        DataSet ds = new Citic.BLL.Car().GetAllList(sb.ToString(), tb_Name);
                        ViewState["CatList"] = ds.Tables[0];
                        this.G_Car_List.DataSource = ds;
                        this.G_Car_List.DataBind();
                    }
                    else
                    {
                        FineUI.Alert.Show("请填写正确查询条件", FineUI.MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    FineUI.Alert.Show("请填写查询条件", FineUI.MessageBoxIcon.Warning);
                }
            }
        }
        #endregion
        #region 逻辑删除
        protected void btn_Logic_Del_Click(object sender, EventArgs e)
        {
            string[] tb_Name_Count = this.ddl_Dealer.SelectedValue.ToString().Split('_');   //获取拼接经销商信息
            string tb_Name = "tb_Car_" + tb_Name_Count[0] + "_" + tb_Name_Count[1].ToString();  //拼接表名
            int[] SelectCount = G_Car_List.SelectedRowIndexArray;           //获取当前gird选中行集合
            if (SelectCount.Length > 0)
            {
                try
                {
                    List<string> List_Sql = new List<string>();     //存放sql集合
                    string sql_Del = "delete " + tb_Name + " where Vin in(";        //删除
                    string Draft_Sql = string.Empty;
                    DataTable dt = (DataTable)ViewState["CatList"];
                    for (int i = 0; i < SelectCount.Length; i++)
                    {
                        string Vin = G_Car_List.Rows[SelectCount[i]].DataKeys[0].ToString();        //获取绑定车架

                        sql_Del += "'" + Vin + "',";        //拼接删除
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["Vin"].ToString() == Vin)
                            {
                                dt.Rows.Remove(dr);
                                break;
                            }
                        }
                    }
                    sql_Del = sql_Del.Remove(sql_Del.LastIndexOf(',')) + ")";   //截取删除语句
                    List_Sql.Add(sql_Del);              //添加删除语句
                    int Number = new Citic.BLL.Car().SqlTran(List_Sql);
                    //int Number = 0;
                    if (Number > 0)
                    {
                        FineUI.Alert.Show("删除成功");
                        G_Car_List.DataSource = ((DataTable)ViewState["CatList"]);
                        G_Car_List.DataBind();

                    }
                    else
                    {
                        FineUI.Alert.Show("删除成功");
                    }
                }
                catch
                {
                    FineUI.Alert.Show("连接失败,请联系管理员", FineUI.MessageBoxIcon.Error);
                }


            }
            else
            {
                FineUI.Alert.Show("没有选择任何行", FineUI.MessageBoxIcon.Warning);
            }
        }
        #endregion
        #region gird行绑定
        protected void G_Car_List_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            string Statu = G_Car_List.Rows[e.RowIndex].Values[11].ToString();
            switch (Statu)
            {
                case "1":
                    G_Car_List.Rows[e.RowIndex].Values[11] = "在库";
                    break;
                case "2":
                    G_Car_List.Rows[e.RowIndex].Values[11] = "移动";
                    break;
                case "0":
                    G_Car_List.Rows[e.RowIndex].Values[11] = "出库";
                    break;
                case "4":
                    G_Car_List.Rows[e.RowIndex].Values[11] = "申请中";
                    break;
                case "3":
                    G_Car_List.Rows[e.RowIndex].Values[11] = "在途";
                    break;
            }
        }
        #endregion

        protected void btn_Physics_Del_Click(object sedner, EventArgs e)
        {
            string[] tb_Name_Count = this.ddl_Dealer.SelectedValue.ToString().Split('_');   //获取拼接经销商信息
            string tb_Name = "tb_Car_" + tb_Name_Count[0] + "_" + tb_Name_Count[1].ToString();  //拼接表名
            int[] SelectCount = G_Car_List.SelectedRowIndexArray;           //获取当前gird选中行集合
            if (SelectCount.Length > 0)
            {
                try
                {
                    List<string> List_Sql = new List<string>();     //存放sql集合
                    string sql_Del = "delete " + tb_Name + " where Vin in(";        //删除
                    string Draft_Sql = string.Empty;
                    DataTable dt = (DataTable)ViewState["CatList"];
                    for (int i = 0; i < SelectCount.Length; i++)
                    {
                        string Vin = G_Car_List.Rows[SelectCount[i]].DataKeys[0].ToString();        //获取绑定车架
                        sql_Del += "'" + Vin + "',";        //拼接删除
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["Vin"].ToString() == Vin)
                            {
                                dt.Rows.Remove(dr);
                                break;
                            }
                        }
                    }

                    sql_Del = sql_Del.Remove(sql_Del.LastIndexOf(',')) + ")";   //截取删除语句
                    List_Sql.Add(sql_Del);              //添加删除语句
                    int Number = new Citic.BLL.Car().SqlTran(List_Sql);
                    if (Number > 0)
                    {
                        FineUI.Alert.Show("删除成功");
                        G_Car_List.DataSource = ((DataTable)ViewState["CatList"]);
                        G_Car_List.DataBind();

                    }
                    else
                    {
                        FineUI.Alert.Show("删除成功");
                    }
                }
                catch
                {
                    FineUI.Alert.Show("连接失败,请联系管理员", FineUI.MessageBoxIcon.Error);
                }

            }
        }
    }
}
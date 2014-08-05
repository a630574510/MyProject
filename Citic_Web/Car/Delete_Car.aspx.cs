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
    public partial class Delete_Car : BasePage
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
            DataTable dt = Dealer_BankBll.GetListAll("IsDelete=0 and CollaborateType=1 order by DealerName").Tables[0];
            //DataTable dt = new Dealer().GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 order by D_L.DealerName").Tables[0];
            //DataTable dt = DealerBll.GetAllList().Tables[0];
            //ViewState["DealerList"] = dt;
            this.ddl_Dealer.DataTextField = "DealerName";
            this.ddl_Dealer.DataValueField = "ID";
            this.ddl_Dealer.DataSource = dt;
            this.ddl_Dealer.DataBind();
            this.ddl_Dealer.Items.Insert(0, new FineUI.ListItem("——请选择——", "-1"));
            this.ddl_Dealer.SelectedIndex = 0;

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
            if (!this.ddl_Dealer.SelectedValue.Equals("-1"))
            {
                int id = int.Parse(this.ddl_Dealer.SelectedValue.ToString());
                DataTable dt = Dealer_BankBll.GetListAll(string.Format("IsDelete=0 and CollaborateType=1 and ID='{0}'", id)).Tables[0];
                this.lbl_Cooperation_Bank.Text = dt.Rows[0]["BankName"].ToString();
                ViewState["tb_Name"] = string.Format("tb_Car_{0}_{1}", dt.Rows[0]["BankID"].ToString(), dt.Rows[0]["DealerID"].ToString());
                if (dt.Rows[0]["GD_ID"].ToString().Length != 0 || dt.Rows[0]["ZX_ID"].ToString().Length != 0)
                {
                    this.btn_Del_GD.Enabled = true;
                    this.btn_Physics_Del.Enabled = false;
                }
                else
                {
                    this.btn_Physics_Del.Enabled = true;
                    this.btn_Del_GD.Enabled = false;
                }
                //DataRow[] dr = ((DataTable)ViewState["DealerList"]).Select(string.Format("DealerName='{0}' and ID='{1}'", this.ddl_Dealer.SelectedText.ToString().Trim(), this.ddl_Dealer.SelectedValue.ToString()));
                //this.lbl_Cooperation_Bank.Text = dr[0].ItemArray[3].ToString();
            }
            else
            {
                FineUI.Alert.ShowInTop("请选择经销商", FineUI.MessageBoxIcon.Error);
            }

        }
        #endregion
        #region 查询
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ddl_Dealer.SelectedValue.Equals("-1"))
                {
                    if (this.txt_Vin.Text.Trim().Length != 0 || txt_Number_Order.Text.Trim().Length != 0 || txt_EngineNo.Text.Trim().Length != 0 || txt_QualifiedNo.Text.Trim().Length != 0)
                    {
                        if (this.txt_Vin.Text.Trim().Length >= 5 || txt_Number_Order.Text.Trim().Length >= 5 || txt_EngineNo.Text.Trim().Length >= 5 || txt_QualifiedNo.Text.Trim().Length >= 5)
                        {
                            ViewState.Remove("CatList");    //移除
                            //DataRow[] dr_List = ((DataTable)ViewState["DealerList"]).Select(string.Format("DealerName='{0}' and ID='{1}'", this.ddl_Dealer.SelectedText.ToString().Trim(), this.ddl_Dealer.SelectedValue.ToString()));

                            //string tb_Name = "tb_Car_" + dr_List[0].ItemArray[2].ToString() + "_" + dr_List[0].ItemArray[0].ToString();  //拼接表名
                            string tb_Name = ViewState["tb_Name"].ToString();
                            StringBuilder sb = new StringBuilder("IsDelete=0 ");
                            if (!string.IsNullOrEmpty(this.txt_Vin.Text.Trim()))        //车架号
                            {
                                sb.Append(" and Vin in('" + this.txt_Vin.Text.Trim() + "')");
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
                            DataTable dt = CarBll.GetAllList(sb.ToString(), tb_Name).Tables[0];
                            if (dt.Rows.Count != 0)
                            {

                                ViewState["CatList"] = dt;
                                this.G_Car_List.DataSource = dt;
                                this.G_Car_List.DataBind();
                            }
                            else
                            {
                                FineUI.Alert.Show("搜索不到对应条件车辆信息", FineUI.MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            FineUI.Alert.Show("请填写正确查询条件", FineUI.MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        FineUI.Alert.Show("请填写正确查询条件", FineUI.MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    FineUI.Alert.Show("请选择经销商", FineUI.MessageBoxIcon.Warning);
                }
            }
            catch
            {
                FineUI.Alert.Show("查询出错,刷新后查询", FineUI.MessageBoxIcon.Error);
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
            int[] SelectCount = G_Car_List.SelectedRowIndexArray;           //获取当前gird选中行集合
            if (SelectCount.Length > 0)
            {
                try
                {

                    //DataRow[] dr_List = ((DataTable)ViewState["DealerList"]).Select(string.Format("DealerName='{0}' and ID='{1}'", this.ddl_Dealer.SelectedText.ToString().Trim(), this.ddl_Dealer.SelectedValue.ToString()));

                    //string tb_Name = "tb_Car_" + dr_List[0].ItemArray[2].ToString() + "_" + dr_List[0].ItemArray[0].ToString();  //拼接表名
                    string tb_Name = ViewState["tb_Name"].ToString();
                    List<string> List_Sql = new List<string>();     //存放sql集合
                    string sql_Del = "delete " + tb_Name + " where ID in(";        //删除
                    string sql_dbsx = "delete tb_DBSX_List where Vin in (";     //待办事删除
                    string Draft_Sql = string.Empty;
                    DataTable dt = (DataTable)ViewState["CatList"];
                    List<string> List_Draft_Sql = new List<string>();
                    for (int i = 0; i < SelectCount.Length; i++)
                    {
                        string Vin = G_Car_List.Rows[SelectCount[i]].DataKeys[0].ToString();        //获取绑定车架
                        string ID = G_Car_List.Rows[SelectCount[i]].DataKeys[1].ToString();

                        sql_Del += "'" + ID + "',";        //拼接删除
                        sql_dbsx += "'" + Vin + "',";       //待办事删除
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["Vin"].ToString() == Vin)
                            {
                                dt.Rows.Remove(dr);
                                break;
                            }
                        }
                        List_Draft_Sql.Add(G_Car_List.Rows[SelectCount[i]].DataKeys[2].ToString());
                    }

                    sql_Del = sql_Del.Remove(sql_Del.LastIndexOf(',')) + ")";   //截取删除语句
                    List_Sql.Add(sql_Del);              //添加删除语句
                    sql_dbsx = sql_dbsx.Remove(sql_dbsx.LastIndexOf(',')) + ")";
                    List_Sql.Add(sql_dbsx);     //待办事删除
                    int Number = CarBll.SqlTran(List_Sql);
                    DraftBll.UpdateDraftMoney(List_Draft_Sql.ToArray());
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

        protected void btn_Del_GD_Click(object sender, EventArgs e)
        {
            int[] SelectCount = G_Car_List.SelectedRowIndexArray;           //获取当前gird选中行集合
            if (SelectCount.Length > 0)
            {
                try
                {
                    string tb_Name = ViewState["tb_Name"].ToString();
                    List<string> List_Sql = new List<string>();     //存放sql集合
                    string sql_Del = "delete " + tb_Name + " where ID in(";        //删除
                    string Draft_Sql = string.Empty;
                    DataTable dt = (DataTable)ViewState["CatList"];
                    List<string> List_Draft_Sql = new List<string>();
                    string sql_dbsx = "delete tb_DBSX_List where Vin in (";     //待办事删除
                    string ErrorTxt = string.Empty;
                    for (int i = 0; i < SelectCount.Length; i++)
                    {
                        string Vin = G_Car_List.Rows[SelectCount[i]].DataKeys[0].ToString();        //获取绑定车架
                        string ID = G_Car_List.Rows[SelectCount[i]].DataKeys[1].ToString();
                        string[] CarList = G_Car_List.Rows[i].Values;
                        if (CarList[11].ToString() == "在途")
                        {
                            sql_Del += "'" + ID + "',";        //拼接删除
                            sql_dbsx += "'" + Vin + "',";       //待办事删除
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["Vin"].ToString() == Vin)
                                {
                                    dt.Rows.Remove(dr);
                                    break;
                                }
                            }
                            List_Draft_Sql.Add(G_Car_List.Rows[SelectCount[i]].DataKeys[2].ToString());
                        }
                        else
                        {
                            ErrorTxt = "第" + (i + 1) + "行状态不让删除";
                            break;
                        }
                    }
                    if (ErrorTxt.Length == 0)
                    {
                        sql_Del = sql_Del.Remove(sql_Del.LastIndexOf(',')) + ")";   //截取删除语句
                        List_Sql.Add(sql_Del);              //添加删除语句
                        sql_dbsx = sql_dbsx.Remove(sql_dbsx.LastIndexOf(',')) + ")";
                        List_Sql.Add(sql_dbsx);     //待办事删除
                        int Number = CarBll.SqlTran(List_Sql);
                        DraftBll.UpdateDraftMoney(List_Draft_Sql.ToArray());
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
                    else
                    {
                        FineUI.Alert.ShowInTop(ErrorTxt, FineUI.MessageBoxIcon.Error);
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
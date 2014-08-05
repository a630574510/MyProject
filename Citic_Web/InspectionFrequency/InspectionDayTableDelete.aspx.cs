using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Citic_Web.InspectionFrequency
{
    public partial class InspectionDayTableDelete : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txt_Time.SelectedDate = DateTime.Now;
                ViewState.Clear();
            }
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("IsDel=0");
            if (!string.IsNullOrEmpty(this.txt_SupervisorName.Text.Trim()))        //监管员
            {
                sb.Append(" and Area like '%" + this.txt_SupervisorName.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_Bank.Text.Trim()))      //合作银行
            {
                sb.Append(" and Bank like '%" + this.txt_Bank.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_BrandName.Text.Trim()))      //品牌
            {
                sb.Append(" and BrandName like '%" + this.txt_BrandName.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_Time.Text.Trim()))      //检查时间
            {
                sb.Append(" and CONVERT(varchar(10),CreateTime,23) like '%" + this.txt_Time.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_Rummager.Text.Trim()))      //检查人员
            {
                sb.Append(" and Rummager like '%" + this.txt_Rummager.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_DealerName.Text.Trim()))      //经销店名称
            {
                sb.Append(" and DealerName like '%" + this.txt_DealerName.Text.Trim() + "%'");
            }
            DataSet ds = new Citic.BLL.Inspection().GetList(sb.ToString());
            ViewState["InspectionDay"] = ds.Tables[0];
            this.G_DayTabel.DataSource = (DataTable)ViewState["InspectionDay"];
            this.G_DayTabel.DataBind();

        }
        #region 逻辑删除
        /// <summary>
        /// 逻辑删除 张繁 2013年8月14日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Logic_Del_Click(object sender, EventArgs e)
        {
            int[] selectCount = G_DayTabel.SelectedRowIndexArray;

            if (selectCount.Length > 0)
            {
                string UserName = CurrentUser.TrueName;
                string UserId = CurrentUser.UserId.ToString();
                string sql = "update tb_InspectionDay set isDel=1,DelTime='" + DateTime.Now + "',DelId='" + UserId + "' where id in(";
                DataTable dt = (DataTable)ViewState["InspectionDay"];
                for (int i = 0; i < selectCount.Length; i++)
                {
                    string id = G_DayTabel.Rows[selectCount[i]].DataKeys[0].ToString();
                    sql += id + ",";
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"].ToString() == id)
                        {
                            dt.Rows.Remove(dr);
                            break;
                        }
                    }
                }
                SqlConnection con = new SqlConnection("server=192.168.0.106;database=Citic_Pledge_Manage;uid=sa;pwd=sasa;");
                sql = sql.Remove(sql.LastIndexOf(',')) + ")";
                SqlCommand com = new SqlCommand(sql, con);
                con.Open();
                int number = com.ExecuteNonQuery();
                con.Close();
                if (number > 0)
                {
                    FineUI.Alert.Show("逻辑删除成功");
                    this.G_DayTabel.DataSource = (DataTable)ViewState["InspectionDay"];
                    this.G_DayTabel.DataBind();
                }
                else
                {
                    FineUI.Alert.Show("逻辑删除失败");
                }
            }
            else
            {
                FineUI.Alert.Show("没有选择任何行", FineUI.MessageBoxIcon.Warning);
            }

        }
        #endregion
        #region 物理删除
        /// <summary>
        /// 物理删除 张繁 2013年8月14日
        /// </summary>
        /// <param name="sender"></param> 
        /// <param name="e"></param>
        protected void btn_Physics_Del_Click(object sender, EventArgs e)
        {
            int[] selectCount = G_DayTabel.SelectedRowIndexArray;

            if (selectCount.Length > 0)
            {
                string sql = "delete tb_Inspection where id in(";
                DataTable dt = (DataTable)ViewState["InspectionDay"];
                for (int i = 0; i < selectCount.Length; i++)
                {
                    string id = G_DayTabel.Rows[selectCount[i]].DataKeys[0].ToString();
                    sql += id + ",";
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID"].ToString() == id)
                        {
                            dt.Rows.Remove(dr);
                            break;
                        }
                    }
                }

                int number = new Citic.BLL.Inspection().ExecuteSql(sql.Remove(sql.LastIndexOf(',')) + ")");
                if (number > 0)
                {
                    FineUI.Alert.Show("物理删除成功");
                    this.G_DayTabel.DataSource = (DataTable)ViewState["InspectionDay"];
                    this.G_DayTabel.DataBind();
                }
                else
                {
                    FineUI.Alert.Show("物理删除失败");
                }
            }
            else
            {
                FineUI.Alert.Show("没有选择任何行", FineUI.MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}
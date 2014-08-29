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
    public partial class InspectionDelete : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState.Clear();
                this.G_InspectionFrequency.Title = DateTime.Now.ToLongDateString().ToString() + "视频检查追踪表（汽车业务）";
                this.txt_Time.SelectedDate = DateTime.Now;
            }
        }
        #region 查询按钮
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("IsDel=0");
            if (!string.IsNullOrEmpty(this.txt_Area.Text.Trim()))        //检查区域
            {
                sb.Append(" and Area like '%" + this.txt_Area.Text.Trim() + "%'");
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
            if (!string.IsNullOrEmpty(this.txt_CreateName.Text.Trim()))      //检查人员
            {
                sb.Append(" and CreateName like '%" + this.txt_CreateName.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_DealerName.Text.Trim()))      //经销店名称
            {
                sb.Append(" and DealerName like '%" + this.txt_DealerName.Text.Trim() + "%'");
            }
            DataSet ds = new Citic.BLL.Inspection().GetList(sb.ToString());
            ViewState["Inspection"] = ds.Tables[0];
            this.G_InspectionFrequency.DataSource = (DataTable)ViewState["Inspection"];
            this.G_InspectionFrequency.DataBind();
            this.G_InspectionFrequency.Title = Convert.ToDateTime(this.txt_Time.Text.Trim()).ToLongDateString() + "视频检查追踪表（汽车业务）";
        }
        #endregion

        #region 逻辑删除
        /// <summary>
        /// 追踪逻辑删除 张繁 2013年8月15日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Del_Click(object sender, EventArgs e)
        {
            int[] SelectCount = G_InspectionFrequency.SelectedRowIndexArray;
            if (SelectCount.Length > 0)
            {
                string UserName = CurrentUser.TrueName;
                string UserId = CurrentUser.UserId.ToString();
                string sql = "update tb_Inspection set IsDel=1,DelTime='" + DateTime.Now + "',DelId='" + UserId + "' where ID in (";
                DataTable dt = (DataTable)ViewState["Inspection"];
                for (int i = 0; i < SelectCount.Length; i++)
                {
                    string id = G_InspectionFrequency.Rows[SelectCount[i]].DataKeys[0].ToString();
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
                sql = sql.Remove(sql.LastIndexOf(',')) + ")";
                int number = new Citic.BLL.Inspection().ExecuteSql(sql);
                if (number > 0)
                {
                    FineUI.Alert.Show(string.Format("删除{0}条成功", SelectCount.Length.ToString()));
                    G_InspectionFrequency.DataSource = ((DataTable)ViewState["Inspection"]);
                    G_InspectionFrequency.DataBind();

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
        /// 追踪删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btn_Del_Click(object sender, EventArgs e)
        //{
        //    int[] SelectCount = G_InspectionFrequency.SelectedRowIndexArray;
        //    if (SelectCount.Length > 0)
        //    {
        //        string sql = "delete tb_InspectionFrequency where id in(";
        //        DataTable dt = (DataTable)ViewState["InspectionFrequency"];
        //        for (int i = 0; i < SelectCount.Length; i++)
        //        {
        //            string id = G_InspectionFrequency.Rows[SelectCount[i]].DataKeys[0].ToString();
        //            sql += id + ",";
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                if (dr["ID"].ToString() == id)
        //                {
        //                    dt.Rows.Remove(dr);
        //                    break;
        //                }
        //            }
        //        }
        //        sql = sql.Remove(sql.LastIndexOf(',')) + ")";
        //        int number = new Citic.BLL.InspectionFrequency().ExecuteSql(sql);
        //        if (number > 0)
        //        {
        //            FineUI.Alert.Show("物理删除成功");
        //            G_InspectionFrequency.DataSource = ((DataTable)ViewState["InspectionFrequency"]).Select("Statu='1'");
        //            G_InspectionFrequency.DataBind();
        //        }
        //        else
        //        {
        //            FineUI.Alert.Show("物理删除失败");
        //        }
        //    }
        //    else
        //    {
        //        FineUI.Alert.Show("没有选择任何行", FineUI.MessageBoxIcon.Warning);
        //    }
        //}
        #endregion

    }
}
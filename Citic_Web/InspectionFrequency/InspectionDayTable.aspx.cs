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
    public partial class InspectionDayTable : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txt_StartTime.SelectedDate = DateTime.Now;
                this.txt_AsTime.SelectedDate = DateTime.Now;
                this.TT_Day.Text = DateTime.Now.ToLongDateString().ToString() + "-" + DateTime.Now.ToLongDateString().ToString() + "，总部视频部对所监管的部分经销店进行了全面的远程视频检查，现将结果报告如下：";

            }
        }
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
            if (!string.IsNullOrEmpty(this.txt_StartTime.Text.Trim()) && !string.IsNullOrEmpty(this.txt_AsTime.Text.Trim()))      //检查时间
            {
                sb.Append(" and CONVERT(varchar(10),CreateTime,23) between '" + this.txt_StartTime.Text.Trim() + "' and '" + this.txt_AsTime.Text.Trim() + "'");
            }
            if (!string.IsNullOrEmpty(this.txt_Rummager.Text.Trim()))      //检查人员
            {
                sb.Append(" and Rummager like '%" + this.txt_Rummager.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_DealerName.Text.Trim()))      //经销店名称
            {
                sb.Append(" and DealerName like '%" + this.txt_DealerName.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_SupervisorName.Text.Trim()))     //监管员
            {
                sb.Append(" and SupervisorName like '%" + this.txt_SupervisorName.Text.Trim() + "%'");
            }
            //this.G_DayInspection.DataSource = new Citic.BLL.Inspection().DayInspection(this.txt_StartTime.Text.Trim());
            //this.G_DayInspection.DataBind();
            DataTable dt = new Citic.BLL.Inspection().GetList(sb.ToString()).Tables[0];
            this.G_DayTabel.DataSource = dt;
            this.G_DayTabel.DataBind();
            this.G_DayInspection.DataSource = StatisticalExamination(dt);
            this.G_DayInspection.DataBind();
            this.TT_Day.Text = Convert.ToDateTime(this.txt_StartTime.Text.Trim()).ToLongDateString().ToString() + "-" + Convert.ToDateTime(this.txt_AsTime.Text.Trim()).ToLongDateString().ToString() + "，总部视频部对所监管的部分经销店进行了全面的远程视频检查，现将结果报告如下：";
        }
        private DataTable StatisticalExamination(DataTable dt)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ShopCount");
            table.Columns.Add("ConformShopCount");
            table.Columns.Add("NotConformShopCount");
            table.Columns.Add("InventoryShopCount");
            int Dealer = dt.Rows.Count;
            int IsConform = dt.Select("IsConform='1'").Length;
            int Inventory = dt.Select("Inventory='0'").Length;
            table.Rows.Add(Dealer, Dealer - IsConform, IsConform, Inventory);

            return table;
        }
    }
}
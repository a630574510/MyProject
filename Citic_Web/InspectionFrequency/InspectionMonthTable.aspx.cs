using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Citic_Web.InspectionFrequency
{
    public partial class InspectionMonthTable : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txt_Time.SelectedDate = DateTime.Now;
            }
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("IsDel=0");
            if (!string.IsNullOrEmpty(this.txt_Area.Text.Trim()))        //检查区域
            {
                sb.Append(" and Area like '%" + this.txt_Area.Text.Trim() + "%'");
            }
            else if (!string.IsNullOrEmpty(this.txt_Bank.Text.Trim()))      //合作银行
            {
                sb.Append(" and Bank like '%" + this.txt_Bank.Text.Trim() + "%'");
            }
            else if (!string.IsNullOrEmpty(this.txt_BrandName.Text.Trim()))      //品牌
            {
                sb.Append(" and BrandName like '%" + this.txt_BrandName.Text.Trim() + "%'");
            }
            else if (!string.IsNullOrEmpty(this.txt_Time.Text.Trim()))      //检查时间
            {
                sb.Append(" and convert(varchar(7), CreateTime, 120) = convert(varchar(7),'" + this.txt_Time.Text.Trim() + "', 120) ");
            }
            else if (!string.IsNullOrEmpty(this.txt_SupervisorName.Text.Trim()))      //检查人员
            {
                sb.Append(" and Rummager like '%" + this.txt_SupervisorName.Text.Trim() + "%'");
            }
            else if (!string.IsNullOrEmpty(this.txt_DealerName.Text.Trim()))      //经销店名称
            {
                sb.Append(" and DealerName like '%" + this.txt_DealerName.Text.Trim() + "%'");
            }
            this.G_DayInspection.DataSource = new Citic.BLL.InspectionDay().MonthInspection(this.txt_Time.Text.Trim());
            this.G_DayInspection.DataBind();
            this.G_DayTabel.DataSource = new Citic.BLL.InspectionDay().GetList(sb.ToString());
            this.G_DayTabel.DataBind();
            this.TT_Day.Text = Convert.ToDateTime(this.txt_Time.Text.Trim()).GetDateTimeFormats('y')[0].ToString() + "，总部视频部对所监管的部分经销店进行了全面的远程视频检查，现将结果报告如下：";
        }
    }
}
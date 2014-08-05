using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Citic_Web.BankInterface
{
    public partial class GD_Q402 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            if (this.txt_PI_NO.Text.Trim().Length == 0 && this.txt_DJ_NO.Text.Trim().Length == 0)
            {
                FineUI.Alert.ShowInTop("合格证和车架必须填写一样");
            }
            else
            {
                int RoleId = this.CurrentUser.RoleId;       //获取角色id
                string sql = string.Empty;
                string dj = this.txt_DJ_NO.Text.Trim();
                string pi = this.txt_PI_NO.Text.Trim();

                if (RoleId == 10)
                {
                    sql = string.Format("select * from tb_ToGDMessage where FTranCode='Q402'  and ([Status]='1' or [Status]='2' or [Status]='3') and RequestDate between CONVERT(varchar(100), GETDATE()-7, 23) and CONVERT(varchar(100), GETDATE()+1, 23) and RequestPe_ID='{0}' and (RequestSource like '%<DJ_NO>{1}</DJ_NO>%' or RequestSource like '%<PI_NO>{2}</PI_NO>%') order by ResponseDate desc", CurrentUser.UserId, dj, pi);
                }
                else
                {
                    sql = string.Format("select * from tb_ToGDMessage where FTranCode='Q402'  and ([Status]='1' or [Status]='2' or [Status]='3') and RequestDate between CONVERT(varchar(100), GETDATE()-7, 23) and CONVERT(varchar(100), GETDATE()+1, 23) and (RequestSource like '%<DJ_NO>{0}</DJ_NO>%' or RequestSource like '%<PI_NO>{1}</PI_NO>%') order by ResponseDate desc", dj, pi);
                }
                DataSet ds = CarBll.GetList(sql);
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("PI_NO");            //合格证编号/车架
                dt.Columns.Add("Message");       //返回错误信息
                dt.Columns.Add("RequestDate");      //提交时间
                dt.Columns.Add("ResponseDate");      //返回时间
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataRow dr_dt = dt.NewRow();
                    dr_dt["id"] = dr["ID"].ToString();
                    dr_dt["PI_NO"] = pi.Length == 0 ? dj : pi;
                    dr_dt["Message"] = dr["Status"].ToString() == "1" ? "成功入库" : dr["ErrMessage"].ToString();
                    dr_dt["RequestDate"] = dr["RequestDate"].ToString();
                    dr_dt["ResponseDate"] = dr["ResponseDate"].ToString();
                    dt.Rows.Add(dr_dt);
                }
                if (dt.Rows.Count == 0)
                {
                    FineUI.Alert.ShowInTop("无法查询到数据对应车辆数据", FineUI.MessageBoxIcon.Information);
                }
                this.G_Correct.DataSource = dt;
                this.G_Correct.DataBind();
            }

        }
    }
}
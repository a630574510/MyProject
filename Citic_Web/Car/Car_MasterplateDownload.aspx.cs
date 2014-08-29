using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Citic.BLL;
using System.Text;
using System.Data;
namespace Citic_Web.Car
{
    public partial class Car_MasterplateDownload : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.dp_AddTime.SelectedDate = DateTime.Now;
            }
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("isDel=1 ");
            if (!string.IsNullOrEmpty(this.txt_Dealer.Text.Trim()))
            {
                sb.AppendFormat("and DealerName like '%{0}%' ", this.txt_Dealer.Text.Trim());
            }
            if (!string.IsNullOrEmpty(this.dp_AddTime.Text.Trim()))
            {
                sb.AppendFormat("and CONVERT(varchar(10),CreateTime,23) ='{0}' ", this.dp_AddTime.Text.Trim());
            }
            CarMasterplate CarMasterplateBll = new CarMasterplate();
            int RoleId = this.CurrentUser.RoleId;       //获取角色id
            DataTable dt = new DataTable();
            switch (RoleId)
            {
                case 1:         //1为超级管理员
                    dt = CarMasterplateBll.GetList(sb.Append(" order by CreateTime desc").ToString()).Tables[0];
                    break;
                case 2:         //2为管理员
                    break;
                case 3:         //3为业务经理

                    dt = CarMasterplateBll.GetList(sb.Append(" order by CreateTime desc").ToString()).Tables[0];
                    break;
                case 4:         //4为市场经理
                    break;
                case 5:         //5为市场专员
                    sb.AppendFormat(" and BankID in(select MappingID from tb_UserMapping where RoleID=5 and UserID='{0}')", CurrentUser.UserId);
                    dt = CarMasterplateBll.GetList(sb.Append(" order by CreateTime desc").ToString()).Tables[0];
                    break;
                case 6:         //6为品牌专员
                    sb.AppendFormat(" and BankID in(select MappingID from tb_UserMapping where RoleID=6 and UserID='{0}')", CurrentUser.UserId);
                    dt = CarMasterplateBll.GetList(sb.Append(" order by CreateTime desc").ToString()).Tables[0];
                    break;
                case 7:         //7为调配专员
                    break;
                case 8:         //8为银行
                    break;
                case 9:         //9为厂家
                    break;
                case 10:         //10为监管员 2014年4月16日   
                    sb.AppendFormat(" and CreateID='{0}' order by CreateTime desc", CurrentUser.UserId);
                    dt = CarMasterplateBll.GetList(sb.ToString()).Tables[0];
                    break;
            }
            this.G_Transit.DataSource = dt.Select("TypeID=1");
            this.G_Transit.DataBind();
            this.G_Out.DataSource = dt.Select("TypeID=2");
            this.G_Out.DataBind();
            this.G_Move.DataSource = dt.Select("TypeID=3");
            this.G_Move.DataBind();
        }

    }
}
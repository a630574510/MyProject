using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Citic_Web
{
    public partial class Login : System.Web.UI.Page
    {
        private static Citic.BLL.Department DepartmentBll = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DeptBind();
            }
        }

        private void DeptBind()
        {
            if (DepartmentBll == null)
            {
                DepartmentBll = new Citic.BLL.Department();
            }
            DataSet ds = DepartmentBll.GetList(" PDID=0 and Type<>0");
            //ddlDept.DataSource = ds.Tables[0];
            //ddlDept.DataValueField = "ID";
            //ddlDept.DataTextField = "DName";
            //ddlDept.DataBind();
            //ListItem Drl = new ListItem("请选择", "0");
            //ddlDept.Items.Insert(0, Drl);

            rbl_Dept.DataSource = ds.Tables[0];
            rbl_Dept.DataTextField = "DName";
            rbl_Dept.DataValueField = "ID";
            rbl_Dept.DataBind();
            rbl_Dept.Items[0].Selected = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string NAME = this.txtUsername.Text.Trim();
            string PWD = this.txtPass.Text.Trim();
            int Dept = Convert.ToInt32(rbl_Dept.SelectedValue);
            if (Dept > 0)
            {
                bool persist = true;
                if (AuthProcess.AuthenticateUser(NAME, PWD, Dept, Request.UserHostAddress.ToString(), persist))
                {
                    Response.Redirect("Main.aspx");
                }
                else
                {
                    Response.Write("<script> alert('用户名或密码输入错误'); </script>");
                }
            }
            else
            {
                Response.Write("<script> alert('请选择部门！'); </script>");
            }
        }
    }
}
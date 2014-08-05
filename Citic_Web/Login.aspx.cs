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

                string result = AuthProcess.AuthenticateUser(NAME, PWD, Dept, Request.UserHostAddress.ToString(), persist);
                if (string.IsNullOrEmpty(result))
                {
                    Response.Redirect("Main.aspx");
                }
                else
                {
                    Response.Write("<script> alert('" + result + "'); </script>");
                }
            }
            else
            {
                Response.Write("<script> alert('请选择部门！'); </script>");
            }
        }
    }
}
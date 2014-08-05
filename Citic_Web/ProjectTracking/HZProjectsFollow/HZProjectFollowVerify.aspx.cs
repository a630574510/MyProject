using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Citic_Web.ProjectTracking.HZProjectsFollow
{
    public partial class HZProjectFollowVerify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_Add1.OnClientClick = WindowAdd1.GetShowReference("../../ProjectTracking/rcquesbyday/AddHZXMGJ.aspx");
            }
        }
    }
}
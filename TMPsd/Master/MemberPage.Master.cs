using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMPsd.Master
{
    public partial class MemberPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Remove("Username");
            Session.Remove("UserID");
            Session.Remove("Password");
            Session.Remove("BookID");
            Response.Redirect("GuestLogin.aspx");
        }
    }
}
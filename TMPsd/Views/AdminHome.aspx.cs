using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMPsd.Views
{
    public partial class AdminHome : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["Username"] as string))
            {
                string temp = Session["username"] as String;

                User check = db.Users.Where(obj => obj.Username == temp).FirstOrDefault();
                
                if(check.RoleID == 1)
                {
                    Response.Redirect("/Views/GuestLogin.aspx");
                }
                else if (check.RoleID == 2)
                {
                    HelloLabel.Text = "Hello Admin " + Session["Username"] + " !";
                }
            }
            else
            {
                Response.Redirect("/Views/GuestLogin.aspx");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMPsd.Views
{
    public partial class GuestLogin : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Username"] != null && Request.Cookies["Password"] != null)
                {
                    LogUsername.Text = Request.Cookies["Username"].Value.ToString();
                    LogPassword.Attributes["value"] = Request.Cookies["Password"].Value.ToString();
                }
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            User check = db.Users.Where(obj => obj.Username == LogUsername.Text && obj.Password == LogPassword.Text).FirstOrDefault();

            if (check != null)
            {
                Session.Timeout = 60;
                Session["Username"] = LogUsername.Text;
                Session["Password"] = LogPassword.Text;
                Session["UserID"] = check.UserID;

                if (RememberCheck.Checked)
                {
                    Response.Cookies["Username"].Value = LogUsername.Text;
                    Response.Cookies["Password"].Value = LogPassword.Text;
                }

                if (check.RoleID == 1)
                { 
                    if (check.Banned == false)
                    {
                        Response.Redirect("/Views/MemberHome.aspx");
                    }
                    else if (check.Banned == true)
                    {
                        Banned.Text = "*Account is banned";
                    }
                    
                }
                else if (check.RoleID == 2)
                {
                    Response.Redirect("/Views/AdminHome.aspx");
                }
            }

            else if (check == null)
            {
                WrongCombination.Text = "*Wrong combination of email and password";
            }
        }
    }
}
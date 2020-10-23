using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMPsd.Views
{
    public partial class MemberChangePassword : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["Username"] as string))
            {
                string temp = Session["username"] as String;

                User check = db.Users.Where(obj => obj.Username == temp).FirstOrDefault();

                if (check.RoleID == 2)
                {
                    Response.Redirect("/Views/GuestLogin.aspx");
                }
            }
            else
            {
                Response.Redirect("/Views/GuestLogin.aspx");
            }
        }

        private User GetUserByPassword(string password)
        {
            string var = string.Empty;
            var = Convert.ToString(Session["Username"]);

            User user = (from u in db.Users where u.Username == var && u.Password == password select u).FirstOrDefault();
            return user;
        }


        protected void ChangePassBtn_Click(object sender, EventArgs e)
        {
            string OldPassword = txtOldPassword.Text;
            string NewPassword = txtNewPassword.Text;

            User user = GetUserByPassword(OldPassword);

            if (user != null)
            {
                user.Password = NewPassword;

                db.SaveChanges();

                txtOldPassword.Text = "";
                txtNewPassword.Text = "";
                txtConfirmNewPassword.Text = "";

                SuccessLabel.Text = "Change password success";
            }
            else if (user == null)
            {
                FailedLabel.Text = "Failed to change password";
            }
        }
    }
}
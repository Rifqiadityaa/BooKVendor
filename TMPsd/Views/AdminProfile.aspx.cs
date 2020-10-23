using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMPsd.Views
{
    public partial class AdminProfile : System.Web.UI.Page
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
                    UpdateGridData();
                }
                else if (check.RoleID == 1)
                {
                    Response.Redirect("/Views/GuestLogin.aspx");
                }
            }
            else
            {
                Response.Redirect("/Views/GuestLogin.aspx");
            }
        }

        private void UpdateGridData()
        {
            string usernameSession = string.Empty;
            usernameSession = Convert.ToString(Session["Username"]);

            AdminProfileGridView.DataSource = db.Users.Where(M => M.Username == usernameSession).Select(x => new { Username = x.Username, Name = x.Name, Gender = x.Gender, PhoneNumber = x.PhoneNumber, Address = x.Address }).ToList();
            AdminProfileGridView.DataBind();
        }
    }
}
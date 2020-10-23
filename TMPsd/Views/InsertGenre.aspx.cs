using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMPsd.Repository;

namespace TMPsd.Views
{
    public partial class InsertGenre : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["Username"] as string))
            {
                string temp = Session["username"] as String;

                User check = db.Users.Where(obj => obj.Username == temp).FirstOrDefault();

                if (check.RoleID == 1)
                {
                    Response.Redirect("/Views/GuestLogin.aspx");
                }
            }
            else
            {
                Response.Redirect("/Views/GuestLogin.aspx");
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            string Name = txtGenreName.Text;
            string Description = txtGenreDesc.Text;

            GenreRepository.insertGenre(Name, Description);

            txtGenreName.Text = "";
            txtGenreDesc.Text = "";

            InsertSuccess.Text = "Genre inserted succesfully";
        }
    }
}
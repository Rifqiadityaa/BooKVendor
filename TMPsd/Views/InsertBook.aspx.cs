    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMPsd.Repository;

namespace TMPsd.Views
{
    public partial class InsertBook : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var genreName = (from g in db.Genres
                                     select new { g.GenreName, g.GenreID }).ToList();

                    dropDownGenre.DataTextField = "GenreName";
                    dropDownGenre.DataValueField = "GenreID";
                    dropDownGenre.DataSource = genreName;
                    dropDownGenre.DataBind();
                }
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            int GenreID = Int32.Parse(dropDownGenre.SelectedValue);
            string Description = txtDesc.Text;
            int Stock = Int32.Parse(txtStock.Text);
            int Price = Int32.Parse(txtPrice.Text);

            BookRepository.insertBook(Name, GenreID, Description, Stock, Price);

            txtName.Text = "";
            txtDesc.Text = "";
            txtStock.Text = "";
            txtPrice.Text = "";

            InsertSuccess.Text = "Book inserted succesfully";
        }
    }
}
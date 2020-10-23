using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMPsd.Views
{
    public partial class AdminBook : System.Web.UI.Page
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

        public Object getBook()
        {
            return (from b in db.Books
                    join g in db.Genres on b.GenreID equals g.GenreID
                    select new
                    {
                        BookID = b.BookID,
                        BookName = b.Name,
                        GenreName = g.GenreName,
                        BookDescription = b.Description,
                        BookStock = b.Stock,
                        BookPrice = b.Price
                    }).ToList();
        }

        private void UpdateGridData()
        {
            AdminBookGridView.DataSource = getBook();
            AdminBookGridView.DataBind();
        }
    }
}
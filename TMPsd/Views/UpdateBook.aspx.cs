using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMPsd.Views
{
    public partial class UpdateBook : System.Web.UI.Page
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
            UpdateBookGridView.DataSource = getBook();
            UpdateBookGridView.DataBind();
        }

        private Book GetBookByID(int BookID)
        {
            Book book = (from b in db.Books where b.BookID == BookID select b).FirstOrDefault();
            return book;
        }

        protected void UpdateBookGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBookID.Text = UpdateBookGridView.SelectedRow.Cells[2].Text;
            txtName.Text = UpdateBookGridView.SelectedRow.Cells[3].Text;
            txtDesc.Text = UpdateBookGridView.SelectedRow.Cells[5].Text;
            txtStock.Text = UpdateBookGridView.SelectedRow.Cells[6].Text;
            txtPrice.Text = UpdateBookGridView.SelectedRow.Cells[7].Text;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int BookID = Int32.Parse(txtBookID.Text);
            int NewGenreID = Int32.Parse(dropDownGenre.SelectedValue);
            string NewName = txtName.Text;
            string NewDesc = txtDesc.Text;
            int NewStock = Int32.Parse(txtStock.Text);
            int NewPrice = Int32.Parse(txtPrice.Text);

            Book book = GetBookByID(BookID);

            if (book != null)
            {
                book.BookID = BookID;
                book.GenreID = NewGenreID;
                book.Name = NewName;
                book.Description = NewDesc;
                book.Stock = NewStock;
                book.Price = NewPrice;

                db.SaveChanges();

                UpdateGridData();

                txtBookID.Text = "";
                txtName.Text = "";
                txtDesc.Text = "";
                txtStock.Text = "";
                txtPrice.Text = "";

                UpdateSuccess.Text = "Book updated successfully";
            }
            else if (book == null)
            {
                UpdateFailed.Text = "Failed to update book";
            }
        }

        protected void UpdateBookGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int BookID = Convert.ToInt32(UpdateBookGridView.DataKeys[e.RowIndex].Values[0]);

            Book book = GetBookByID (BookID);

            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();

                UpdateGridData();

                SuccessDelete.Text = "Deleted book successfully";
            }
            else if (book == null)
            {
                FailedDelete.Text = "Failed to delete book";
            }
        }
    }
}
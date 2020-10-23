using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMPsd.Views
{
    public partial class UpdateGenre : System.Web.UI.Page
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
            UpdateGenreGridView.DataSource = db.Genres.ToList();
            UpdateGenreGridView.DataBind();
        }

        private Genre GetGenreByID(int GenreID)
        {
            Genre genre = (from g in db.Genres where g.GenreID == GenreID select g).FirstOrDefault();
            return genre;
        }

        protected void UpdateGenreGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGenreID.Text = UpdateGenreGridView.SelectedRow.Cells[2].Text;
            txtGenreName.Text = UpdateGenreGridView.SelectedRow.Cells[3].Text;
            txtGenreDesc.Text = UpdateGenreGridView.SelectedRow.Cells[4].Text;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int GenreID = Int32.Parse(txtGenreID.Text);
            string NewName = txtGenreName.Text;
            string NewDesc = txtGenreDesc.Text;

            Genre genre = GetGenreByID(GenreID);

            if (genre != null)
            {
                genre.GenreID = GenreID;
                genre.GenreName = NewName;
                genre.Description = NewDesc;

                db.SaveChanges();

                UpdateGridData();

                txtGenreID.Text = "";
                txtGenreName.Text = "";
                txtGenreDesc.Text = "";

                UpdateSuccess.Text = "Genre updated successfully";
            }
            else if (genre == null)
            {
                UpdateFailed.Text = "Failed to update genre";
            }
        }

        protected void UpdateGenreGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int GenreID = Convert.ToInt32(UpdateGenreGridView.DataKeys[e.RowIndex].Values[0]);

            Genre genre = GetGenreByID(GenreID);

            if (genre != null)
            {
                db.Genres.Remove(genre);
                db.SaveChanges();

                UpdateGridData();

                SuccessDelete.Text = "Deleted genre successfully";
            }
            else if (genre == null)
            {
                FailedDelete.Text = "Failed to delete genre";
            }
        }
    }
}
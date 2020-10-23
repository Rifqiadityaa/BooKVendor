using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMPsd.Views
{
    public partial class MemberUpdateProfile : System.Web.UI.Page
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
                    UpdateGridData();
                }
                else if (check.RoleID == 2)
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

            MemberUpdateProfileGridView.DataSource = db.Users.Where(M => M.Username == usernameSession).Select(x => new { UserID = x.UserID, Username = x.Username, Name = x.Name, Gender = x.Gender, PhoneNumber = x.PhoneNumber, Address = x.Address }).ToList();
            MemberUpdateProfileGridView.DataBind();
        }

        protected void MemberUpdateProfileGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserID.Text = MemberUpdateProfileGridView.SelectedRow.Cells[1].Text;
            txtUsername.Text = MemberUpdateProfileGridView.SelectedRow.Cells[2].Text;
            txtName.Text = MemberUpdateProfileGridView.SelectedRow.Cells[3].Text;
            txtGender.Text = MemberUpdateProfileGridView.SelectedRow.Cells[4].Text;
            txtPhone.Text = MemberUpdateProfileGridView.SelectedRow.Cells[5].Text;
            txtAddress.Text = MemberUpdateProfileGridView.SelectedRow.Cells[6].Text;
        }

        private User GetUserByID(int UserID)
        {
            User user = (from u in db.Users where u.UserID == UserID select u).FirstOrDefault();
            return user;
        }

        protected void txtAddressCustomValidator_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            if (e.Value.Contains("Street") || (e.Value.Contains("street")))
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            Page.Validate("RegisterValidation");
            if (Page.IsValid)
            {
                {
                    int UserID = Int32.Parse(txtUserID.Text);
                    string Username = txtUsername.Text;
                    string NewName = txtName.Text;
                    string NewGender = txtGender.Text;
                    string NewPhoneNumber = txtPhone.Text;
                    string NewAddress = txtAddress.Text;

                    User user = GetUserByID(UserID);

                    if (user != null)
                    {
                        user.Name = NewName;
                        user.Gender = NewGender;
                        user.PhoneNumber = NewPhoneNumber;
                        user.Address = NewAddress;

                        db.SaveChanges();

                        UpdateGridData();

                        txtUserID.Text = "";
                        txtUsername.Text = "";
                        txtName.Text = "";
                        txtGender.Text = "";
                        txtPhone.Text = "";
                        txtAddress.Text = "";

                        UpdateSuccess.Text = "Profile updated successfully";
                    }
                    else if (user == null)
                    {
                        UpdateFailed.Text = "Failed to update profile";
                    }
                }
            }
            else if (!Page.IsValid)
            {
                UpdateFailed.Text = "Failed to update profile";
            }
        }
    }
}
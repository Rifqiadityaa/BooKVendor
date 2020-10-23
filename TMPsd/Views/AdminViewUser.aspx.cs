using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMPsd.Views
{
    public partial class AdminViewUser : System.Web.UI.Page
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

        public Object getUsers()
        {
            return (from u in db.Users
                    join r in db.Roles on u.RoleID equals r.RoleID
                    where u.RoleID == 1
                    select new
                    {
                        UserID = u.UserID,
                        Username = u.Username,
                        Name = u.Name,
                        Role = r.RoleName,
                        Gender = u.Gender,
                        PhoneNumber = u.PhoneNumber,
                        Address = u.Address,
                        Banned = u.Banned.ToString(),
                    }).ToList();
        }

        private void UpdateGridData()
        {
            AdminViewUserGridView.DataSource = getUsers();
            AdminViewUserGridView.DataBind();
        }

        private User GetUserByID(int UserID)
        {
            User user = (from u in db.Users where u.UserID == UserID select u).FirstOrDefault();
            return user;
        }


        protected void AdminViewUserGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteUser")
            {
                int UserID = Convert.ToInt32(e.CommandArgument);

                User user = GetUserByID(UserID);

                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();

                    UpdateGridData();

                    SuccessDelete.Text = "User deleted successfully";
                }
                else if (user == null)
                {
                    FailedDelete.Text = "Failed to delete user";
                }
            }

            if (e.CommandName == "BanUser")
            {
                int UserID = Convert.ToInt32(e.CommandArgument);

                User user = GetUserByID(UserID);

                if (user != null)
                {
                    if (user.Banned != true)
                    {
                        user.Banned = true;
                        db.SaveChanges();
                        UpdateGridData();
                        SuccessBan.Text = "User banned successfully";
                    }
                    else if (user.Banned == true)
                    {
                        FailedAlreadyBan.Text = "user already banned";
                    }
                }
                else if (user == null)
                {
                    FailedBan.Text = "Failed to ban user";
                }
            }

            if (e.CommandName == "UnbanUser")
            {
                int UserID = Convert.ToInt32(e.CommandArgument);

                User user = GetUserByID(UserID);

                if (user != null)
                {
                    if (user.Banned != false)
                    {
                        user.Banned = false;
                        db.SaveChanges();
                        UpdateGridData();
                        SuccessUnban.Text = "User unbanned successfully";
                    }
                    else if(user.Banned == false)
                    {
                        FailedAlreadyUnban.Text = "User already unbanned";
                    }
                }
                else if (user == null)
                {
                    FailedUnban.Text = "Failed to unban user";
                }
            }

            if (e.CommandName == "PromoteUser")
            {
                int UserID = Convert.ToInt32(e.CommandArgument);

                User user = GetUserByID(UserID);

                if (user != null)
                {
                    user.RoleID = 2;
                    db.SaveChanges();
                    UpdateGridData();
                    SuccessPromote.Text = "User promoted successfully";
                }
                else if (user == null)
                {
                    FailedPromote.Text = "Failed to promote user";
                }
            }


        }
    }
}
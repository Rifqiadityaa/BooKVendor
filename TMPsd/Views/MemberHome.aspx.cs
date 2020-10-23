using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMPsd.Repository;

namespace TMPsd.Views
{
    public partial class MemberHome : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["Username"] as string))
            {
                string temp = Session["Username"] as String;

                User check = db.Users.Where(obj => obj.Username == temp).FirstOrDefault();

                if (check.RoleID == 2)
                {
                    Response.Redirect("/Views/GuestLogin.aspx");
                }
                else if (check.RoleID == 1)
                {
                    HelloLabel.Text = "Hello " + Session["Username"] + " !";
                    UpdateGridData();
                }
            }
            else
            {
                Response.Redirect("/Views/GuestLogin.aspx");
            }
        }

        private void UpdateGridData()
        {
            BookHomeGridView.DataSource = db.Books.SqlQuery("SELECT TOP 5 * FROM [Book] ORDER BY RAND()").ToList();
            BookHomeGridView.DataBind();
        }

        private Cart GetCartBookByID(int BookID)
        {
            Cart cart = (from c in db.Carts where c.BookID == BookID select c).FirstOrDefault();
            return cart;
        }

        protected void BookHomeGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        { 
            Session["BookID"] = Convert.ToInt32(e.CommandArgument);
            int tempBookID = Convert.ToInt32(Session["BookID"]);
            int tempUserID = Convert.ToInt32(Session["UserID"]);
            Cart checkCartBook = GetCartBookByID(tempBookID);
            Cart checkCart = db.Carts.Where(ca => ca.UserID == tempUserID && ca.BookID == tempBookID).FirstOrDefault();
            Book book = db.Books.Where(b => b.BookID == tempBookID).FirstOrDefault();

            if (e.CommandName == "AddToCart")
            {
                if (book.Stock > 0)
                {
                    if (checkCart == null)
                    {
                        int UserID = tempUserID;
                        int BookID = tempBookID;
                        int Qty = 1;

                        CartRepository.insertCart(UserID, BookID, Qty);

                        book.Stock -= 1;
                        db.SaveChanges();

                        Session.Remove("BookID");

                        Response.Redirect("/Views/MemberCart.aspx");
                    }
      
                    else 
                    {
                        checkCartBook.Quantity += 1;
                        db.SaveChanges();

                        book.Stock -= 1;
                        db.SaveChanges();

                        Session.Remove("BookID");

                        Response.Redirect("/Views/MemberCart.aspx");
                    }
                }
                else if (book.Stock <= 0)
                {
                    AddFailed.Text = "No stock left";
                }
            }

        }
    }
}
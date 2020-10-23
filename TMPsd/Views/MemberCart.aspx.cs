using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMPsd.Repository;

namespace TMPsd.Views
{
    public partial class MemberCart : System.Web.UI.Page
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
                else if (check.RoleID == 1)
                {
                    UpdateGridData();
                }
            }
            else
            {
                Response.Redirect("/Views/GuestLogin.aspx");
            }
        }

        public Object getCartBook()
        {
            int tempUserID = Convert.ToInt32(Session["UserID"]);

            return (from b in db.Books
                    join c in db.Carts
                    on b.BookID equals c.BookID
                    where c.UserID == tempUserID
                    select new
                    {
                        BookID = b.BookID,
                        BookName = b.Name,
                        Quantity = c.Quantity,
                        BookPrice = b.Price,
                    }).ToList();
        }

        private Cart GetCartBookByID(int BookID)
        {
            Cart cart = (from c in db.Carts where c.BookID == BookID select c).FirstOrDefault();
            return cart;
        }


        private void UpdateGridData()
        {
            CartGridView.DataSource = getCartBook();
            CartGridView.DataBind();
        }

        int GrandTotal = 0;
        protected void CartGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int CartBookPrice = int.Parse(e.Row.Cells[5].Text.Trim());
                int CartBookQty = int.Parse(e.Row.Cells[4].Text.Trim());
                Label Subtotal = e.Row.FindControl("SubtotalLabel") as Label;
                Subtotal.Text = (CartBookPrice * CartBookQty).ToString();
                GrandTotal += int.Parse(Subtotal.Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                (e.Row.FindControl("GrandTotalLabel") as Label).Text = GrandTotal.ToString();
            }
        }

        protected void CartGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBookID.Text = CartGridView.SelectedRow.Cells[2].Text;
            txtQuantity.Text = CartGridView.SelectedRow.Cells[4].Text;
        }

        

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            int tempUserID = Convert.ToInt32(Session["UserID"]);
            DateTime Date = DateTime.Now;
           
            HeaderTransactionRepository.insertHeaderTransaction(tempUserID, Date);
            HeaderTransaction LastTransaction = db.HeaderTransactions.Where(lt => lt.UserID == tempUserID).OrderByDescending(lt => lt.TransactionID).FirstOrDefault();

            int TransactionID = LastTransaction.TransactionID;
            
            for (int i = 0; i < CartGridView.Rows.Count; i++)
            {
                int BookID = Int32.Parse(CartGridView.Rows[i].Cells[2].Text);
                int Quantity = Int32.Parse(CartGridView.Rows[i].Cells[4].Text);

                DetailTransactionRepository.insertDetailTransaction(TransactionID, BookID, Quantity);
            }

            for (int i = 0; i < CartGridView.Rows.Count; i++)
            {
                Cart cart = db.Carts.Where(c => c.UserID == tempUserID).FirstOrDefault();
                db.Carts.Remove(cart);
                db.SaveChanges();
            }

            Response.Redirect("/Views/MemberTransactionHistory.aspx");                       
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int BookID = Int32.Parse(txtBookID.Text);
            int newQty = Int32.Parse(txtQuantity.Text);
            Cart cart = GetCartBookByID(BookID);
            Book Book = db.Books.Where(b => b.BookID == BookID).FirstOrDefault();
            if (cart != null)
            {
                if (newQty > Book.Stock)
                {
                    txtQuantityFailed.Text = "Quantity can't be greater than stock";
                }
                else if (newQty <= Book.Stock)
                {
                    if (newQty < cart.Quantity)
                    {
                        Book.Stock = Book.Stock + (cart.Quantity - newQty);
                        db.SaveChanges();

                        cart.Quantity = newQty;
                        db.SaveChanges();

                        GrandTotal = 0;

                        UpdateGridData();

                        UpdateSuccess.Text = "Table updated successfully";
                    }
                    else if (newQty > cart.Quantity)
                    {
                        Book.Stock = Book.Stock - (newQty - cart.Quantity);
                        db.SaveChanges();

                        cart.Quantity = newQty;
                        db.SaveChanges();

                        GrandTotal = 0;

                        UpdateGridData();

                        UpdateSuccess.Text = "Table updated successfully";
                    }
                    else if (newQty == cart.Quantity)
                    {
                        cart.Quantity = newQty;
                        db.SaveChanges();

                        GrandTotal = 0;

                        UpdateGridData();

                        UpdateSuccess.Text = "No changes were made";
                    }
                }
            }
            else if (cart == null)
            {
                UpdateFailed.Text = "Failed to update table";
            }
        }

        protected void CartGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteCartItem")
            {
                int CartBookID = Convert.ToInt32(e.CommandArgument);
                Book BookStock = db.Books.Where(b => b.BookID == CartBookID).FirstOrDefault();
                Cart cart = GetCartBookByID(CartBookID);

                if (cart != null)
                {
                    BookStock.Stock += cart.Quantity;
                    db.SaveChanges();

                    db.Carts.Remove(cart);
                    db.SaveChanges();

                    GrandTotal = 0;

                    UpdateGridData();

                    SuccessDelete.Text = "Item deleted successfully";
                }
                else if (cart == null)
                {
                    FailedDelete.Text = "Failed to delete Item";
                }
            }
        }

        protected void CartGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cartBookID = Convert.ToInt32(CartGridView.DataKeys[e.RowIndex].Values[0]);

            Cart cart = GetCartBookByID(cartBookID);
            Book book = db.Books.Where(b => b.BookID == cartBookID).FirstOrDefault();

            if (cart != null)
            {
                book.Stock += cart.Quantity;
                db.SaveChanges();

                db.Carts.Remove(cart);
                db.SaveChanges();

                UpdateGridData();

                SuccessDelete.Text = "Deleted book successfully";
            }
            else if (cart == null)
            {
                FailedDelete.Text = "Failed to delete book";
            }
        }
    }
}
    

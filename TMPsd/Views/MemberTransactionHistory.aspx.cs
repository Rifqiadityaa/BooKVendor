using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMPsd.Views
{
    public partial class MemberTransactionHistory : System.Web.UI.Page
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

        public Object getTransactionHistory()
        {
            int tempUserID = Convert.ToInt32(Session["UserID"]);

            return (from ht in db.HeaderTransactions
                    join dt in db.DetailTransactions
                    on ht.TransactionID equals dt.TransactionID
                    join b in db.Books
                    on dt.BookID equals b.BookID
                    where ht.UserID == tempUserID
                    select new
                    {
                        BookName = b.Name,
                        BookPrice = b.Price,
                        Quantity = dt.Quantity,
                        Date = ht.Date
                    }).ToList();
        }

        protected void TransactionHistoryGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int BookPrice = int.Parse(e.Row.Cells[1].Text.Trim());
                int BookQty = int.Parse(e.Row.Cells[2].Text.Trim());
                Label Subtotal = e.Row.FindControl("SubtotalLabel") as Label;
                Subtotal.Text = (BookPrice * BookQty).ToString();
            }
        }

        private void UpdateGridData()
        {
            TransactionHistoryGridView.DataSource = getTransactionHistory();
            TransactionHistoryGridView.DataBind();
        }
    }
}
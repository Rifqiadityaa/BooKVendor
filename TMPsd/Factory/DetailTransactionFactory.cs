using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMPsd.Factory
{
    public class DetailTransactionFactory
    {
        public static DetailTransaction createDetailTransaction(int TransactionID, int BookID, int Quantity)
        {
            DetailTransaction dt = new DetailTransaction();

            dt.TransactionID = TransactionID;
            dt.BookID = BookID;
            dt.Quantity = Quantity;

            return dt;
        }
    }
}
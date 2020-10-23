using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMPsd.Factory;

namespace TMPsd.Repository
{
    public class DetailTransactionRepository
    {
        public static void insertDetailTransaction(int TransactionID, int UserID, int Quantity)
        {
            DetailTransaction dt = DetailTransactionFactory.createDetailTransaction(TransactionID, UserID, Quantity);

            Database1Entities db = new Database1Entities();
            db.DetailTransactions.Add(dt);
            db.SaveChanges();
        }
    }
}
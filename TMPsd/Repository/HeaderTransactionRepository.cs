using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMPsd.Factory;

namespace TMPsd.Repository
{
    public class HeaderTransactionRepository
    {
        public static void insertHeaderTransaction(int UserID, DateTime Date)
        {
            HeaderTransaction ht = HeaderTransactionFactory.createHeaderTransaction(UserID, Date);

            Database1Entities db = new Database1Entities();
            db.HeaderTransactions.Add(ht);
            db.SaveChanges();
        }
    }
}
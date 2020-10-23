using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMPsd.Factory
{
    public class HeaderTransactionFactory
    {
        public static HeaderTransaction createHeaderTransaction(int UserID, DateTime Date)
        {
            HeaderTransaction ht = new HeaderTransaction();

            ht.UserID = UserID;
            ht.Date = Date;

            return ht;
        }
    }
}
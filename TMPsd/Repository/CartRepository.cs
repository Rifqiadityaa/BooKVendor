using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMPsd.Factory;

namespace TMPsd.Repository
{
    public class CartRepository
    {
        public static void insertCart(int UserID, int BookID, int Qty)
        {
            Cart cart = CartFactory.createCart(UserID, BookID, Qty);

            Database1Entities db = new Database1Entities();
            db.Carts.Add(cart);
            db.SaveChanges();
        }
    }
}
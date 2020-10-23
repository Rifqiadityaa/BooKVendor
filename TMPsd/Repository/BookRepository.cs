using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMPsd.Factory;

namespace TMPsd.Repository
{
    public class BookRepository
    {
        public static void insertBook(string Name, int genreID, string Description, int stock, int price)
        {
            Book book = BookFactory.createBook(Name, genreID, Description, stock, price);

            Database1Entities db = new Database1Entities();
            db.Books.Add(book);
            db.SaveChanges();
        }
    }
}
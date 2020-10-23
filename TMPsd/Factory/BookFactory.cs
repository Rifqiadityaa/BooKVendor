using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMPsd.Factory
{
    public class BookFactory
    {
        public static Book createBook(string Name, int genreID, string Description, int stock, int price)
        {
            Book book = new Book();

            book.Name = Name;
            book.GenreID = genreID;
            book.Description = Description;
            book.Stock = stock;
            book.Price = price;

            return book;
        }
    }
}
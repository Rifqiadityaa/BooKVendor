using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMPsd.Factory;

namespace TMPsd.Repository
{
    public class GenreRepository
    {
        public static void insertGenre(string Name, string Description)
        {
            Genre genre = GenreFactory.createGenre(Name, Description);

            Database1Entities db = new Database1Entities();
            db.Genres.Add(genre);
            db.SaveChanges();
        }
    }
}
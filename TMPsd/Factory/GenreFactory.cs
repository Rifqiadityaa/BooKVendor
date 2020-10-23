using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMPsd.Factory
{
    public class GenreFactory
    {
        public static Genre createGenre(string Name, string Description)
        {
            Genre genre = new Genre();

            genre.GenreName = Name;
            genre.Description = Description;

            return genre;
        }
    }
}
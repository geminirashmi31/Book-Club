using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        public int BookGenreId { get; set; }
        public int BookAuthorId { get; set; }

        public virtual BookGenre BookGenre { get; set; }
        public virtual BookAuthor BookAuthor { get; set; }
    }
}

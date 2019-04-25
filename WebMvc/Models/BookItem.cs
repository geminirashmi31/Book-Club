using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{
    public class BookItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        public int BookGenreId { get; set; }
        public int BookAuthorId { get; set; }

        public string BookGenre { get; set; }
        public string BookAuthor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{
    public class Books
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public long Count { get; set; }

        public List<BookItem> Data { get; set; }
    }
}

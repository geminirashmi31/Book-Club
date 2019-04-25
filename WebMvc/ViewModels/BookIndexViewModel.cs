using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class BookIndexViewModel
    {
        public PaginationInfo PaginationInfo { get; set; }
        public IEnumerable<BookItem> BookItems { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }

        public int? AuthorFilterApplied { get; set; }
        public int? GenresFilterApplied { get; set; }
    }
}

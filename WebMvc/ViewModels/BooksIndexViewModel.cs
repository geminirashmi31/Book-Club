using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class BooksIndexViewModel
    {
        public PaginationInfo PaginationInfo { get; set; }
        public IEnumerable<BooksItem> BooksItem { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }

        public int? AuthorsFilterApplied { get; set; }
        public int? GenresFilterApplied { get; set; }
    }
}
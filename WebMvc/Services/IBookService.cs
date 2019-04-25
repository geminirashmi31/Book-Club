using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface IBookService
    {
        Task<Books> GetBookItemsAsync(int page, int take, int? author, int? genre);

        Task<IEnumerable<SelectListItem>> GetAuthorsAsync();
        Task<IEnumerable<SelectListItem>> GetGenresAsync();
    }
}

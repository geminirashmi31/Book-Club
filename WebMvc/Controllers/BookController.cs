using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;
        public BookController(IBookService service) =>
            _service = service;

        public async Task<IActionResult> Index(int? authorFilterApplied,
            int? genreFilterApplied, int? page)
        {
            var itemsOnPage = 10;
            var book = await _service.GetBookItemsAsync(page ?? 0, itemsOnPage,
                authorFilterApplied, genreFilterApplied);

            var vm = new BookIndexViewModel
            {
                BookItems = book.Data,
                Authors = await _service.GetAuthorsAsync(),
                Genres = await _service.GetGenresAsync(),
                AuthorFilterApplied = authorFilterApplied ?? 0,
                GenresFilterApplied = genreFilterApplied ?? 0,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = book.Count,
                    TotalPages = (int)Math.Ceiling((decimal)book.Count / itemsOnPage)
                }
            };

            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";
            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";

            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }
    }
}
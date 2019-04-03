using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Data;
using BookAPI.Domain;
using BookAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Books")]
    public class BookController : Controller
    {
        private readonly BookContext _context;
        private readonly IConfiguration _config;

        public BookController(BookContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        //GET
        [HttpGet]
        //the route name is the same as action name
        [Route("[action]")]
        //return JSON back (IActionResult)
        public async Task<IActionResult> BookGenres()
        {
            var items = await _context.BookGenres.ToListAsync();
            return Ok(items);
        }

        //GET
        [HttpGet]
        //the route name is the same as action name
        [Route("[action]")]
        //return JSON back (IActionResult)
        public async Task<IActionResult> BookAuthors()
        {
            var items = await _context.BookAuthors.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("books/{id:int}")]
        public async Task<IActionResult> GetBooksById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Incorrect id");
            }

           var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == id);
           if (book != null)
           {
               book.PictureUrl = book.PictureUrl.Replace("http://externalbooksbaseurltobereplaced",
                   _config["ExternalBooksBaseUrl"]);
               return Ok(book);
           }

           return NotFound();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Books(
            [FromQuery] int pageSize = 6,
            [FromQuery] int pageIndex = 0)
        {
            var booksCount =
                await _context.Books.LongCountAsync();

            var books = await _context.Books
                .OrderBy(b => b.Title)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            books = ChangePictureUrl(books);

            var model = new PaginatedItemsViewModel<Book>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = booksCount,
                Data = books
            };
            return Ok(model);
        }


        private List<Book> ChangePictureUrl(List<Book> books)
        {
            books.ForEach(
                b => b.PictureUrl = b.PictureUrl
                    .Replace("http://externalbooksbaseurltobereplaced"
                        , _config["ExternalCatalogBaseUrl"])
            );
            return books;
        }
    }
}
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class BookService : IBookService
    {
        private readonly string _remoteServiceBaseUri;
        private readonly IHttpClient _client;
        public BookService(IHttpClient httpClient, IConfiguration configuration)
        {
            _client = httpClient;
            _remoteServiceBaseUri = $"{configuration["BookUrl"]}/api/books/";
        }

        public async Task<IEnumerable<SelectListItem>> GetAuthorsAsync()
        {
            var authorUri = ApiPaths.Books.GetAllAuthors(_remoteServiceBaseUri);
            var dataString = await _client.GetStringAsync(authorUri);

            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value= null,
                    Text = "All",
                    Selected=true
                }
            };

            var authors = JArray.Parse(dataString);
            foreach (var author in authors)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = author.Value<string>("id"),
                        Text = author.Value<string>("author")
                    });
            }

            return items;
        }

        public async Task<Books> GetBookItemsAsync(int page, int take, int? author, int? genre)
        {
            var bookItemsUri = ApiPaths.Books.GetAllBookItems(_remoteServiceBaseUri,
                page, take, author, genre);

            var dataString = await _client.GetStringAsync(bookItemsUri);
            var response = JsonConvert.DeserializeObject<Books>(dataString);

            return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetGenresAsync()
        {
            var genreUri = ApiPaths.Books.GetAllGenres(_remoteServiceBaseUri);
            var dataString = await _client.GetStringAsync(genreUri);

            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value= null,
                    Text = "All",
                    Selected=true
                }
            };

            var genres = JArray.Parse(dataString);
            foreach (var genre in genres)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = genre.Value<string>("id"),
                        Text = genre.Value<string>("genre")
                    });
            }

            return items;
        }
    }
}

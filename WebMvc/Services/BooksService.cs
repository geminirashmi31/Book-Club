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
    public class BooksService : IBooksService
    {
        private readonly string _remoteServiceBaseUri;
        private readonly IHttpClient _client;
        public BooksService (IHttpClient httpClient, IConfiguration configuration)
        {
            _client = httpClient;
            _remoteServiceBaseUri = $"{configuration["BooksUrl"]}/api/books/";
        }

        public async Task<IEnumerable<SelectListItem>> GetAuthorsAsync()
        {
            var authorUri = ApiPaths.Books.GetAllAuthors(_remoteServiceBaseUri);
            var dataString = await _client.GetStringAsync(authorUri);
            //by default the select item is empty
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value= null,
                    Text = "All",
                    Selected=true
                }
            };
            //data type is string we are parsing it into array of Json objects
            JArray authors = JArray.Parse(dataString);
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

        public async Task<Books> GetBooksItemsAsync(int page, int take, int? author, int? genre)
        {
            var booksItemsUri = ApiPaths.Books.GetAllBooksItems(_remoteServiceBaseUri,
                page, take, author, genre);

            var dataString = await _client.GetStringAsync(booksItemsUri);
            var response = JsonConvert.DeserializeObject<Books>(dataString);

            return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetGenresAsync()
        {
            var genreUri = ApiPaths.Books.GetAllGenres(_remoteServiceBaseUri);
            var dataString = await _client.GetStringAsync(genreUri);
            //by default the select item is empty
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value= null,
                    Text = "All",
                    Selected=true
                }
            };
            //data type is string we are parsing it into array of Json objects
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


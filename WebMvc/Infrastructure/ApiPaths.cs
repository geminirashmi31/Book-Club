using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public class ApiPaths
    {
        public static class Books
        {
            public static string GetAllBookItems(string baseUri, int page, int take,
                int? author, int? genre)
            {
                var filterQs = string.Empty;

                if (author.HasValue || genre.HasValue)
                {
                    var authorQs = (author.HasValue) ? author.Value.ToString() : "null";
                    var genreQs = (genre.HasValue) ? genre.Value.ToString() : "null";
                    filterQs = $"/genre/{genreQs}/author/{authorQs}";
                }

                return $"{baseUri}books{filterQs}?pageIndex={page}&pageSize={take}";
            }

            public static string GetAllAuthors(string baseUri)
            {
                return $"{baseUri}bookauthors";
            }

            public static string GetAllGenres(string baseUri)
            {
                return $"{baseUri}bookgenres";
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public class ApiPaths
    {
        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }

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

        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            //public static string GetOrdersByUser(string baseUri, string userName)
            //{
            //    return $"{baseUri}/userOrders?userName={userName}";
            //}
            public static string GetOrders(string baseUri)
            {
                return baseUri;
            }
            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }
    }
}

using BookAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Data
{
    public class BookSeed
    {
        public static void Seed(BookContext context)
        {
            context.Database.Migrate();
            if (!context.BookGenres.Any())
            {
                context.BookGenres.AddRange(GetPreconfiguredBookGenres());
            }
            if (!context.BookAuthors.Any())
            {
                context.BookAuthors.AddRange(GetPreconfiguredBookAuthors());
            }
            if (!context.Books.Any())
            {
                context.Books.AddRange(GetPreconfiguredBooks());
            } 
            context.SaveChanges();
        }

        private static IEnumerable<BookGenre> GetPreconfiguredBookGenres()
        {
            return new List<BookGenre>()
            {
                new BookGenre(){ Genre="Fantasy" },
                new BookGenre(){ Genre="Science Fiction" }
            };
        }

        private static IEnumerable<BookAuthor> GetPreconfiguredBookAuthors()
        {
            return new List<BookAuthor>()
            {
                new BookAuthor(){ Author="Robert Jordan" },
                new BookAuthor(){ Author="Robert Scheckley" },
                new BookAuthor(){ Author="Isaac Asimov" },
                new BookAuthor(){ Author="George Martin" }
            };
        }

        private static IEnumerable<Book> GetPreconfiguredBooks()
        {
            return new List<Book>()
            {
                new Book() { Title = "From The Two Rivers", Price = 199.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1", Description = "Shoes for next century", Rating=5, BookGenreId=1, BookAuthorId=1 },
                new Book() { Title = "The Wheel of Time", Price= 88.50M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2", Description = "will make you world champions", Rating=5, BookGenreId=1,BookAuthorId=1 },
                new Book() { Title = "Citizen In Space", Price = 129, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3", Description = "You have already won gold medal", Rating= 5, BookGenreId=1,BookAuthorId=2 },
                new Book() { Title = "Pilgrimage To Earth", Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4", Description = "Olympic runner", Rating=5, BookGenreId=1,BookAuthorId=2, },
                new Book() { Title = "The Foundation Trilogy", Price = 188.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5", Description = "Roslyn Red Sheet", Rating=5, BookGenreId=2,BookAuthorId=3 },
                new Book() { Title = "I, Robot", Price = 112, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6", Description = "Lala Land", BookGenreId=2,BookAuthorId=3 },
                new Book() { Title = "A Dance With Dragons", Price = 212, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7", Description = "High in the sky", Rating=5, BookGenreId=1, BookAuthorId=4,  },
                new Book() { Title = "A Feast For Crows", Price = 238.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8", Description = "Light as carbon", Rating=5, BookGenreId=1, BookAuthorId=4 },
                new Book() { Title = "Fire and Blood",  Price = 129, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9", Description = "High Jumper", Rating=5, BookGenreId=1,BookAuthorId=4 }
                
            };
            
        }
    }


        
}

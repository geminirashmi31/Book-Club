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
                new Book() { Title = "From The Two Rivers", Price = 199.5M, PictureUrl = "http://externalbooksbaseurltobereplaced/api/pic/1", Description = "From the Two Rivers is a special edition that contains Part 1 of The Eye of the World, Jordan's internationally bestselling epic fantasy saga, and is a perfect gift for old fans and new.", Rating=5, BookGenreId=1, BookAuthorId=1 },
                new Book() { Title = "The Wheel of Time", Price= 88.50M, PictureUrl = "http://externalbooksbaseurltobereplaced/api/pic/2", Description = "In his fantasy world, the Dark One, the embodiment of pure evil, is breaking free from his prison. ... This saga is not only his story, but the story of an entire world's struggle to deal with war and change, destruction and hope.", Rating=5, BookGenreId=1,BookAuthorId=1 },
                new Book() { Title = "Citizen In Space", Price = 129, PictureUrl = "http://externalbooksbaseurltobereplaced/api/pic/3", Description = "Citizen in Space is a collection of science fiction short stories by American writer Robert Sheckley. It was first published in 1955 by Ballantine Books (catalogue number 126).", Rating= 5, BookGenreId=1,BookAuthorId=2 },
                new Book() { Title = "Pilgrimage To Earth", Price = 12, PictureUrl = "http://externalbooksbaseurltobereplaced/api/pic/4", Description = "In “Pilgrimage to Earth,” on a long-desired trip to the home planet, a young man finds a perfectly developed society and, finally, deep, true love—which, sadly, only lasts for a very limited time before the reset button removes all trace of it.", Rating=5, BookGenreId=1,BookAuthorId=2, },
                new Book() { Title = "The Foundation Trilogy", Price = 188.5M, PictureUrl = "http://externalbooksbaseurltobereplaced/api/pic/5", Description = "Collectively they tell the early story of the Foundation, an institute founded by psychohistorian Hari Seldon to preserve the best of galactic civilization after the collapse of the Galactic Empire.", Rating=5, BookGenreId=2,BookAuthorId=3 },
                new Book() { Title = "I, Robot", Price = 112, PictureUrl = "http://externalbooksbaseurltobereplaced/api/pic/6", Description = "In 2035, highly intelligent robots fill public service positions throughout the world, operating under three rules to keep humans safe.", BookGenreId=2,BookAuthorId=3 },
                new Book() { Title = "Game of Thrones", Price = 212, PictureUrl = "http://externalbooksbaseurltobereplaced/api/pic/7", Description = "A Game of Thrones takes place over the course of one year on or near the fictional continent of Westeros.", Rating=5, BookGenreId=1, BookAuthorId=4,  },
                new Book() { Title = "A Feast For Crows", Price = 238.5M, PictureUrl = "http://externalbooksbaseurltobereplaced/api/pic/8", Description = "A Feast for Crows picks up the tale where A Storm of Swords leaves off and runs simultaneously with events in the following novel, A Dance with Dragons.", Rating=5, BookGenreId=1, BookAuthorId=4 },
                new Book() { Title = "Fire and Blood",  Price = 129, PictureUrl = "http://externalbooksbaseurltobereplaced/api/pic/9", Description = "With all the fire and fury fans have come to expect from internationally bestselling author George R. R. Martin, this is the first volume of the definitive two-part history of the Targaryens in Westeros.", Rating=5, BookGenreId=1,BookAuthorId=4 }
                
            };
            
        }
    }


        
}

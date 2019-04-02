using BookAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) 
            : base(options)
        {

        }

        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookGenre>(ConfigureBookGenre);
            modelBuilder.Entity<BookAuthor>(ConfigureBookAuthor);
            modelBuilder.Entity<Book>(ConfigureBook);
        }

        private void ConfigureBook(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.Property(b => b.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("book_hilo");

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.PictureUrl)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Rating)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(b => b.BookGenre)
                .WithMany()
                .HasForeignKey(b => b.BookGenreId);

            builder.HasOne(b => b.BookAuthor)
                .WithMany()
                .HasForeignKey(b => b.BookAuthorId);
        }

        private void ConfigureBookGenre(EntityTypeBuilder<BookGenre> builder)
        {
            builder.ToTable("BookGenres");
            builder.Property(b => b.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo(("book_genre_hilo"));

            builder.Property(b => b.Genre)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureBookAuthor(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.ToTable("BookAuthors");
            builder.Property(b => b.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo(("book_author_hilo"));

            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(100);
        }

    }
}

using Contracts;
using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataContext
{
    public class BoosterDataContext : CoreDataContext
    {
        public BoosterDataContext(DbContextOptions<BoosterDataContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasMany(x => x.BookAuthor).WithOne(x => x.Book);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasMany(x => x.BookAuthor).WithOne(x => x.Author);
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(x => new { x.BookId, x.AuthorId });
            });
        }
    }
}

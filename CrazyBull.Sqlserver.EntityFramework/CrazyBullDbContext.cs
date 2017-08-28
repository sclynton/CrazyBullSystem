using CrazyBull.Core;
using CrazyBull.Core.Articles;
using CrazyBull.Core.Author;
using CrazyBull.Core.Bookshelves;
using CrazyBull.Core.Comments;
using CrazyBull.Core.Customers;
using Microsoft.EntityFrameworkCore;
using System;

namespace CrazyBull.Sqlserver.EntityFramework
{
    public class CrazyBullDbContext : DbContext
    {
        public CrazyBullDbContext(DbContextOptions<CrazyBullDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Bookshelf> Bookshelves { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}

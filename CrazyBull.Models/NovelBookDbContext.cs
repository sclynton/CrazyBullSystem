using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using CrazyBull.Entity;

namespace CrazyBull.Models
{
    public class NovelBookDbContext : DbContext
    {
        public NovelBookDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Book> Books { get; set; }
    }
}

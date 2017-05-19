using CrazyBull.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace CrazyBull.MySql.EntityFramework
{
    public class CrazyBullDbContext : DbContext
    {
        public CrazyBullDbContext(DbContextOptions<CrazyBullDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}

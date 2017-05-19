using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CrazyBull.MySql.EntityFramework;

namespace CrazyBull.MySql.EntityFramework.Migrations
{
    [DbContext(typeof(CrazyBullDbContext))]
    partial class CrazyBullDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("CrazyBull.Entity.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BookName");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });
        }
    }
}

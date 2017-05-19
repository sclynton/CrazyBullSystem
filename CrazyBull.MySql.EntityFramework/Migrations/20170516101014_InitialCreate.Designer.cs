using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CrazyBull.MySql.EntityFramework;

namespace CrazyBull.MySql.EntityFramework.Migrations
{
    [DbContext(typeof(CrazyBullDbContext))]
    [Migration("20170516101014_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

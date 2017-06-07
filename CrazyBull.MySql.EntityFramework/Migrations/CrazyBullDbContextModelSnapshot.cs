using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CrazyBull.MySql.EntityFramework;
using CrazyBull.Core.Author;
using CrazyBull.Core.Books;

namespace CrazyBull.MySql.EntityFramework.Migrations
{
    [DbContext(typeof(CrazyBullDbContext))]
    partial class CrazyBullDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("CrazyBull.Core.Articles.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsHot");

                    b.Property<string>("Publisher");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("CrazyBull.Core.Author.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Name");

                    b.Property<int>("Sex");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("CrazyBull.Core.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("AuthorName");

                    b.Property<string>("BookName");

                    b.Property<int>("CategoryId");

                    b.Property<int>("ChannelType");

                    b.Property<string>("CoverImage");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Description");

                    b.Property<bool>("IsIndex");

                    b.Property<bool>("IsOver");

                    b.Property<DateTime?>("UpdatedTime");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("CrazyBull.Core.Bookshelves.Bookshelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<int>("CustomerId");

                    b.HasKey("Id");

                    b.ToTable("Bookshelves");
                });

            modelBuilder.Entity("CrazyBull.Core.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Name");

                    b.Property<int>("ParentId");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CrazyBull.Core.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsVip");

                    b.Property<string>("Name");

                    b.Property<int>("WordCount");

                    b.HasKey("Id");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("CrazyBull.Core.Comments.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedTime");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CrazyBull.Core.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Email");

                    b.Property<string>("Head");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });
        }
    }
}

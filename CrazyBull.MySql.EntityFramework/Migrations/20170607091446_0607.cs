using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrazyBull.MySql.EntityFramework.Migrations
{
    public partial class _0607 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChannelType",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsIndex",
                table: "Books",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOver",
                table: "Books",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Content = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    IsHot = table.Column<bool>(nullable: false),
                    Publisher = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookshelves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    BookId = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookshelves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    BookId = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    IsVip = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    WordCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    BookId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Head = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Bookshelves");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ChannelType",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsIndex",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsOver",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Books");
        }
    }
}

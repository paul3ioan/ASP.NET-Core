using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazinData.Migrations
{
    public partial class _20200504022735_20200503193254_InitialMigrationcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aliments",
                columns: table => new
                {
                    AlimentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdusId = table.Column<int>(nullable: false),
                    expirationDate = table.Column<DateTime>(nullable: false),
                    CountryProduction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aliments", x => x.AlimentId);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    BooksId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdusId = table.Column<int>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Style = table.Column<string>(nullable: true),
                    Editor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.BooksId);
                });

            migrationBuilder.CreateTable(
                name: "jucarii",
                columns: table => new
                {
                    JucariiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    MinimumAge = table.Column<int>(nullable: false),
                    Producter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jucarii", x => x.JucariiId);
                });

            migrationBuilder.CreateTable(
                name: "produs",
                columns: table => new
                {
                    ProdusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typee = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Avalability = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    RegistrationNumber = table.Column<int>(nullable: false),
                    Cantitate = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produs", x => x.ProdusID);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Valid = table.Column<int>(nullable: false),
                    data = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Balance = table.Column<int>(nullable: false),
                    Adress = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aliments");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "jucarii");

            migrationBuilder.DropTable(
                name: "produs");

            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}

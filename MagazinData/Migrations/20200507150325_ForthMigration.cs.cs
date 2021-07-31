using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazinData.Migrations
{
    public partial class ForthMigrationcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_transaction",
                table: "transaction");


            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "transaction",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "transaction",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

          

            migrationBuilder.AddPrimaryKey(
                name: "PK_transaction",
                table: "transaction",
                column: "TransactionId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_transaction",
                table: "transaction");


            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "transaction");

   

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "transaction",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

 

            migrationBuilder.AddPrimaryKey(
                name: "PK_transaction",
                table: "transaction",
                column: "UserId");

 
        }
    }
}

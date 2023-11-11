using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trif_Andrei_Lab2.Migrations
{
    public partial class Borrowings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BorrowingID",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Borrowing",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: true),
                    BookID = table.Column<int>(type: "int", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowing", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Borrowing_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BorrowingID",
                table: "Book",
                column: "BorrowingID",
                unique: true,
                filter: "[BorrowingID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_MemberID",
                table: "Borrowing",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Borrowing_BorrowingID",
                table: "Book",
                column: "BorrowingID",
                principalTable: "Borrowing",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Borrowing_BorrowingID",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Borrowing");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Book_BorrowingID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BorrowingID",
                table: "Book");
        }
    }
}

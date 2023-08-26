using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final3.Migrations
{
    /// <inheritdoc />
    public partial class Changing_BorrowerHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistory_Books_BooksBookId",
                table: "BorrowHistory");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "BorrowHistory",
                newName: "IsReturn");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "BorrowHistory",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "BooksBookId",
                table: "BorrowHistory",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "HistoryId",
                table: "BorrowHistory",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowHistory_BooksBookId",
                table: "BorrowHistory",
                newName: "IX_BorrowHistory_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistory_Books_BookId",
                table: "BorrowHistory",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistory_Books_BookId",
                table: "BorrowHistory");

            migrationBuilder.RenameColumn(
                name: "IsReturn",
                table: "BorrowHistory",
                newName: "IsAvailable");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "BorrowHistory",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BorrowHistory",
                newName: "BooksBookId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BorrowHistory",
                newName: "HistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowHistory_BookId",
                table: "BorrowHistory",
                newName: "IX_BorrowHistory_BooksBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistory_Books_BooksBookId",
                table: "BorrowHistory",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

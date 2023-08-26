using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final3.Migrations
{
    /// <inheritdoc />
    public partial class Changing_Books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorsAuthorId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "Books",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "AuthorsAuthorId",
                table: "Books",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorsAuthorId",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Books",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Books",
                newName: "AuthorsAuthorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                newName: "IX_Books_AuthorsAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorsAuthorId",
                table: "Books",
                column: "AuthorsAuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

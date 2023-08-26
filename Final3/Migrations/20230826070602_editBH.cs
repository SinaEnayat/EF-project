using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final3.Migrations
{
    /// <inheritdoc />
    public partial class editBH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistory_Borrower_BorrowerId",
                table: "BorrowHistory");

            migrationBuilder.DropIndex(
                name: "IX_BorrowHistory_BorrowerId",
                table: "BorrowHistory");

            migrationBuilder.DropColumn(
                name: "BorrowerId",
                table: "BorrowHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BorrowerId",
                table: "BorrowHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowHistory_BorrowerId",
                table: "BorrowHistory",
                column: "BorrowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistory_Borrower_BorrowerId",
                table: "BorrowHistory",
                column: "BorrowerId",
                principalTable: "Borrower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

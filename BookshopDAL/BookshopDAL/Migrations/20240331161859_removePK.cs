using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookshopDAL.Migrations
{
    /// <inheritdoc />
    public partial class removePK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedBooks_Books_BookId",
                table: "PurchasedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedBooks_Users_UserId",
                table: "PurchasedBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedBooks",
                table: "PurchasedBooks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PurchasedBooks",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "PurchasedBooks",
                newName: "PurchasedBooksId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedBooks_UserId",
                table: "PurchasedBooks",
                newName: "IX_PurchasedBooks_UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedBooks_PurchasedBooksId",
                table: "PurchasedBooks",
                column: "PurchasedBooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedBooks_Books_PurchasedBooksId",
                table: "PurchasedBooks",
                column: "PurchasedBooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedBooks_Users_UsersId",
                table: "PurchasedBooks",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedBooks_Books_PurchasedBooksId",
                table: "PurchasedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedBooks_Users_UsersId",
                table: "PurchasedBooks");

            migrationBuilder.DropIndex(
                name: "IX_PurchasedBooks_PurchasedBooksId",
                table: "PurchasedBooks");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "PurchasedBooks",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PurchasedBooksId",
                table: "PurchasedBooks",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedBooks_UsersId",
                table: "PurchasedBooks",
                newName: "IX_PurchasedBooks_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedBooks",
                table: "PurchasedBooks",
                columns: new[] { "BookId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedBooks_Books_BookId",
                table: "PurchasedBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedBooks_Users_UserId",
                table: "PurchasedBooks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

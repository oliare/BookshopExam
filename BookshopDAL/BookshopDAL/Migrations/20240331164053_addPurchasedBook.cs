using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookshopDAL.Migrations
{
    /// <inheritdoc />
    public partial class addPurchasedBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedBooks",
                table: "PurchasedBooks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PurchasedBooks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedBooks",
                table: "PurchasedBooks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedBooks_BookId",
                table: "PurchasedBooks",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedBooks",
                table: "PurchasedBooks");

            migrationBuilder.DropIndex(
                name: "IX_PurchasedBooks_BookId",
                table: "PurchasedBooks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PurchasedBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedBooks",
                table: "PurchasedBooks",
                columns: new[] { "BookId", "UserId" });
        }
    }
}

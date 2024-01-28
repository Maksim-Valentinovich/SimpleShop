using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShop.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNameProductId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCardItem_Products_productId",
                table: "ShopCardItem");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "ShopCardItem",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCardItem_productId",
                table: "ShopCardItem",
                newName: "IX_ShopCardItem_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCardItem_Products_ProductId",
                table: "ShopCardItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCardItem_Products_ProductId",
                table: "ShopCardItem");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ShopCardItem",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCardItem_ProductId",
                table: "ShopCardItem",
                newName: "IX_ShopCardItem_productId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCardItem_Products_productId",
                table: "ShopCardItem",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

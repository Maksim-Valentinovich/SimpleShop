using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShop.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShopCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShopCardId",
                table: "ShopCardItem",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShopCardId",
                table: "ShopCardItem",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}

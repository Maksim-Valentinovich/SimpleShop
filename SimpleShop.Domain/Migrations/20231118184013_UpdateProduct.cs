using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShop.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountDay",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountPeople",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountVisit",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameClub",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                table: "Clients",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountDay",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CountPeople",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CountVisit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameClub",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                table: "Clients",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}

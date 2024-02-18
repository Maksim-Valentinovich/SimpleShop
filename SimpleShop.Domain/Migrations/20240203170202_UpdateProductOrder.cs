using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShop.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "CountDay",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "CountPeople",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "CountVisit",
                table: "Subscriptions");

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Subscriptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions",
                columns: new[] { "ProductId", "OrderId", "ClubId" });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ClubId",
                table: "Subscriptions",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Clubs_ClubId",
                table: "Subscriptions",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Clubs_ClubId",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_ClubId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Subscriptions");

            migrationBuilder.AddColumn<int>(
                name: "CountDay",
                table: "Subscriptions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountPeople",
                table: "Subscriptions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountVisit",
                table: "Subscriptions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions",
                columns: new[] { "ProductId", "OrderId" });
        }
    }
}

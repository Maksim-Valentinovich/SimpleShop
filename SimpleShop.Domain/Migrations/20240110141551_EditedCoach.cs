using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShop.Domain.Migrations
{
    /// <inheritdoc />
    public partial class EditedCoach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryCoaches");

            migrationBuilder.AddColumn<int>(
                name: "CategoryCoachId",
                table: "Coaches",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryCoachId",
                table: "Coaches");

            migrationBuilder.CreateTable(
                name: "CategoryCoaches",
                columns: table => new
                {
                    CoachId = table.Column<int>(type: "integer", nullable: false),
                    CategoryPeopleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCoaches", x => new { x.CoachId, x.CategoryPeopleId });
                    table.ForeignKey(
                        name: "FK_CategoryCoaches_CategoriesPeople_CategoryPeopleId",
                        column: x => x.CategoryPeopleId,
                        principalTable: "CategoriesPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryCoaches_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCoaches_CategoryPeopleId",
                table: "CategoryCoaches",
                column: "CategoryPeopleId");
        }
    }
}

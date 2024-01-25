using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShop.Domain.Migrations
{
    /// <inheritdoc />
    public partial class EditClub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clubs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Clubs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "InterpreterFinish",
                table: "Clubs",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "InterpreterStart",
                table: "Clubs",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Clubs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "WeekendsFinish",
                table: "Clubs",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "WeekendsStart",
                table: "Clubs",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "InterpreterFinish",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "InterpreterStart",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "WeekendsFinish",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "WeekendsStart",
                table: "Clubs");
        }
    }
}

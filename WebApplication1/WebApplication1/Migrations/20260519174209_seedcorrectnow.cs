using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class seedcorrectnow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FoundationDate",
                value: new DateOnly(1968, 7, 18));

            migrationBuilder.UpdateData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FoundationDate",
                value: new DateOnly(1993, 4, 5));

            migrationBuilder.UpdateData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 3,
                column: "FoundationDate",
                value: new DateOnly(1994, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FoundationDate",
                value: new DateTime(1968, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FoundationDate",
                value: new DateTime(1993, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 3,
                column: "FoundationDate",
                value: new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

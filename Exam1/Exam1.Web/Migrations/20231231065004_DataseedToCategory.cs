using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Exam1.Web.Migrations
{
    /// <inheritdoc />
    public partial class DataseedToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("880fa994-2866-49ba-8480-6004314d15db"), "Cloths" },
                    { new Guid("c4115907-01c8-4f46-abf4-6a2b217c46f8"), "Electronics" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("880fa994-2866-49ba-8480-6004314d15db"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c4115907-01c8-4f46-abf4-6a2b217c46f8"));
        }
    }
}

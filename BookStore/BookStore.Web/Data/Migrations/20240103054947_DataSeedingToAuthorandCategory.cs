using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedingToAuthorandCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "Name", "ShortBio" },
                values: new object[,]
                {
                    { new Guid("9f508a3b-ab10-48c0-8d87-1da8e107f0f7"), new DateTime(1903, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Orwell", "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949)." },
                    { new Guid("dcbc66f7-0cd5-4ddf-8127-0a43fa39af4e"), new DateTime(1964, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dan Brown", "Daniel Gerhard Brown (born June 22, 1964) is an American author best known for his thriller novels" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1bb035e1-51d2-420f-b1b3-774266a7e173"), "History" },
                    { new Guid("2eb4ed3c-a204-44b2-aaed-a1281c3b5101"), "Adventure" },
                    { new Guid("86e7a421-c040-4fbe-9dc2-243335128538"), "Dystopia" },
                    { new Guid("98450ee3-d8b2-4719-bed9-170090cc300a"), "Crime" },
                    { new Guid("c04c31b2-b3a1-4ae8-b986-8fe47c02f1ad"), "Action" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("9f508a3b-ab10-48c0-8d87-1da8e107f0f7"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("dcbc66f7-0cd5-4ddf-8127-0a43fa39af4e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1bb035e1-51d2-420f-b1b3-774266a7e173"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2eb4ed3c-a204-44b2-aaed-a1281c3b5101"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("86e7a421-c040-4fbe-9dc2-243335128538"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("98450ee3-d8b2-4719-bed9-170090cc300a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c04c31b2-b3a1-4ae8-b986-8fe47c02f1ad"));
        }
    }
}

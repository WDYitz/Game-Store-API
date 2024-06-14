using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seedgenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Genres");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Genres",
                newName: "Title");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: ["Id", "Title"],
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Sports" },
                    { 3, "Racing" },
                    { 4, "Survival" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Genres",
                newName: "ReleaseDate");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Genres",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Genres",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

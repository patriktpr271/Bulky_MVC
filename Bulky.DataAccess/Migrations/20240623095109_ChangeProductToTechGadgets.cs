using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProductToTechGadgets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Products",
                newName: "SKU");

            migrationBuilder.RenameColumn(
                name: "ISBN",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Products",
                newName: "Brand");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ProductName", "SKU" },
                values: new object[] { "Fortune of Time", "SWD9999001" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ProductName", "SKU" },
                values: new object[] { "Dark Skies", "CAW777777701" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ProductName", "SKU" },
                values: new object[] { "Vanish in the Sunset", "RITO5555501" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ProductName", "SKU" },
                values: new object[] { "Cotton Candy", "WS3333333301" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ProductName", "SKU" },
                values: new object[] { "Rock in the Ocean", "SOTJ1111111101" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ProductName", "SKU" },
                values: new object[] { "Leaves and Wonders", "FOT000000001" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SKU",
                table: "Products",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "ISBN");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Products",
                newName: "Author");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "SWD9999001", "Fortune of Time" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "CAW777777701", "Dark Skies" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "RITO5555501", "Vanish in the Sunset" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "WS3333333301", "Cotton Candy" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "SOTJ1111111101", "Rock in the Ocean" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "FOT000000001", "Leaves and Wonders" });
        }
    }
}

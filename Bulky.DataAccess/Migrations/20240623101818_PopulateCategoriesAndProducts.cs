using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PopulateCategoriesAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Name",
                value: "Headphones");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Name",
                value: "Smartphones");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "Tablets");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "DisplayOrder", "Name" },
                values: new object[] { 4, 4, "Gaming Consoles" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "Budapest", "Sony", "+36 1 317 4974", "1053", "Pest", "Kecskeméti utca 4" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "Budapest", "Apple", "+36 30 730 1144", "1095", "Pest", "Könyves Kálmán krt 12-14" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "Seattle", "Microsoft", "+800 426 9400", "95104", "Washington", "920 Fourth Avenue, Suite 2900" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "Description", "ListPrice", "Price", "Price100", "Price50", "ProductName", "SKU" },
                values: new object[] { "Sony", " The Sony WH-1000XM4 offers superior noise-cancellation, 30-hour battery life, and high-resolution audio quality. Equipped with touch sensor controls, quick attention mode, and wearing detection, these headphones provide an exceptional listening experience.", 349.99000000000001, 349.99000000000001, 279.99000000000001, 300.0, "WH-1000XM4 Wireless Noise-Cancelling Headphones", "WH-1000XM4" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "Description", "ListPrice", "Price", "Price100", "Price50", "ProductName", "SKU" },
                values: new object[] { "Apple", "The Apple iPhone 14 Pro features a stunning 6.1-inch Super Retina XDR display, A16 Bionic chip, and an advanced camera system with ProRAW and ProRes video capabilities. With 5G support, Face ID, and a ceramic shield front cover, it offers unmatched performance and durability.", 999.99000000000001, 999.99000000000001, 899.99000000000001, 949.99000000000001, "Apple iPhone 14 Pro", "IP14PRO" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Brand", "Description", "ListPrice", "Price", "Price100", "Price50", "ProductName", "SKU" },
                values: new object[] { "Microsoft", "The Microsoft Surface Pro 9 combines the power of a laptop with the flexibility of a tablet. It features a 13-inch PixelSense touchscreen, 11th Gen Intel Core processor, and up to 15 hours of battery life. With its detachable keyboard and Surface Pen compatibility, it's perfect for both work and creativity. ", 1199.99, 1199.99, 999.99000000000001, 1100.0, " Microsoft Surface Pro 9", "SURFACEPRO9" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Brand", "CategoryId", "Description", "ListPrice", "Price", "Price100", "Price50", "ProductName", "SKU" },
                values: new object[] { "Sony", 4, "The Sony PlayStation 5 (PS5) is a cutting-edge gaming console that offers ultra-high-speed SSD, haptic feedback, adaptive triggers, and 3D audio technology. With stunning 4K graphics and lightning-fast load times, it delivers an immersive gaming experience. ", 499.99000000000001, 499.99000000000001, 349.99000000000001, 400.0, "Sony PlayStation 5", "PS5" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Brand", "Description", "ListPrice", "Price", "Price100", "Price50", "ProductName", "SKU" },
                values: new object[] { "Apple", " The Apple MacBook Pro 16-inch features a stunning Retina display, powerful M1 Pro chip, and up to 21 hours of battery life. With a Magic Keyboard, Touch Bar, and up to 64GB of unified memory, it’s designed for professionals who need high performance and versatility. ", 2499.9899999999998, 2499.9899999999998, 2199.9899999999998, 2399.9899999999998, "Apple MacBook Pro 16-inch", "MBP16M1PRO" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "Description", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "ProductName", "SKU" },
                values: new object[] { 7, "Microsoft", 4, " The Microsoft Xbox Series X is the most powerful Xbox ever, featuring a custom AMD Zen 2 processor, 12 teraflops of processing power, and support for 8K resolution. With a 1TB SSD and backward compatibility, it offers exceptional performance and an expansive game library.", "", 499.99000000000001, 499.99000000000001, 399.99000000000001, 450.0, "Microsoft Xbox Series X", "XBOXSERIESX" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Name",
                value: "Action");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Name",
                value: "Sci-Fi");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "History");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "New York", "Wood.co", "123-456-7890", "10001", "NY", "1234 Elm St" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "New York", "Paper.co", "123-456-7890", "10001", "NY", "1234 Elm St" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[] { "New York", "Ink.co", "123-456-7890", "10001", "NY", "1234 Elm St" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "Description", "ListPrice", "Price", "Price100", "Price50", "ProductName", "SKU" },
                values: new object[] { "Billy Spark", "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", 99.0, 90.0, 80.0, 85.0, "Fortune of Time", "SWD9999001" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "Description", "ListPrice", "Price", "Price100", "Price50", "ProductName", "SKU" },
                values: new object[] { "Nancy Hoover", "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", 40.0, 30.0, 20.0, 25.0, "Dark Skies", "CAW777777701" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Brand", "Description", "ListPrice", "Price", "Price100", "Price50", "ProductName", "SKU" },
                values: new object[] { "Abby Muscles", "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", 70.0, 65.0, 55.0, 60.0, "Cotton Candy", "WS3333333301" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Brand", "CategoryId", "Description", "ListPrice", "Price", "Price100", "Price50", "ProductName", "SKU" },
                values: new object[] { "Ron Parker", 1, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean", "SOTJ1111111101" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Brand", "Description", "ListPrice", "Price", "Price100", "Price50", "ProductName", "SKU" },
                values: new object[] { "Laura Phantom", "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders", "FOT000000001" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "Description", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "ProductName", "SKU" },
                values: new object[] { 3, "Julian Button", 1, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "", 55.0, 50.0, 35.0, 40.0, "Vanish in the Sunset", "RITO5555501" });
        }
    }
}

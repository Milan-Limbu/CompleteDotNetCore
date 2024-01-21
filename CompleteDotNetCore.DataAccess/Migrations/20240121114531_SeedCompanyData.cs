using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompleteDotNetCore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCompanyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "City", "Name", "PhoneNumber", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, null, "Tech City", "Tech Solution", "6669990000", "IL", "12121" },
                    { 2, null, "Vid City", "Vivid Books", "7779990000", "IL", "66666" },
                    { 3, null, "Lala land", "Readers Club", "1113335555", "NY", "99999" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

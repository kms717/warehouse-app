using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseApp.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Sales");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Sales",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "КГТ" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Sales",
                type: "INTEGER",
                nullable: true);
        }
    }
}

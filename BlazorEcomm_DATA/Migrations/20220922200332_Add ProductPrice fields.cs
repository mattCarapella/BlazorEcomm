using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcomm_DATA.Migrations
{
    public partial class AddProductPricefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CPUCores",
                table: "ProductPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CPUModel",
                table: "ProductPrices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Display",
                table: "ProductPrices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GPU",
                table: "ProductPrices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GPUCores",
                table: "ProductPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Memory",
                table: "ProductPrices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScreenSize",
                table: "ProductPrices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Storage",
                table: "ProductPrices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPUCores",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "CPUModel",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "Display",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "GPU",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "GPUCores",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "Memory",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "ScreenSize",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "Storage",
                table: "ProductPrices");
        }
    }
}

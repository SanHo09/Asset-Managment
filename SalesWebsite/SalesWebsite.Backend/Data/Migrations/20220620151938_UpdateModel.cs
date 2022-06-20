using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebsite.Backend.Data.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Rate_RateId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Rate_RateId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_RateId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Customers_RateId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RateId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RateId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "Customersid",
                table: "Rate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Rate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rate_Customersid",
                table: "Rate",
                column: "Customersid");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_ProductsId",
                table: "Rate",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_Customers_Customersid",
                table: "Rate",
                column: "Customersid",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_Products_ProductsId",
                table: "Rate",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rate_Customers_Customersid",
                table: "Rate");

            migrationBuilder.DropForeignKey(
                name: "FK_Rate_Products_ProductsId",
                table: "Rate");

            migrationBuilder.DropIndex(
                name: "IX_Rate_Customersid",
                table: "Rate");

            migrationBuilder.DropIndex(
                name: "IX_Rate_ProductsId",
                table: "Rate");

            migrationBuilder.DropColumn(
                name: "Customersid",
                table: "Rate");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Rate");

            migrationBuilder.AddColumn<int>(
                name: "RateId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RateId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_RateId",
                table: "Products",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RateId",
                table: "Customers",
                column: "RateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Rate_RateId",
                table: "Customers",
                column: "RateId",
                principalTable: "Rate",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Rate_RateId",
                table: "Products",
                column: "RateId",
                principalTable: "Rate",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebsite.Backend.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categorys_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Rate_Customers_Customersid",
                table: "Rate");

            migrationBuilder.DropForeignKey(
                name: "FK_Rate_Products_ProductsId",
                table: "Rate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rate",
                table: "Rate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys");

            migrationBuilder.RenameTable(
                name: "Rate",
                newName: "Rates");

            migrationBuilder.RenameTable(
                name: "Categorys",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "Rates",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Customersid",
                table: "Rates",
                newName: "Customerid");

            migrationBuilder.RenameIndex(
                name: "IX_Rate_ProductsId",
                table: "Rates",
                newName: "IX_Rates_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Rate_Customersid",
                table: "Rates",
                newName: "IX_Rates_Customerid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rates",
                table: "Rates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Customers_Customerid",
                table: "Rates",
                column: "Customerid",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Products_ProductId",
                table: "Rates",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Customers_Customerid",
                table: "Rates");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Products_ProductId",
                table: "Rates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rates",
                table: "Rates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Rates",
                newName: "Rate");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorys");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Rate",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "Customerid",
                table: "Rate",
                newName: "Customersid");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_ProductId",
                table: "Rate",
                newName: "IX_Rate_ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_Customerid",
                table: "Rate",
                newName: "IX_Rate_Customersid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rate",
                table: "Rate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categorys_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}

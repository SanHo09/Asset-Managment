using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebsite.Backend.Data.Migrations
{
    public partial class updateCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRate");

            migrationBuilder.AddColumn<int>(
                name: "RateId",
                table: "Customers",
                type: "int",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Rate_RateId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_RateId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RateId",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "CustomerRate",
                columns: table => new
                {
                    Customersid = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRate", x => new { x.Customersid, x.Id });
                    table.ForeignKey(
                        name: "FK_CustomerRate_Customers_Customersid",
                        column: x => x.Customersid,
                        principalTable: "Customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerRate_Rate_Id",
                        column: x => x.Id,
                        principalTable: "Rate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRate_Id",
                table: "CustomerRate",
                column: "Id");
        }
    }
}

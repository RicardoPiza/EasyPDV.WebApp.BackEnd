using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyPDV.BackEnd.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CancelledSales",
                columns: table => new
                {
                    CancelledSaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelledSales", x => x.CancelledSaleId);
                });

            migrationBuilder.CreateTable(
                name: "Cashier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashierNumber = table.Column<int>(type: "int", nullable: false),
                    CashierResponsible = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashierBleed",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashierBleed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegularSales",
                columns: table => new
                {
                    RegularSaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularSales", x => x.RegularSaleId);
                });

            migrationBuilder.CreateTable(
                name: "CashierOpen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    InitialBalance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashierOpen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashierOpen_Cashier_Id",
                        column: x => x.Id,
                        principalTable: "Cashier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoldProducts",
                columns: table => new
                {
                    SoldProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancelledSaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegularSaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldProducts", x => x.SoldProductId);
                    table.ForeignKey(
                        name: "FK_SoldProducts_CancelledSales_CancelledSaleId",
                        column: x => x.CancelledSaleId,
                        principalTable: "CancelledSales",
                        principalColumn: "CancelledSaleId");
                    table.ForeignKey(
                        name: "FK_SoldProducts_RegularSales_RegularSaleId",
                        column: x => x.RegularSaleId,
                        principalTable: "RegularSales",
                        principalColumn: "RegularSaleId");
                });

            migrationBuilder.CreateTable(
                name: "IndividualSales",
                columns: table => new
                {
                    IndividualSaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoldProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualSales", x => x.IndividualSaleId);
                    table.ForeignKey(
                        name: "FK_IndividualSales_SoldProducts_SoldProductId",
                        column: x => x.SoldProductId,
                        principalTable: "SoldProducts",
                        principalColumn: "SoldProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReversedSales",
                columns: table => new
                {
                    ReversedSaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductChangeFromSoldProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductChangeToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    ChangeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReversedSales", x => x.ReversedSaleId);
                    table.ForeignKey(
                        name: "FK_ReversedSales_Products_ProductChangeToId",
                        column: x => x.ProductChangeToId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReversedSales_SoldProducts_ProductChangeFromSoldProductId",
                        column: x => x.ProductChangeFromSoldProductId,
                        principalTable: "SoldProducts",
                        principalColumn: "SoldProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndividualSales_SoldProductId",
                table: "IndividualSales",
                column: "SoldProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReversedSales_ProductChangeFromSoldProductId",
                table: "ReversedSales",
                column: "ProductChangeFromSoldProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReversedSales_ProductChangeToId",
                table: "ReversedSales",
                column: "ProductChangeToId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldProducts_CancelledSaleId",
                table: "SoldProducts",
                column: "CancelledSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldProducts_RegularSaleId",
                table: "SoldProducts",
                column: "RegularSaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashierBleed");

            migrationBuilder.DropTable(
                name: "CashierOpen");

            migrationBuilder.DropTable(
                name: "IndividualSales");

            migrationBuilder.DropTable(
                name: "ReversedSales");

            migrationBuilder.DropTable(
                name: "Cashier");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SoldProducts");

            migrationBuilder.DropTable(
                name: "CancelledSales");

            migrationBuilder.DropTable(
                name: "RegularSales");
        }
    }
}

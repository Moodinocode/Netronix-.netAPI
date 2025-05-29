using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netronix.API.Migrations
{
    /// <inheritdoc />
    public partial class hopefullyfixedthedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VariantOptions_InventoryItems_InventoryItemId",
                table: "VariantOptions");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_VariantOptions_InventoryItemId",
                table: "VariantOptions");

            migrationBuilder.DropColumn(
                name: "InventoryItemId",
                table: "VariantOptions");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "VariantOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "VariantOptions");

            migrationBuilder.AddColumn<Guid>(
                name: "InventoryItemId",
                table: "VariantOptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VariantOptions_InventoryItemId",
                table: "VariantOptions",
                column: "InventoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_ProductId",
                table: "InventoryItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_VariantOptions_InventoryItems_InventoryItemId",
                table: "VariantOptions",
                column: "InventoryItemId",
                principalTable: "InventoryItems",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BettingSite.Migrations
{
    /// <inheritdoc />
    public partial class addingBid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "basePrice");

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bidPrice = table.Column<float>(type: "real", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bids_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_productId",
                table: "Bids",
                column: "productId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.RenameColumn(
                name: "basePrice",
                table: "Products",
                newName: "price");
        }
    }
}

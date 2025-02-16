using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BettingSite.Migrations
{
    /// <inheritdoc />
    public partial class addingPriceAndDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "Products",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Products");
        }
    }
}

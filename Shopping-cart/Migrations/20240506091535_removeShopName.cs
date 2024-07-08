using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_cart.Migrations
{
    public partial class removeShopName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopName",
                table: "SellerApplications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopName",
                table: "SellerApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

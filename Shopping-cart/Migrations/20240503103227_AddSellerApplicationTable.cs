using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_cart.Migrations
{
    public partial class AddSellerApplicationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SellerApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerApplications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SellerApplications_UserId",
                table: "SellerApplications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellerApplications");
        }
    }
}

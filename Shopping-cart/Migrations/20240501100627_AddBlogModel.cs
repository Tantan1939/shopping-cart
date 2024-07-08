using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_cart.Migrations
{
    public partial class AddBlogModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SC");

            migrationBuilder.CreateTable(
                name: "Blogs",
                schema: "SC",
                columns: table => new
                {
                    BlogNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Tite as title"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BlogPk", x => x.BlogNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs",
                schema: "SC");
        }
    }
}

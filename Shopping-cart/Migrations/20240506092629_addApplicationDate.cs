using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_cart.Migrations
{
    public partial class addApplicationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicationDate",
                table: "SellerApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationDate",
                table: "SellerApplications");
        }
    }
}

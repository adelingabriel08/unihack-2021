using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpYourCity.API.Migrations
{
    public partial class ModifyPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsSuccesful",
                table: "Payments");

            migrationBuilder.AddColumn<string>(
                name: "EventId",
                table: "Payments",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Payments",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RequestId",
                table: "Payments",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Payments");

            migrationBuilder.AddColumn<uint>(
                name: "Amount",
                table: "Payments",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuccesful",
                table: "Payments",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}

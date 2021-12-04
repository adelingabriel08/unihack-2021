using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpYourCity.API.Migrations
{
    public partial class donorChanges3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Payments_PaymentId",
                table: "Donors");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Donors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Payments_PaymentId",
                table: "Donors",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Payments_PaymentId",
                table: "Donors");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Donors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Payments_PaymentId",
                table: "Donors",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

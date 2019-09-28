using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDesk.Migrations
{
    public partial class nullableDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckoutTime",
                table: "ServicePets",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckinTime",
                table: "ServicePets",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "273ef2eb-6e06-4e15-b98a-d71559b45b02", "AQAAAAEAACcQAAAAEHMKRkkiBcP8o1v0UjeEFJZW4jsQRCKItK6GokWFVmvpJzaWd4eA3IfhSfYL33Ajsw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckoutTime",
                table: "ServicePets",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckinTime",
                table: "ServicePets",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4ca1589b-cef2-4b97-b61a-a0d78ceafb89", "AQAAAAEAACcQAAAAEITI3/2CQKU6201DgaA0NhV2lEtpDBNiFDAf1kvY+izTP6xzgJNs//JQyh4cGGXOCA==" });
        }
    }
}

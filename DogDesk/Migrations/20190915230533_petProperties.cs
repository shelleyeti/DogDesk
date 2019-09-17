using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDesk.Migrations
{
    public partial class petProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CheckinTime",
                table: "ServicePets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckoutTime",
                table: "ServicePets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ServiceNote",
                table: "ServicePets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AmountFood",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PetNote",
                table: "Pets",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e2d4ce28-9191-4f6f-8a7f-d1d2644bbb0f", "AQAAAAEAACcQAAAAEMPUBDI7uukHNm1YStBYzP7fTorHL6HOQygrr9DXpzMz+cMdxJegl6bwk9qjxOmw+A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckinTime",
                table: "ServicePets");

            migrationBuilder.DropColumn(
                name: "CheckoutTime",
                table: "ServicePets");

            migrationBuilder.DropColumn(
                name: "ServiceNote",
                table: "ServicePets");

            migrationBuilder.DropColumn(
                name: "AmountFood",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetNote",
                table: "Pets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a18ac14-9443-4342-815a-2c0758de1372", "AQAAAAEAACcQAAAAEAhn6GbnmZHVcvOPV/1cc8g0H5v6OLLJ41fNhgJiYFn3RqjVIuv/HOHCiFIUeQ2MhQ==" });
        }
    }
}

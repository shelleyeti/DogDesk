using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDesk.Migrations
{
    public partial class petImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PetImage",
                table: "Pets",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a13294d5-ac08-4d19-993c-f5b3cd147dc6", "AQAAAAEAACcQAAAAEFHRwNoYpmZdhV67JxeJnCdJ8A07VfrIJHGO+Nu0Lg8BCdr1v8DT5KyrZPYStcOIzg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetImage",
                table: "Pets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e2d4ce28-9191-4f6f-8a7f-d1d2644bbb0f", "AQAAAAEAACcQAAAAEMPUBDI7uukHNm1YStBYzP7fTorHL6HOQygrr9DXpzMz+cMdxJegl6bwk9qjxOmw+A==" });
        }
    }
}

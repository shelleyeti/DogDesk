using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDesk.Migrations
{
    public partial class pe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4ca1589b-cef2-4b97-b61a-a0d78ceafb89", "AQAAAAEAACcQAAAAEITI3/2CQKU6201DgaA0NhV2lEtpDBNiFDAf1kvY+izTP6xzgJNs//JQyh4cGGXOCA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a13294d5-ac08-4d19-993c-f5b3cd147dc6", "AQAAAAEAACcQAAAAEFHRwNoYpmZdhV67JxeJnCdJ8A07VfrIJHGO+Nu0Lg8BCdr1v8DT5KyrZPYStcOIzg==" });
        }
    }
}

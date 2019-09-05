using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDesk.Migrations
{
    public partial class petModelBreed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Pets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Pets",
                newName: "Breed");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09cbabf0-80ad-4ea3-95ff-583735e620ac", "AQAAAAEAACcQAAAAEFHZ4/Z7lNjZBvcG+cZkiD0R9M3FNjkZU4Lw6/F+Gw5NPB7eKyYM5mFuQ8MPktOtTw==" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Breed", "Name" },
                values: new object[] { "aussie mix", "Cavy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pets",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Breed",
                table: "Pets",
                newName: "FirstName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "546b7086-a229-44e2-9ae4-e8102ee21a53", "AQAAAAEAACcQAAAAEFkmSV1YrxP65idcQWjWeJRlyCwoGoblYpxaeEVg0+oLvdLCv8LGkaI4VF0JmfRlcQ==" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Cavy", "Arnold" });
        }
    }
}

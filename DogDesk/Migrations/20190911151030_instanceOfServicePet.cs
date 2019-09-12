using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDesk.Migrations
{
    public partial class instanceOfServicePet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceNameId",
                table: "ServicePets",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9131df12-3f0b-43ac-9cfc-21489fdfbd9a", "AQAAAAEAACcQAAAAEOYSHDYIAMkh2vV4sMcvbEA1IcVeS3Y4hYseEwEDyzMsb6EcgVERIPQF/kf6kPps5Q==" });

            migrationBuilder.CreateIndex(
                name: "IX_ServicePets_ServiceNameId",
                table: "ServicePets",
                column: "ServiceNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePets_ServiceTypes_ServiceNameId",
                table: "ServicePets",
                column: "ServiceNameId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicePets_ServiceTypes_ServiceNameId",
                table: "ServicePets");

            migrationBuilder.DropIndex(
                name: "IX_ServicePets_ServiceNameId",
                table: "ServicePets");

            migrationBuilder.DropColumn(
                name: "ServiceNameId",
                table: "ServicePets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "99f040ea-6519-4a72-899e-8a29006b036d", "AQAAAAEAACcQAAAAEFuav34oFGFR3kIuLgcL7rciG84M5koUQavkCh07idu7zDqNU8BjHqf4UGAHg1VECQ==" });
        }
    }
}

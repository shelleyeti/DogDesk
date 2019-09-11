using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDesk.Migrations
{
    public partial class fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "11bb590a-8268-44e3-9186-eea556f8359e", "AQAAAAEAACcQAAAAEBalhafWEmzgv6QooW8BH1zFmLlLBu8QOPkJ5UlYeA5c+zTX5wM2/rhL6x1eTob/vw==" });

            migrationBuilder.CreateIndex(
                name: "IX_ServicePets_ServiceType",
                table: "ServicePets",
                column: "ServiceType");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePets_ServiceTypes_ServiceType",
                table: "ServicePets",
                column: "ServiceType",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicePets_ServiceTypes_ServiceType",
                table: "ServicePets");

            migrationBuilder.DropIndex(
                name: "IX_ServicePets_ServiceType",
                table: "ServicePets");

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
    }
}

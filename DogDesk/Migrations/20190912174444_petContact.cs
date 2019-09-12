using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DogDesk.Migrations
{
    public partial class petContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Pets_PetId",
                table: "EmergencyContacts");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "EmergencyContacts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "PetContactss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PetId = table.Column<int>(nullable: false),
                    EmergencyContactId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetContactss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetContactss_EmergencyContacts_EmergencyContactId",
                        column: x => x.EmergencyContactId,
                        principalTable: "EmergencyContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetContactss_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a18ac14-9443-4342-815a-2c0758de1372", "AQAAAAEAACcQAAAAEAhn6GbnmZHVcvOPV/1cc8g0H5v6OLLJ41fNhgJiYFn3RqjVIuv/HOHCiFIUeQ2MhQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_PetContactss_EmergencyContactId",
                table: "PetContactss",
                column: "EmergencyContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PetContactss_PetId",
                table: "PetContactss",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Pets_PetId",
                table: "EmergencyContacts",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Pets_PetId",
                table: "EmergencyContacts");

            migrationBuilder.DropTable(
                name: "PetContactss");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "EmergencyContacts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11bb590a-8268-44e3-9186-eea556f8359e", "AQAAAAEAACcQAAAAEBalhafWEmzgv6QooW8BH1zFmLlLBu8QOPkJ5UlYeA5c+zTX5wM2/rhL6x1eTob/vw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Pets_PetId",
                table: "EmergencyContacts",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

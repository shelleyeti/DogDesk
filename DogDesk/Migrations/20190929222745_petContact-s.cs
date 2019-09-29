using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDesk.Migrations
{
    public partial class petContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetContactss_EmergencyContacts_EmergencyContactId",
                table: "PetContactss");

            migrationBuilder.DropForeignKey(
                name: "FK_PetContactss_Pets_PetId",
                table: "PetContactss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetContactss",
                table: "PetContactss");

            migrationBuilder.RenameTable(
                name: "PetContactss",
                newName: "PetContacts");

            migrationBuilder.RenameIndex(
                name: "IX_PetContactss_PetId",
                table: "PetContacts",
                newName: "IX_PetContacts_PetId");

            migrationBuilder.RenameIndex(
                name: "IX_PetContactss_EmergencyContactId",
                table: "PetContacts",
                newName: "IX_PetContacts_EmergencyContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetContacts",
                table: "PetContacts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6395bf3-1537-4035-90fa-a1dca71cfdf0", "AQAAAAEAACcQAAAAEB88eEWhDOpCq0ai51gNRNBs99HLvikENx95vn1eFz1FBren0y/+JdUEoh+nSnqglQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_PetContacts_EmergencyContacts_EmergencyContactId",
                table: "PetContacts",
                column: "EmergencyContactId",
                principalTable: "EmergencyContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetContacts_Pets_PetId",
                table: "PetContacts",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetContacts_EmergencyContacts_EmergencyContactId",
                table: "PetContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PetContacts_Pets_PetId",
                table: "PetContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetContacts",
                table: "PetContacts");

            migrationBuilder.RenameTable(
                name: "PetContacts",
                newName: "PetContactss");

            migrationBuilder.RenameIndex(
                name: "IX_PetContacts_PetId",
                table: "PetContactss",
                newName: "IX_PetContactss_PetId");

            migrationBuilder.RenameIndex(
                name: "IX_PetContacts_EmergencyContactId",
                table: "PetContactss",
                newName: "IX_PetContactss_EmergencyContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetContactss",
                table: "PetContactss",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "273ef2eb-6e06-4e15-b98a-d71559b45b02", "AQAAAAEAACcQAAAAEHMKRkkiBcP8o1v0UjeEFJZW4jsQRCKItK6GokWFVmvpJzaWd4eA3IfhSfYL33Ajsw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_PetContactss_EmergencyContacts_EmergencyContactId",
                table: "PetContactss",
                column: "EmergencyContactId",
                principalTable: "EmergencyContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetContactss_Pets_PetId",
                table: "PetContactss",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

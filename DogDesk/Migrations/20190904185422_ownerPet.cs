using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDesk.Migrations
{
    public partial class ownerPet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Owners");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Pets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1d0bd0c-df07-47a0-82cd-bbd49d71de4e", "AQAAAAEAACcQAAAAEOaVs28d2ISTC3ApYE9y6SPkx0pxZ0c3i1ICWi6SkrwkH89HniO509WT2P+Mt005wA==" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "OwnerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "ServiceName",
                value: "Nail Trim");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePets_PetId",
                table: "ServicePets",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_PetOwners_OwnerId",
                table: "PetOwners",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PetOwners_PetId",
                table: "PetOwners",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_PetId",
                table: "EmergencyContacts",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Pets_PetId",
                table: "EmergencyContacts",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_Owners_OwnerId",
                table: "PetOwners",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_Pets_PetId",
                table: "PetOwners",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePets_Pets_PetId",
                table: "ServicePets",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Pets_PetId",
                table: "EmergencyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_Owners_OwnerId",
                table: "PetOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_Pets_PetId",
                table: "PetOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePets_Pets_PetId",
                table: "ServicePets");

            migrationBuilder.DropIndex(
                name: "IX_ServicePets_PetId",
                table: "ServicePets");

            migrationBuilder.DropIndex(
                name: "IX_PetOwners_OwnerId",
                table: "PetOwners");

            migrationBuilder.DropIndex(
                name: "IX_PetOwners_PetId",
                table: "PetOwners");

            migrationBuilder.DropIndex(
                name: "IX_EmergencyContacts_PetId",
                table: "EmergencyContacts");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Owners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5d761841-7a8d-415d-a260-d91b084d4126", "AQAAAAEAACcQAAAAEF5mOlWD3zKmmSyNB2RmVFq1fcpo13l9xOeddhc7ndKRykfHfKh2WfWD7JTVq27HIw==" });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1,
                column: "PetId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "ServiceName",
                value: "Nails");
        }
    }
}

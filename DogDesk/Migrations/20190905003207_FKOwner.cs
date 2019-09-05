using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDesk.Migrations
{
    public partial class FKOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "546b7086-a229-44e2-9ae4-e8102ee21a53", "AQAAAAEAACcQAAAAEFkmSV1YrxP65idcQWjWeJRlyCwoGoblYpxaeEVg0+oLvdLCv8LGkaI4VF0JmfRlcQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_PetOwners_OwnerId",
                table: "PetOwners",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_Owners_OwnerId",
                table: "PetOwners",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_Owners_OwnerId",
                table: "PetOwners");

            migrationBuilder.DropIndex(
                name: "IX_PetOwners_OwnerId",
                table: "PetOwners");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c97b48b-f3af-4d5c-9f83-093954a847d0", "AQAAAAEAACcQAAAAECK3vw8tfz4GoUNNbTCzpGYPS1jDpUXxYC/vOxSAF1O4BGLqoRIkZhStWN2OEuHITA==" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDesk.Migrations
{
    public partial class FKPet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AnimalGenders_GenderOfAnimalId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AnimalSizes_SizeOfAnimalId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_GenderOfAnimalId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_SizeOfAnimalId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "GenderOfAnimalId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "SizeOfAnimalId",
                table: "Pets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27937653-5bf6-4133-8213-929d727de274", "AQAAAAEAACcQAAAAEEaXHLfMRE9E2BAJYJQSFmJ/1VaVTQacFa1zQeMJuGP179YHBFbo25pQ3Qx2mIXbfw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_GenderId",
                table: "Pets",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_SizeId",
                table: "Pets",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AnimalGenders_GenderId",
                table: "Pets",
                column: "GenderId",
                principalTable: "AnimalGenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AnimalSizes_SizeId",
                table: "Pets",
                column: "SizeId",
                principalTable: "AnimalSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AnimalGenders_GenderId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AnimalSizes_SizeId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_GenderId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_SizeId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "GenderOfAnimalId",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeOfAnimalId",
                table: "Pets",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "60fb0c80-d9c2-450e-8d65-162bf49e48f1", "AQAAAAEAACcQAAAAEFhhXTWpG1EclMs/vWy+wJ35XbthsGiTalPKdKOEFtFNXmd0y6T7Edu6CjvxEM+3rg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_GenderOfAnimalId",
                table: "Pets",
                column: "GenderOfAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_SizeOfAnimalId",
                table: "Pets",
                column: "SizeOfAnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AnimalGenders_GenderOfAnimalId",
                table: "Pets",
                column: "GenderOfAnimalId",
                principalTable: "AnimalGenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AnimalSizes_SizeOfAnimalId",
                table: "Pets",
                column: "SizeOfAnimalId",
                principalTable: "AnimalSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

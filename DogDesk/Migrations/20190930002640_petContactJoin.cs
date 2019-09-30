using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDesk.Migrations
{
    public partial class petContactJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f7f4ded0-ddb5-47a1-8352-9c79c124235d", "AQAAAAEAACcQAAAAENTVx5FNJyvaltxo1J4TuoWy98g8u/02C66FuuK1cUn14I2TwJ2dy8lAL+Ybccu2zA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000-shelley-arnold-333-7777777",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6395bf3-1537-4035-90fa-a1dca71cfdf0", "AQAAAAEAACcQAAAAEB88eEWhDOpCq0ai51gNRNBs99HLvikENx95vn1eFz1FBren0y/+JdUEoh+nSnqglQ==" });
        }
    }
}

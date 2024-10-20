using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalCoreProject.DataAccessLayer.Migrations
{
    public partial class mig28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Destinations");

            migrationBuilder.AddColumn<int>(
       name: "CityId",
       table: "Destinations",
       type: "int",
       nullable: true); // nullable true yapıldı

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_CityId",
                table: "Destinations",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Cities_CityId",
                table: "Destinations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Cities_CityId",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_CityId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Destinations");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

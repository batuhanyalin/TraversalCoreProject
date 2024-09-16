using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalCoreProject.DataAccessLayer.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Destinations_DestinationId1",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_DestinationId1",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "DestinationId1",
                table: "Destinations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationId1",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_DestinationId1",
                table: "Destinations",
                column: "DestinationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Destinations_DestinationId1",
                table: "Destinations",
                column: "DestinationId1",
                principalTable: "Destinations",
                principalColumn: "DestinationId");
        }
    }
}

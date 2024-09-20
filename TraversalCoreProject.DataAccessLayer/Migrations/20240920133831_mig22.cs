using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalCoreProject.DataAccessLayer.Migrations
{
    public partial class mig22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DestinationId",
                table: "AspNetUsers",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Destinations_DestinationId",
                table: "AspNetUsers",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Destinations_DestinationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DestinationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "AspNetUsers");
        }
    }
}

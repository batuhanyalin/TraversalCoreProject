using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalCoreProject.DataAccessLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Testimonials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationId1",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_DestinationId",
                table: "Testimonials",
                column: "DestinationId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_Destinations_DestinationId",
                table: "Testimonials",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Destinations_DestinationId1",
                table: "Destinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_Destinations_DestinationId",
                table: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_Testimonials_DestinationId",
                table: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_DestinationId1",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "DestinationId1",
                table: "Destinations");
        }
    }
}

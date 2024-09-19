using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalCoreProject.DataAccessLayer.Migrations
{
    public partial class mig19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_AspNetUsers_MemberId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Destinations_DestinationId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_MemberId",
                table: "Reservations",
                newName: "IX_Reservations_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_DestinationId",
                table: "Reservations",
                newName: "IX_Reservations_DestinationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_MemberId",
                table: "Reservations",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Destinations_DestinationId",
                table: "Reservations",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_MemberId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Destinations_DestinationId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MemberId",
                table: "Reservation",
                newName: "IX_Reservation_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_DestinationId",
                table: "Reservation",
                newName: "IX_Reservation_DestinationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_AspNetUsers_MemberId",
                table: "Reservation",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Destinations_DestinationId",
                table: "Reservation",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

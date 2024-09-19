using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalCoreProject.DataAccessLayer.Migrations
{
    public partial class mig20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PersonCount",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PersonCount",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

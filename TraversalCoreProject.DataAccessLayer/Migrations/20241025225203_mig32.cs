using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalCoreProject.DataAccessLayer.Migrations
{
    public partial class mig32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description2",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "ImageUrl1",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "LittleTitle",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Title2",
                table: "Abouts");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl1",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LittleTitle",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Abouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

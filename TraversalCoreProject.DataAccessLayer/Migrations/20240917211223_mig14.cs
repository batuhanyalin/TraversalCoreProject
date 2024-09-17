using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalCoreProject.DataAccessLayer.Migrations
{
    public partial class mig14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_MemberId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Destinations_DestinationId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_DestinationTag_Destinations_DestinationId",
                table: "DestinationTag");

            migrationBuilder.DropForeignKey(
                name: "FK_DestinationTag_Tag_TagId",
                table: "DestinationTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DestinationTag",
                table: "DestinationTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "DestinationTag",
                newName: "DestinationTags");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_DestinationTag_TagId",
                table: "DestinationTags",
                newName: "IX_DestinationTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_DestinationTag_DestinationId",
                table: "DestinationTags",
                newName: "IX_DestinationTags_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_MemberId",
                table: "Comments",
                newName: "IX_Comments_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_DestinationId",
                table: "Comments",
                newName: "IX_Comments_DestinationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DestinationTags",
                table: "DestinationTags",
                column: "DestinationTagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_MemberId",
                table: "Comments",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Destinations_DestinationId",
                table: "Comments",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationTags_Destinations_DestinationId",
                table: "DestinationTags",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationTags_Tags_TagId",
                table: "DestinationTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_MemberId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Destinations_DestinationId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_DestinationTags_Destinations_DestinationId",
                table: "DestinationTags");

            migrationBuilder.DropForeignKey(
                name: "FK_DestinationTags_Tags_TagId",
                table: "DestinationTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DestinationTags",
                table: "DestinationTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "DestinationTags",
                newName: "DestinationTag");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_DestinationTags_TagId",
                table: "DestinationTag",
                newName: "IX_DestinationTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_DestinationTags_DestinationId",
                table: "DestinationTag",
                newName: "IX_DestinationTag_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MemberId",
                table: "Comment",
                newName: "IX_Comment_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_DestinationId",
                table: "Comment",
                newName: "IX_Comment_DestinationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DestinationTag",
                table: "DestinationTag",
                column: "DestinationTagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_MemberId",
                table: "Comment",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Destinations_DestinationId",
                table: "Comment",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationTag_Destinations_DestinationId",
                table: "DestinationTag",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationTag_Tag_TagId",
                table: "DestinationTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

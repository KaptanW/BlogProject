using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class commentuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "BlogsComments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BlogsComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BlogsComments_AppUserId",
                table: "BlogsComments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogsComments_UserId",
                table: "BlogsComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsComments_AspNetUsers_AppUserId",
                table: "BlogsComments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsComments_AspNetUsers_UserId",
                table: "BlogsComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogsComments_AspNetUsers_AppUserId",
                table: "BlogsComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogsComments_AspNetUsers_UserId",
                table: "BlogsComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogsComments_AppUserId",
                table: "BlogsComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogsComments_UserId",
                table: "BlogsComments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "BlogsComments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BlogsComments");
        }
    }
}

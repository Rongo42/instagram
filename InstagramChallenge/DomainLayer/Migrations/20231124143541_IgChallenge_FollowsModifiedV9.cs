using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    /// <inheritdoc />
    public partial class IgChallenge_FollowsModifiedV9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_PosterId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "PosterId",
                table: "Posts",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PosterId",
                table: "Posts",
                newName: "IX_Posts_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_OwnerId",
                table: "Posts",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onUpdate: ReferentialAction.NoAction,
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_OwnerId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Posts",
                newName: "PosterId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_OwnerId",
                table: "Posts",
                newName: "IX_Posts_PosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_PosterId",
                table: "Posts",
                column: "PosterId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    /// <inheritdoc />
    public partial class IgChallenge_FollowsModifiedV6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_PostOwnerId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "PostOwnerId",
                table: "Posts",
                newName: "PosterId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PostOwnerId",
                table: "Posts",
                newName: "IX_Posts_PosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_PosterId",
                table: "Posts",
                column: "PosterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_PosterId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "PosterId",
                table: "Posts",
                newName: "PostOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PosterId",
                table: "Posts",
                newName: "IX_Posts_PostOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_PostOwnerId",
                table: "Posts",
                column: "PostOwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

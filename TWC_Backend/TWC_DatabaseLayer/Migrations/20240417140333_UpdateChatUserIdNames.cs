using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWC_DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChatUserIdNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId2",
                table: "Chats",
                newName: "User2Id");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Chats",
                newName: "User1Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User2Id",
                table: "Chats",
                newName: "UserId2");

            migrationBuilder.RenameColumn(
                name: "User1Id",
                table: "Chats",
                newName: "UserId1");
        }
    }
}

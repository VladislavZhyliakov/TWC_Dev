using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWC_DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserTags_TagId",
                table: "UserTags");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTags_TagId",
                table: "ProjectTags");

            migrationBuilder.CreateIndex(
                name: "IX_UserTags_TagId",
                table: "UserTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTags_TagId",
                table: "ProjectTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserTags_TagId",
                table: "UserTags");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTags_TagId",
                table: "ProjectTags");

            migrationBuilder.CreateIndex(
                name: "IX_UserTags_TagId",
                table: "UserTags",
                column: "TagId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTags_TagId",
                table: "ProjectTags",
                column: "TagId",
                unique: true);
        }
    }
}

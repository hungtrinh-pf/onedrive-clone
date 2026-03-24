using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneDriveClone.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Subfolders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FolderItems_FolderItems_FolderItemId",
                table: "FolderItems");

            migrationBuilder.DropIndex(
                name: "IX_FolderItems_FolderItemId",
                table: "FolderItems");

            migrationBuilder.DropColumn(
                name: "FolderItemId",
                table: "FolderItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FolderItemId",
                table: "FolderItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FolderItems_FolderItemId",
                table: "FolderItems",
                column: "FolderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_FolderItems_FolderItems_FolderItemId",
                table: "FolderItems",
                column: "FolderItemId",
                principalTable: "FolderItems",
                principalColumn: "Id");
        }
    }
}

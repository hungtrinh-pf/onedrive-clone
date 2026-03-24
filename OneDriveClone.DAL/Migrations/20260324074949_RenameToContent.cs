using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneDriveClone.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameToContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "FileItems",
                newName: "Content");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "FileItems",
                newName: "Data");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneDriveClone.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModifyFileModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "FileItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "FileItems");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneDriveClone.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SetParentNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FolderItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FolderItemId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FolderItems_FolderItems_FolderItemId",
                        column: x => x.FolderItemId,
                        principalTable: "FolderItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FolderItems_FolderItems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FolderItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FolderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileItems_FolderItems_FolderId",
                        column: x => x.FolderId,
                        principalTable: "FolderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileItems_FolderId",
                table: "FileItems",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderItems_FolderItemId",
                table: "FolderItems",
                column: "FolderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderItems_ParentId",
                table: "FolderItems",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileItems");

            migrationBuilder.DropTable(
                name: "FolderItems");
        }
    }
}

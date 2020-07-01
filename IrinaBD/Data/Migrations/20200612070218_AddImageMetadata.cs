using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IrinaBD.Data.Migrations
{
    public partial class AddImageMetadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "imageMetadatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OriginalFileName = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imageMetadatas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imageMetadatas");
        }
    }
}

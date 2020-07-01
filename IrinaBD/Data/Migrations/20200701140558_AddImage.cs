using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IrinaBD.Data.Migrations
{
    public partial class AddImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "imageMetadatas",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "imageMetadatas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "imageMetadatas");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "imageMetadatas");
        }
    }
}

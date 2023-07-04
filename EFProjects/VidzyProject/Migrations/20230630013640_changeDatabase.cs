using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidzyProject.Migrations
{
    /// <inheritdoc />
    public partial class changeDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Classification",
                table: "Videos",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Videos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
      table: "Genres",
      columns: new[] { "Id", "Name" },
      values: new object[,]
      {
            { 1, "Action" },
            { 2, "Comedy" },
            { 3, "Drama" }
      });


         

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Videos");

            migrationBuilder.AlterColumn<string>(
                name: "Classification",
                table: "Videos",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}

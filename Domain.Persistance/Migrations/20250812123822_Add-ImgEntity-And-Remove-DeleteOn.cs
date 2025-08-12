using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddImgEntityAndRemoveDeleteOn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "HomeSlides");

            migrationBuilder.DropColumn(
                name: "CategoryImage",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ImgPath",
                table: "HomeSlides",
                newName: "ImgName");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Categories",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ImgName",
                table: "HomeSlides",
                newName: "ImgPath");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "HomeSlides",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "CategoryImage",
                table: "Categories",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Categories",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                column: "DeletedOn",
                value: null);
        }
    }
}

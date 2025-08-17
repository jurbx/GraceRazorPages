using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class DeleteImgEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "HomeSlides");

            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Images",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "HomeSlides",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Categories",
                type: "text",
                nullable: true);
        }
    }
}

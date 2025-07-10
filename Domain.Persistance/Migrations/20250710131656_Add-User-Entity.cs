using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Email", "Name", "PasswordHash", "Role", "UpdatedOn" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), null, null, "grace-testuser@gmail.com", "AdminUser", "�I�=��֑�wT����^�L��6��u�F�]��T�9�N��F��m��E���~��hj\0", 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

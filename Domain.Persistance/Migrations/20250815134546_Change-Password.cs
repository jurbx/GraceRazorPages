using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ChangePassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                column: "Password",
                value: "110f0dd59c92d2487a30958d9f804477dc9a8814f2848d613a88d79b956f1229f97480067786e5e034ac51822c152eeb70f3c0844db5d6313c408c33a2849321");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                column: "Password",
                value: "1b08d60549c43d8ad3151fd69113f57754bbfbfff75e1bc54c829e36e2fb7514d61646be5da1f154ba39dd4edaeb46bdaf6defd21f45fa90ca7edaf0681a6a00");
        }
    }
}

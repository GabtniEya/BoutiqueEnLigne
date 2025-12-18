using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoutiqueEnLigne.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdminHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "MotDePasseHash",
                value: "$2a$11$t/wPvspnjv8dRdnLglwYLucujuYK/yB4kDTlVuFBX8c7TifoPGOxa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "MotDePasseHash",
                value: "$2a$11$8vJ3qXQZY.8XxZ9jC6L5Iu5nHZqGKxFQYXz0PZ7dH5QZdYxZNQqE2");
        }
    }
}

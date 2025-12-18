using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoutiqueEnLigne.Migrations
{
    /// <inheritdoc />
    public partial class AjoutAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotDePasseHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "DateCreation", "Email", "MotDePasseHash", "Nom" },
                values: new object[] { 1, new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(668), "admin@boutique.com", "$2a$11$8vJ3qXQZY.8XxZ9jC6L5Iu5nHZqGKxFQYXz0PZ7dH5QZdYxZNQqE2", "Administrateur" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(623));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(624));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(630));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(618));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(626));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(627));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(628));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(631));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(633));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(634));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(636));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(638));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(640));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5317));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5334));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5329));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5331));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5337));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5339));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5340));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5345));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5352));
        }
    }
}

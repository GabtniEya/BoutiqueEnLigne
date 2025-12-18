using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoutiqueEnLigne.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 17, 0, 49, 159, DateTimeKind.Local).AddTicks(6507));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 17, 0, 49, 159, DateTimeKind.Local).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 17, 0, 49, 159, DateTimeKind.Local).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 17, 0, 49, 159, DateTimeKind.Local).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 17, 0, 49, 159, DateTimeKind.Local).AddTicks(6525));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 16, 33, 24, 256, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 16, 33, 24, 256, DateTimeKind.Local).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 16, 33, 24, 256, DateTimeKind.Local).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 16, 33, 24, 256, DateTimeKind.Local).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 16, 33, 24, 256, DateTimeKind.Local).AddTicks(8651));
        }
    }
}

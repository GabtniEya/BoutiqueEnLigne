using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoutiqueEnLigne.Migrations
{
    /// <inheritdoc />
    public partial class AjoutCodesPromo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodePromoUtilise",
                table: "Commandes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantReduction",
                table: "Commandes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CodesPromo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pourcentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MontantFixe = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actif = table.Column<bool>(type: "bit", nullable: false),
                    UtilisationsMax = table.Column<int>(type: "int", nullable: true),
                    UtilisationsActuelles = table.Column<int>(type: "int", nullable: false),
                    MontantMinimum = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodesPromo", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.InsertData(
                table: "CodesPromo",
                columns: new[] { "Id", "Actif", "Code", "DateDebut", "DateFin", "Description", "MontantFixe", "MontantMinimum", "Pourcentage", "UtilisationsActuelles", "UtilisationsMax" },
                values: new object[,]
                {
                    { 1, true, "BIENVENUE10", new DateTime(2025, 10, 30, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7846), new DateTime(2026, 5, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7850), "10% de réduction pour les nouveaux clients", null, 50m, 10m, 0, 100 },
                    { 2, true, "PROMO5EUR", new DateTime(2025, 11, 14, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7857), new DateTime(2026, 2, 28, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7858), "5€ de réduction", 5.00m, 30m, 0m, 0, 50 },
                    { 3, true, "MEGA20", new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7860), new DateTime(2025, 12, 6, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7860), "20% de réduction - Offre limitée", null, 100m, 20m, 0, 20 }
                });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7603));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7610));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7617));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7613));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7614));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7619));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7620));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7621));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7623));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAjout",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7627));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodesPromo");

            migrationBuilder.DropColumn(
                name: "CodePromoUtilise",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "MontantReduction",
                table: "Commandes");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2025, 11, 29, 14, 11, 23, 653, DateTimeKind.Local).AddTicks(668));

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
    }
}

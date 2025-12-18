using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoutiqueEnLigne.Migrations
{
    /// <inheritdoc />
    public partial class MiseAJourImagesVariees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAjout", "Description" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5317), "Téléphone intelligent dernière génération avec écran OLED 6.5 pouces, 128GB" });

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
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5342), "/images/produits/book1.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5329), "/images/produits/headphones.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5331), "/images/produits/tablet.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5332), "/images/produits/smartwatch.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5337), "/images/produits/shirt.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5339), "/images/produits/dress.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5340), "/images/produits/jacket.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5343), "/images/produits/book2.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5345), "/images/produits/book3.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5346), "/images/produits/magazine.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5347), "/images/produits/lamp.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5349), "/images/produits/pillow.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5350), "/images/produits/kitchen.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 32, 22, 806, DateTimeKind.Local).AddTicks(5352), "/images/produits/carpet.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAjout", "Description" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4323), "Téléphone intelligent dernière génération avec écran OLED 6.5 pouces, 128GB de stockage" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4335));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4341));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAjout",
                value: new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4343));

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4349), "/images/produits/book.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4336), "/images/produits/phone.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4338), "/images/produits/laptop.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4340), "/images/produits/phone.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4344), "/images/produits/tshirt.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4346), "/images/produits/tshirt.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4348), "/images/produits/jeans.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4351), "/images/produits/book.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4353), "/images/produits/book.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4354), "/images/produits/book.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4356), "/images/produits/laptop.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4357), "/images/produits/tshirt.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4359), "/images/produits/laptop.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DateAjout", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4360), "/images/produits/jeans.jpg" });
        }
    }
}

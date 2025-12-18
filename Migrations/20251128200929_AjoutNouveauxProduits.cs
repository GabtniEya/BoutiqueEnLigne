using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoutiqueEnLigne.Migrations
{
    /// <inheritdoc />
    public partial class AjoutNouveauxProduits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAjout", "Description", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4323), "Téléphone intelligent dernière génération avec écran OLED 6.5 pouces, 128GB de stockage", "/images/produits/phone.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAjout", "Description", "ImageUrl", "Nom" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4335), "PC portable performant 15 pouces, Intel i7, 16GB RAM, SSD 512GB", "/images/produits/laptop.jpg", "Ordinateur Portable Pro" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateAjout", "Description", "ImageUrl", "Nom" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4341), "T-shirt 100% coton bio, coupe moderne", "/images/produits/tshirt.jpg", "T-Shirt Coton Premium" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateAjout", "Description", "ImageUrl", "Nom" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4343), "Jean slim confortable en denim stretch", "/images/produits/jeans.jpg", "Jeans Slim Fit" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateAjout", "Description", "ImageUrl", "Nom" },
                values: new object[] { new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4349), "Le meilleur roman de l'année, histoire captivante", "/images/produits/book.jpg", "Roman Bestseller 2024" });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "CategorieId", "DateAjout", "Description", "ImageUrl", "Nom", "NombreVues", "Prix", "Stock" },
                values: new object[,]
                {
                    { 6, 1, new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4336), "Casque sans fil avec réduction de bruit active, autonomie 30h", "/images/produits/phone.jpg", "Casque Audio Bluetooth", 0, 149.99m, 45 },
                    { 7, 1, new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4338), "Tablette Android haute performance, écran Full HD", "/images/produits/laptop.jpg", "Tablette 10 pouces", 0, 299.99m, 40 },
                    { 8, 1, new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4340), "Smartwatch avec suivi santé, GPS, notifications smartphone", "/images/produits/phone.jpg", "Montre Connectée", 0, 199.99m, 60 },
                    { 9, 2, new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4344), "Chemise coton égyptien, coupe cintrée", "/images/produits/tshirt.jpg", "Chemise Homme Élégante", 0, 49.99m, 80 },
                    { 10, 2, new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4346), "Robe légère et élégante, parfaite pour l'été", "/images/produits/tshirt.jpg", "Robe d'Été Femme", 0, 69.99m, 55 },
                    { 11, 2, new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4348), "Veste en cuir véritable, style moderne", "/images/produits/jeans.jpg", "Veste en Cuir", 0, 249.99m, 25 },
                    { 12, 3, new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4351), "Livre complet pour apprendre C# et .NET", "/images/produits/book.jpg", "Guide Programmation C#", 0, 45.99m, 120 },
                    { 13, 3, new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4353), "Saga épique en 3 tomes, monde imaginaire", "/images/produits/book.jpg", "Roman Fantastique", 0, 24.99m, 150 },
                    { 14, 3, new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4354), "Magazine mensuel sur les nouvelles technologies", "/images/produits/book.jpg", "Magazine Tech Monthly", 0, 9.99m, 200 },
                    { 15, 4, new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4356), "Lampe moderne avec intensité réglable", "/images/produits/laptop.jpg", "Lampe de Bureau LED", 0, 39.99m, 70 },
                    { 16, 4, new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4357), "Coussin moelleux en velours, plusieurs couleurs", "/images/produits/tshirt.jpg", "Coussin Décoratif", 0, 24.99m, 100 },
                    { 17, 4, new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4359), "Ensemble d'ustensiles en acier inoxydable", "/images/produits/laptop.jpg", "Set Cuisine 12 Pièces", 0, 89.99m, 35 },
                    { 18, 4, new DateTime(2025, 11, 28, 21, 9, 29, 628, DateTimeKind.Local).AddTicks(4360), "Tapis moderne et confortable", "/images/produits/jeans.jpg", "Tapis Salon 160x230cm", 0, 129.99m, 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAjout", "Description", "ImageUrl" },
                values: new object[] { new DateTime(2025, 11, 28, 17, 0, 49, 159, DateTimeKind.Local).AddTicks(6507), "Téléphone intelligent dernière génération", "/images/phone.jpg" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAjout", "Description", "ImageUrl", "Nom" },
                values: new object[] { new DateTime(2025, 11, 28, 17, 0, 49, 159, DateTimeKind.Local).AddTicks(6520), "PC portable performant", "/images/laptop.jpg", "Ordinateur Portable" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateAjout", "Description", "ImageUrl", "Nom" },
                values: new object[] { new DateTime(2025, 11, 28, 17, 0, 49, 159, DateTimeKind.Local).AddTicks(6521), "T-shirt 100% coton", "/images/tshirt.jpg", "T-Shirt Coton" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateAjout", "Description", "ImageUrl", "Nom" },
                values: new object[] { new DateTime(2025, 11, 28, 17, 0, 49, 159, DateTimeKind.Local).AddTicks(6523), "Jean slim confortable", "/images/jeans.jpg", "Jeans Slim" });

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateAjout", "Description", "ImageUrl", "Nom" },
                values: new object[] { new DateTime(2025, 11, 28, 17, 0, 49, 159, DateTimeKind.Local).AddTicks(6525), "Le meilleur roman de l'année", "/images/book.jpg", "Roman Bestseller" });
        }
    }
}

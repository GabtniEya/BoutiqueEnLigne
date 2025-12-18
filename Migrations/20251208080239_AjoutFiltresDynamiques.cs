using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoutiqueEnLigne.Migrations
{
    /// <inheritdoc />
    public partial class AjoutFiltresDynamiques : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Créer les tables
            migrationBuilder.CreateTable(
                name: "AttributsCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    NomAttribut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeAttribut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValeursDisponibles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributsCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributsCategories_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributsProduits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduitId = table.Column<int>(type: "int", nullable: false),
                    NomAttribut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValeurAttribut = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributsProduits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributsProduits_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // AJOUTER D'ABORD LES CATÉGORIES MANQUANTES (5 et 6)
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Nom", "Description" },
                values: new object[,]
                {
                    { 5, "Chaussures", "Chaussures pour tous" },
                    { 6, "Parfums", "Parfums et fragrances" }
                });

            // AJOUTER LES PRODUITS POUR CES CATÉGORIES
            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "Nom", "Description", "Prix", "Stock", "ImageUrl", "NombreVues", "DateAjout", "CategorieId" },
                values: new object[,]
                {
                    // CHAUSSURES (CategorieId = 5)
                    { 29, "Nike Air Max 270", "Baskets sportives confortables avec amorti Air Max, idéales pour le running", 149.99m, 45, "/images/produits/sneakers.jpg", 0, new DateTime(2025, 12, 8, 9, 2, 38, 102, DateTimeKind.Local), 5 },
                    { 30, "Bottes en Cuir Chelsea", "Bottes élégantes en cuir véritable, parfaites pour l'automne", 179.99m, 30, "/images/produits/boots.jpg", 0, new DateTime(2025, 12, 8, 9, 2, 38, 102, DateTimeKind.Local), 5 },
                    { 31, "Sandales d'Été", "Sandales légères et confortables pour la plage", 39.99m, 60, "/images/produits/sandals.jpg", 0, new DateTime(2025, 12, 8, 9, 2, 38, 102, DateTimeKind.Local), 5 },
                    { 32, "Escarpins Noirs Élégants", "Chaussures à talon pour occasions spéciales", 89.99m, 35, "/images/produits/heels.jpg", 0, new DateTime(2025, 12, 8, 9, 2, 38, 102, DateTimeKind.Local), 5 },
                    { 33, "Baskets Montantes", "Sneakers style urbain avec semelle épaisse", 119.99m, 40, "/images/produits/high-tops.jpg", 0, new DateTime(2025, 12, 8, 9, 2, 38, 102, DateTimeKind.Local), 5 },

                    // PARFUMS (CategorieId = 6)
                    { 34, "Chanel N°5", "Parfum iconique aux notes florales et aldéhydées, intemporel et élégant", 129.99m, 50, "/images/produits/chanel.jpg", 0, new DateTime(2025, 12, 8, 9, 2, 38, 102, DateTimeKind.Local), 6 },
                    { 35, "Dior Sauvage", "Eau de toilette fraîche et épicée pour homme, notes de bergamote et poivre", 89.99m, 65, "/images/produits/sauvage.jpg", 0, new DateTime(2025, 12, 8, 9, 2, 38, 102, DateTimeKind.Local), 6 },
                    { 36, "Black Opium YSL", "Parfum oriental gourmand pour femme, café et vanille", 99.99m, 55, "/images/produits/blackopium.jpg", 0, new DateTime(2025, 12, 8, 9, 2, 38, 102, DateTimeKind.Local), 6 },
                    { 37, "Acqua di Gio", "Eau de toilette fraîche marine pour homme, notes aquatiques", 79.99m, 70, "/images/produits/acqua.jpg", 0, new DateTime(2025, 12, 8, 9, 2, 38, 102, DateTimeKind.Local), 6 },
                    { 38, "La Vie Est Belle", "Eau de parfum florale gourmande, iris et patchouli", 109.99m, 45, "/images/produits/lavieestbelle.jpg", 0, new DateTime(2025, 12, 8, 9, 2, 38, 102, DateTimeKind.Local), 6 }
                });

            // Mettre à jour les dates
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2025, 12, 8, 9, 2, 38, 102, DateTimeKind.Local).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "CodesPromo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2025, 11, 8, 9, 2, 38, 102, DateTimeKind.Local).AddTicks(8915), new DateTime(2026, 6, 8, 9, 2, 38, 102, DateTimeKind.Local).AddTicks(8923) });

            migrationBuilder.UpdateData(
                table: "CodesPromo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2025, 11, 23, 9, 2, 38, 102, DateTimeKind.Local).AddTicks(8945), new DateTime(2026, 3, 8, 9, 2, 38, 102, DateTimeKind.Local).AddTicks(8947) });

            migrationBuilder.UpdateData(
                table: "CodesPromo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2025, 12, 8, 9, 2, 38, 102, DateTimeKind.Local).AddTicks(8954), new DateTime(2025, 12, 15, 9, 2, 38, 102, DateTimeKind.Local).AddTicks(8955) });

            // Mettre à jour les dates des produits existants
            for (int i = 1; i <= 18; i++)
            {
                migrationBuilder.UpdateData(
                    table: "Produits",
                    keyColumn: "Id",
                    keyValue: i,
                    column: "DateAjout",
                    value: new DateTime(2025, 12, 8, 9, 2, 38, 102, DateTimeKind.Local));
            }

            // MAINTENANT INSÉRER LES ATTRIBUTS DE CATÉGORIES (après avoir créé les catégories 5 et 6)
            migrationBuilder.InsertData(
                table: "AttributsCategories",
                columns: new[] { "Id", "CategorieId", "NomAttribut", "TypeAttribut", "ValeursDisponibles" },
                values: new object[,]
                {
                    // VÊTEMENTS (CategorieId = 2)
                    { 1, 2, "Taille", "select", "XS,S,M,L,XL,XXL" },
                    { 2, 2, "Couleur", "select", "Noir,Blanc,Bleu,Rouge,Vert,Gris,Rose,Jaune" },
                    { 3, 2, "Genre", "select", "Homme,Femme,Unisexe" },
                    { 4, 2, "Matière", "select", "Coton,Polyester,Laine,Jean,Cuir,Soie" },

                    // ÉLECTRONIQUE (CategorieId = 1)
                    { 5, 1, "Marque", "select", "Samsung,Apple,Sony,LG,Xiaomi,Huawei,HP,Dell" },
                    { 6, 1, "Stockage", "select", "32GB,64GB,128GB,256GB,512GB,1TB" },
                    { 7, 1, "Couleur", "select", "Noir,Blanc,Bleu,Argent,Or,Rouge" },

                    // LIVRES (CategorieId = 3)
                    { 8, 3, "Format", "select", "Broché,Relié,Poche,Ebook" },
                    { 9, 3, "Langue", "select", "Français,Anglais,Arabe,Espagnol" },
                    { 10, 3, "Genre", "select", "Roman,Science-Fiction,Thriller,Biographie,Technique,Jeunesse" },

                    // MAISON (CategorieId = 4)
                    { 11, 4, "Matériau", "select", "Bois,Métal,Plastique,Verre,Tissu" },
                    { 12, 4, "Couleur", "select", "Blanc,Noir,Beige,Gris,Bleu,Rouge,Vert" },
                    { 13, 4, "Dimensions", "select", "Petit,Moyen,Grand,XL" },

                    // CHAUSSURES (CategorieId = 5)
                    { 14, 5, "Pointure", "select", "35,36,37,38,39,40,41,42,43,44,45,46" },
                    { 15, 5, "Genre", "select", "Homme,Femme,Enfant,Unisexe" },
                    { 16, 5, "Type", "select", "Sneakers,Bottes,Sandales,Escarpins,Mocassins,Baskets,Chaussures de sport" },
                    { 17, 5, "Couleur", "select", "Noir,Blanc,Marron,Bleu,Rouge,Beige,Gris,Rose" },
                    { 18, 5, "Matière", "select", "Cuir,Tissu,Synthétique,Daim,Toile" },

                    // PARFUMS (CategorieId = 6)
                    { 19, 6, "Famille Olfactive", "select", "Floral,Oriental,Boisé,Frais,Fruité,Épicé,Ambré" },
                    { 20, 6, "Genre", "select", "Homme,Femme,Mixte" },
                    { 21, 6, "Concentration", "select", "Eau de Toilette,Eau de Parfum,Parfum,Cologne" },
                    { 22, 6, "Volume", "select", "30ml,50ml,75ml,100ml,150ml" },
                    { 23, 6, "Marque", "select", "Chanel,Dior,Gucci,Yves Saint Laurent,Calvin Klein,Hugo Boss,Paco Rabanne,Armani" },
                    { 24, 6, "Intensité", "select", "Légère,Moyenne,Forte,Très Forte" }
                });

            // INSÉRER LES ATTRIBUTS DE PRODUITS
            migrationBuilder.InsertData(
                table: "AttributsProduits",
                columns: new[] { "Id", "NomAttribut", "ProduitId", "ValeurAttribut" },
                values: new object[,]
                {
                    // T-Shirt (Produit ID 3)
                    { 1, "Taille", 3, "S,M,L,XL" },
                    { 2, "Couleur", 3, "Noir,Blanc,Bleu" },
                    { 3, "Genre", 3, "Unisexe" },
                    { 4, "Matière", 3, "Coton" },

                    // Jeans (Produit ID 4)
                    { 5, "Taille", 4, "30,32,34,36,38,40" },
                    { 6, "Couleur", 4, "Bleu,Noir" },
                    { 7, "Genre", 4, "Homme" },
                    { 8, "Matière", 4, "Jean" },

                    // Smartphone (Produit ID 1)
                    { 9, "Marque", 1, "Samsung" },
                    { 10, "Stockage", 1, "128GB" },
                    { 11, "Couleur", 1, "Noir,Blanc,Bleu" },

                    // Ordinateur (Produit ID 2)
                    { 12, "Marque", 2, "Apple" },
                    { 13, "Stockage", 2, "512GB" },
                    { 14, "Couleur", 2, "Argent,Gris" },

                    // Roman (Produit ID 5)
                    { 15, "Format", 5, "Broché" },
                    { 16, "Langue", 5, "Français" },
                    { 17, "Genre", 5, "Roman" },

                    // Nike Air Max 270 (ID 29)
                    { 18, "Pointure", 29, "39,40,41,42,43,44" },
                    { 19, "Genre", 29, "Unisexe" },
                    { 20, "Type", 29, "Baskets" },
                    { 21, "Couleur", 29, "Noir,Blanc,Bleu" },
                    { 22, "Matière", 29, "Tissu" },

                    // Bottes Chelsea (ID 30)
                    { 23, "Pointure", 30, "40,41,42,43,44,45" },
                    { 24, "Genre", 30, "Homme" },
                    { 25, "Type", 30, "Bottes" },
                    { 26, "Couleur", 30, "Marron,Noir" },
                    { 27, "Matière", 30, "Cuir" },

                    // Sandales (ID 31)
                    { 28, "Pointure", 31, "36,37,38,39,40,41" },
                    { 29, "Genre", 31, "Femme" },
                    { 30, "Type", 31, "Sandales" },
                    { 31, "Couleur", 31, "Beige,Rose,Blanc" },
                    { 32, "Matière", 31, "Synthétique" },

                    // Escarpins (ID 32)
                    { 33, "Pointure", 32, "36,37,38,39,40" },
                    { 34, "Genre", 32, "Femme" },
                    { 35, "Type", 32, "Escarpins" },
                    { 36, "Couleur", 32, "Noir" },
                    { 37, "Matière", 32, "Cuir" },

                    // Baskets Montantes (ID 33)
                    { 38, "Pointure", 33, "38,39,40,41,42,43" },
                    { 39, "Genre", 33, "Unisexe" },
                    { 40, "Type", 33, "Sneakers" },
                    { 41, "Couleur", 33, "Blanc,Noir" },
                    { 42, "Matière", 33, "Toile" },

                    // Chanel N°5 (ID 34)
                    { 43, "Famille Olfactive", 34, "Floral" },
                    { 44, "Genre", 34, "Femme" },
                    { 45, "Concentration", 34, "Eau de Parfum" },
                    { 46, "Volume", 34, "100ml" },
                    { 47, "Marque", 34, "Chanel" },
                    { 48, "Intensité", 34, "Forte" },

                    // Dior Sauvage (ID 35)
                    { 49, "Famille Olfactive", 35, "Frais" },
                    { 50, "Genre", 35, "Homme" },
                    { 51, "Concentration", 35, "Eau de Toilette" },
                    { 52, "Volume", 35, "100ml" },
                    { 53, "Marque", 35, "Dior" },
                    { 54, "Intensité", 35, "Moyenne" },

                    // Black Opium YSL (ID 36)
                    { 55, "Famille Olfactive", 36, "Oriental" },
                    { 56, "Genre", 36, "Femme" },
                    { 57, "Concentration", 36, "Eau de Parfum" },
                    { 58, "Volume", 36, "50ml,90ml" },
                    { 59, "Marque", 36, "Yves Saint Laurent" },
                    { 60, "Intensité", 36, "Très Forte" },

                    // Acqua di Gio (ID 37)
                    { 61, "Famille Olfactive", 37, "Frais" },
                    { 62, "Genre", 37, "Homme" },
                    { 63, "Concentration", 37, "Eau de Toilette" },
                    { 64, "Volume", 37, "75ml,100ml" },
                    { 65, "Marque", 37, "Armani" },
                    { 66, "Intensité", 37, "Légère" },

                    // La Vie Est Belle (ID 38)
                    { 67, "Famille Olfactive", 38, "Floral" },
                    { 68, "Genre", 38, "Femme" },
                    { 69, "Concentration", 38, "Eau de Parfum" },
                    { 70, "Volume", 38, "50ml,100ml" },
                    { 71, "Marque", 38, "Yves Saint Laurent" },
                    { 72, "Intensité", 38, "Forte" }
                });

            // Créer les index
            migrationBuilder.CreateIndex(
                name: "IX_AttributsCategories_CategorieId",
                table: "AttributsCategories",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributsProduits_ProduitId",
                table: "AttributsProduits",
                column: "ProduitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributsCategories");

            migrationBuilder.DropTable(
                name: "AttributsProduits");

            // Supprimer les produits ajoutés
            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValues: new object[] { 29, 30, 31, 32, 33, 34, 35, 36, 37, 38 });

            // Supprimer les catégories ajoutées
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValues: new object[] { 5, 6 });

            // Restaurer les dates précédentes
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "CodesPromo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2025, 10, 30, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7846), new DateTime(2026, 5, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "CodesPromo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2025, 11, 14, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7857), new DateTime(2026, 2, 28, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7858) });

            migrationBuilder.UpdateData(
                table: "CodesPromo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateDebut", "DateFin" },
                values: new object[] { new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7860), new DateTime(2025, 12, 6, 21, 3, 8, 197, DateTimeKind.Local).AddTicks(7860) });

            for (int i = 1; i <= 18; i++)
            {
                migrationBuilder.UpdateData(
                    table: "Produits",
                    keyColumn: "Id",
                    keyValue: i,
                    column: "DateAjout",
                    value: new DateTime(2025, 11, 29, 21, 3, 8, 197, DateTimeKind.Local));
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using BoutiqueEnLigne.Models;

namespace BoutiqueEnLigne.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tables de la base de données
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<PanierItem> PaniersItems { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<LigneCommande> LignesCommande { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CodePromo> CodesPromo { get; set; }
        public DbSet<AttributProduit> AttributsProduits { get; set; }
        public DbSet<AttributCategorie> AttributsCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration des types décimaux
            modelBuilder.Entity<Produit>()
                .Property(p => p.Prix)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Commande>()
                .Property(c => c.MontantTotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<LigneCommande>()
                .Property(l => l.PrixUnitaire)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CodePromo>()
                .Property(c => c.Pourcentage)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<CodePromo>()
                .Property(c => c.MontantFixe)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CodePromo>()
                .Property(c => c.MontantMinimum)
                .HasColumnType("decimal(18,2)");

            // Seed Data - Categories
            modelBuilder.Entity<Categorie>().HasData(
                new Categorie { Id = 1, Nom = "Électronique", Description = "Produits électroniques" },
                new Categorie { Id = 2, Nom = "Vêtements", Description = "Articles vestimentaires" },
                new Categorie { Id = 3, Nom = "Livres", Description = "Livres et magazines" },
                new Categorie { Id = 4, Nom = "Maison", Description = "Articles pour la maison" },
                new Categorie { Id = 5, Nom = "Chaussures", Description = "Chaussures pour tous" },
                new Categorie { Id = 6, Nom = "Parfums", Description = "Parfums et fragrances" }
            );

            // Seed Data - Produits
            var dateAjout = new DateTime(2024, 1, 1, 12, 0, 0);

            modelBuilder.Entity<Produit>().HasData(
                // ÉLECTRONIQUE (5 produits)
                new Produit { Id = 1, Nom = "Smartphone XYZ", Description = "Téléphone intelligent dernière génération avec écran OLED 6.5 pouces, 128GB", Prix = 599.99m, Stock = 50, ImageUrl = "/images/produits/phone.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 1 },
                new Produit { Id = 2, Nom = "Ordinateur Portable Pro", Description = "PC portable performant 15 pouces, Intel i7, 16GB RAM, SSD 512GB", Prix = 1299.99m, Stock = 30, ImageUrl = "/images/produits/laptop.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 1 },
                new Produit { Id = 6, Nom = "Casque Audio Bluetooth", Description = "Casque sans fil avec réduction de bruit active, autonomie 30h", Prix = 149.99m, Stock = 45, ImageUrl = "/images/produits/headphones.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 1 },
                new Produit { Id = 7, Nom = "Tablette 10 pouces", Description = "Tablette Android haute performance, écran Full HD", Prix = 299.99m, Stock = 40, ImageUrl = "/images/produits/tablet.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 1 },
                new Produit { Id = 8, Nom = "Montre Connectée", Description = "Smartwatch avec suivi santé, GPS, notifications smartphone", Prix = 199.99m, Stock = 60, ImageUrl = "/images/produits/smartwatch.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 1 },

                // VÊTEMENTS (5 produits)
                new Produit { Id = 3, Nom = "T-Shirt Coton Premium", Description = "T-shirt 100% coton bio, coupe moderne", Prix = 29.99m, Stock = 100, ImageUrl = "/images/produits/tshirt.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 2 },
                new Produit { Id = 4, Nom = "Jeans Slim Fit", Description = "Jean slim confortable en denim stretch", Prix = 79.99m, Stock = 75, ImageUrl = "/images/produits/jeans.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 2 },
                new Produit { Id = 9, Nom = "Chemise Homme Élégante", Description = "Chemise coton égyptien, coupe cintrée", Prix = 49.99m, Stock = 80, ImageUrl = "/images/produits/shirt.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 2 },
                new Produit { Id = 10, Nom = "Robe d'Été Femme", Description = "Robe légère et élégante, parfaite pour l'été", Prix = 69.99m, Stock = 55, ImageUrl = "/images/produits/dress.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 2 },
                new Produit { Id = 11, Nom = "Veste en Cuir", Description = "Veste en cuir véritable, style moderne", Prix = 249.99m, Stock = 25, ImageUrl = "/images/produits/jacket.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 2 },

                // LIVRES (4 produits)
                new Produit { Id = 5, Nom = "Roman Bestseller 2024", Description = "Le meilleur roman de l'année, histoire captivante", Prix = 19.99m, Stock = 200, ImageUrl = "/images/produits/book1.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 3 },
                new Produit { Id = 12, Nom = "Guide Programmation C#", Description = "Livre complet pour apprendre C# et .NET", Prix = 45.99m, Stock = 120, ImageUrl = "/images/produits/book2.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 3 },
                new Produit { Id = 13, Nom = "Roman Fantastique", Description = "Saga épique en 3 tomes, monde imaginaire", Prix = 24.99m, Stock = 150, ImageUrl = "/images/produits/book3.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 3 },
                new Produit { Id = 14, Nom = "Magazine Tech Monthly", Description = "Magazine mensuel sur les nouvelles technologies", Prix = 9.99m, Stock = 200, ImageUrl = "/images/produits/magazine.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 3 },

                // MAISON (4 produits)
                new Produit { Id = 15, Nom = "Lampe de Bureau LED", Description = "Lampe moderne avec intensité réglable", Prix = 39.99m, Stock = 70, ImageUrl = "/images/produits/lamp.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 4 },
                new Produit { Id = 16, Nom = "Coussin Décoratif", Description = "Coussin moelleux en velours, plusieurs couleurs", Prix = 24.99m, Stock = 100, ImageUrl = "/images/produits/pillow.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 4 },
                new Produit { Id = 17, Nom = "Set Cuisine 12 Pièces", Description = "Ensemble d'ustensiles en acier inoxydable", Prix = 89.99m, Stock = 35, ImageUrl = "/images/produits/kitchen.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 4 },
                new Produit { Id = 18, Nom = "Tapis Salon 160x230cm", Description = "Tapis moderne et confortable", Prix = 129.99m, Stock = 20, ImageUrl = "/images/produits/carpet.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 4 },

                // CHAUSSURES (5 produits)
                new Produit { Id = 29, Nom = "Nike Air Max 270", Description = "Baskets sportives confortables avec amorti Air Max, idéales pour le running", Prix = 149.99m, Stock = 45, ImageUrl = "/images/produits/sneakers.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 5 },
                new Produit { Id = 30, Nom = "Bottes en Cuir Chelsea", Description = "Bottes élégantes en cuir véritable, parfaites pour l'automne", Prix = 179.99m, Stock = 30, ImageUrl = "/images/produits/boots.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 5 },
                new Produit { Id = 31, Nom = "Sandales d'Été", Description = "Sandales légères et confortables pour la plage", Prix = 39.99m, Stock = 60, ImageUrl = "/images/produits/sandals.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 5 },
                new Produit { Id = 32, Nom = "Escarpins Noirs Élégants", Description = "Chaussures à talon pour occasions spéciales", Prix = 89.99m, Stock = 35, ImageUrl = "/images/produits/heels.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 5 },
                new Produit { Id = 33, Nom = "Baskets Montantes", Description = "Sneakers style urbain avec semelle épaisse", Prix = 119.99m, Stock = 40, ImageUrl = "/images/produits/high-tops.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 5 },

                // PARFUMS (5 produits)
                new Produit { Id = 34, Nom = "Chanel N°5", Description = "Parfum iconique aux notes florales et aldéhydées, intemporel et élégant", Prix = 129.99m, Stock = 50, ImageUrl = "/images/produits/chanel.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 6 },
                new Produit { Id = 35, Nom = "Dior Sauvage", Description = "Eau de toilette fraîche et épicée pour homme, notes de bergamote et poivre", Prix = 89.99m, Stock = 65, ImageUrl = "/images/produits/sauvage.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 6 },
                new Produit { Id = 36, Nom = "Black Opium YSL", Description = "Parfum oriental gourmand pour femme, café et vanille", Prix = 99.99m, Stock = 55, ImageUrl = "/images/produits/blackopium.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 6 },
                new Produit { Id = 37, Nom = "Acqua di Gio", Description = "Eau de toilette fraîche marine pour homme, notes aquatiques", Prix = 79.99m, Stock = 70, ImageUrl = "/images/produits/acqua.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 6 },
                new Produit { Id = 38, Nom = "La Vie Est Belle", Description = "Eau de parfum florale gourmande, iris et patchouli", Prix = 109.99m, Stock = 45, ImageUrl = "/images/produits/lavieestbelle.jpg", NombreVues = 0, DateAjout = dateAjout, CategorieId = 6 }
            );

            // Seed Data - Admin par défaut
            var dateCreation = new DateTime(2024, 1, 1, 10, 0, 0);

            modelBuilder.Entity<Admin>().HasData(
    new Admin
    {
        Id = 1,
        Nom = "Administrateur",
        Email = "admin@boutique.com",
        MotDePasseHash = "$2a$11$t/wPvspnjv8dRdnLglwYLucujuYK/yB4kDTlVuFBX8c7TifoPGOxa", // admin123
        DateCreation = dateCreation
    }
);

            // Seed Data - Codes Promo
            var dateDebut1 = new DateTime(2024, 1, 1);
            var dateFin1 = new DateTime(2024, 12, 31);
            var dateDebut2 = new DateTime(2024, 2, 1);
            var dateFin2 = new DateTime(2024, 10, 31);
            var dateDebut3 = new DateTime(2024, 6, 1);
            var dateFin3 = new DateTime(2024, 6, 30);

            modelBuilder.Entity<CodePromo>().HasData(
                new CodePromo
                {
                    Id = 1,
                    Code = "BIENVENUE10",
                    Description = "10% de réduction pour les nouveaux clients",
                    Pourcentage = 10,
                    DateDebut = dateDebut1,
                    DateFin = dateFin1,
                    Actif = true,
                    UtilisationsMax = 100,
                    UtilisationsActuelles = 0,
                    MontantMinimum = 50
                },
                new CodePromo
                {
                    Id = 2,
                    Code = "PROMO5EUR",
                    Description = "5€ de réduction",
                    MontantFixe = 5.00m,
                    DateDebut = dateDebut2,
                    DateFin = dateFin2,
                    Actif = true,
                    UtilisationsMax = 50,
                    UtilisationsActuelles = 0,
                    MontantMinimum = 30
                },
                new CodePromo
                {
                    Id = 3,
                    Code = "MEGA20",
                    Description = "20% de réduction - Offre limitée",
                    Pourcentage = 20,
                    DateDebut = dateDebut3,
                    DateFin = dateFin3,
                    Actif = true,
                    UtilisationsMax = 20,
                    UtilisationsActuelles = 0,
                    MontantMinimum = 100
                }
            );

            // Seed Data - Attributs par Catégorie
            modelBuilder.Entity<AttributCategorie>().HasData(
                // VÊTEMENTS - Attributs
                new AttributCategorie { Id = 1, CategorieId = 2, NomAttribut = "Taille", TypeAttribut = "select", ValeursDisponibles = "XS,S,M,L,XL,XXL" },
                new AttributCategorie { Id = 2, CategorieId = 2, NomAttribut = "Couleur", TypeAttribut = "select", ValeursDisponibles = "Noir,Blanc,Bleu,Rouge,Vert,Gris,Rose,Jaune" },
                new AttributCategorie { Id = 3, CategorieId = 2, NomAttribut = "Genre", TypeAttribut = "select", ValeursDisponibles = "Homme,Femme,Unisexe" },
                new AttributCategorie { Id = 4, CategorieId = 2, NomAttribut = "Matière", TypeAttribut = "select", ValeursDisponibles = "Coton,Polyester,Laine,Jean,Cuir,Soie" },

                // ÉLECTRONIQUE - Attributs
                new AttributCategorie { Id = 5, CategorieId = 1, NomAttribut = "Marque", TypeAttribut = "select", ValeursDisponibles = "Samsung,Apple,Sony,LG,Xiaomi,Huawei,HP,Dell" },
                new AttributCategorie { Id = 6, CategorieId = 1, NomAttribut = "Stockage", TypeAttribut = "select", ValeursDisponibles = "32GB,64GB,128GB,256GB,512GB,1TB" },
                new AttributCategorie { Id = 7, CategorieId = 1, NomAttribut = "Couleur", TypeAttribut = "select", ValeursDisponibles = "Noir,Blanc,Bleu,Argent,Or,Rouge" },

                // LIVRES - Attributs
                new AttributCategorie { Id = 8, CategorieId = 3, NomAttribut = "Format", TypeAttribut = "select", ValeursDisponibles = "Broché,Relié,Poche,Ebook" },
                new AttributCategorie { Id = 9, CategorieId = 3, NomAttribut = "Langue", TypeAttribut = "select", ValeursDisponibles = "Français,Anglais,Arabe,Espagnol" },
                new AttributCategorie { Id = 10, CategorieId = 3, NomAttribut = "Genre", TypeAttribut = "select", ValeursDisponibles = "Roman,Science-Fiction,Thriller,Biographie,Technique,Jeunesse" },

                // MAISON - Attributs
                new AttributCategorie { Id = 11, CategorieId = 4, NomAttribut = "Matériau", TypeAttribut = "select", ValeursDisponibles = "Bois,Métal,Plastique,Verre,Tissu" },
                new AttributCategorie { Id = 12, CategorieId = 4, NomAttribut = "Couleur", TypeAttribut = "select", ValeursDisponibles = "Blanc,Noir,Beige,Gris,Bleu,Rouge,Vert" },
                new AttributCategorie { Id = 13, CategorieId = 4, NomAttribut = "Dimensions", TypeAttribut = "select", ValeursDisponibles = "Petit,Moyen,Grand,XL" },

                // CHAUSSURES - Attributs
                new AttributCategorie { Id = 14, CategorieId = 5, NomAttribut = "Pointure", TypeAttribut = "select", ValeursDisponibles = "35,36,37,38,39,40,41,42,43,44,45,46" },
                new AttributCategorie { Id = 15, CategorieId = 5, NomAttribut = "Genre", TypeAttribut = "select", ValeursDisponibles = "Homme,Femme,Enfant,Unisexe" },
                new AttributCategorie { Id = 16, CategorieId = 5, NomAttribut = "Type", TypeAttribut = "select", ValeursDisponibles = "Sneakers,Bottes,Sandales,Escarpins,Mocassins,Baskets,Chaussures de sport" },
                new AttributCategorie { Id = 17, CategorieId = 5, NomAttribut = "Couleur", TypeAttribut = "select", ValeursDisponibles = "Noir,Blanc,Marron,Bleu,Rouge,Beige,Gris,Rose" },
                new AttributCategorie { Id = 18, CategorieId = 5, NomAttribut = "Matière", TypeAttribut = "select", ValeursDisponibles = "Cuir,Tissu,Synthétique,Daim,Toile" },

                // PARFUMS - Attributs
                new AttributCategorie { Id = 19, CategorieId = 6, NomAttribut = "Famille Olfactive", TypeAttribut = "select", ValeursDisponibles = "Floral,Oriental,Boisé,Frais,Fruité,Épicé,Ambré" },
                new AttributCategorie { Id = 20, CategorieId = 6, NomAttribut = "Genre", TypeAttribut = "select", ValeursDisponibles = "Homme,Femme,Mixte" },
                new AttributCategorie { Id = 21, CategorieId = 6, NomAttribut = "Concentration", TypeAttribut = "select", ValeursDisponibles = "Eau de Toilette,Eau de Parfum,Parfum,Cologne" },
                new AttributCategorie { Id = 22, CategorieId = 6, NomAttribut = "Volume", TypeAttribut = "select", ValeursDisponibles = "30ml,50ml,75ml,100ml,150ml" },
                new AttributCategorie { Id = 23, CategorieId = 6, NomAttribut = "Marque", TypeAttribut = "select", ValeursDisponibles = "Chanel,Dior,Gucci,Yves Saint Laurent,Calvin Klein,Hugo Boss,Paco Rabanne,Armani" },
                new AttributCategorie { Id = 24, CategorieId = 6, NomAttribut = "Intensité", TypeAttribut = "select", ValeursDisponibles = "Légère,Moyenne,Forte,Très Forte" }
            );

            // Seed Data - Attributs des produits
            modelBuilder.Entity<AttributProduit>().HasData(
                // T-Shirt (Produit ID 3)
                new AttributProduit { Id = 1, ProduitId = 3, NomAttribut = "Taille", ValeurAttribut = "S,M,L,XL" },
                new AttributProduit { Id = 2, ProduitId = 3, NomAttribut = "Couleur", ValeurAttribut = "Noir,Blanc,Bleu" },
                new AttributProduit { Id = 3, ProduitId = 3, NomAttribut = "Genre", ValeurAttribut = "Unisexe" },
                new AttributProduit { Id = 4, ProduitId = 3, NomAttribut = "Matière", ValeurAttribut = "Coton" },

                // Jeans (Produit ID 4)
                new AttributProduit { Id = 5, ProduitId = 4, NomAttribut = "Taille", ValeurAttribut = "30,32,34,36,38,40" },
                new AttributProduit { Id = 6, ProduitId = 4, NomAttribut = "Couleur", ValeurAttribut = "Bleu,Noir" },
                new AttributProduit { Id = 7, ProduitId = 4, NomAttribut = "Genre", ValeurAttribut = "Homme" },
                new AttributProduit { Id = 8, ProduitId = 4, NomAttribut = "Matière", ValeurAttribut = "Jean" },

                // Smartphone (Produit ID 1)
                new AttributProduit { Id = 9, ProduitId = 1, NomAttribut = "Marque", ValeurAttribut = "Samsung" },
                new AttributProduit { Id = 10, ProduitId = 1, NomAttribut = "Stockage", ValeurAttribut = "128GB" },
                new AttributProduit { Id = 11, ProduitId = 1, NomAttribut = "Couleur", ValeurAttribut = "Noir,Blanc,Bleu" },

                // Ordinateur (Produit ID 2)
                new AttributProduit { Id = 12, ProduitId = 2, NomAttribut = "Marque", ValeurAttribut = "Apple" },
                new AttributProduit { Id = 13, ProduitId = 2, NomAttribut = "Stockage", ValeurAttribut = "512GB" },
                new AttributProduit { Id = 14, ProduitId = 2, NomAttribut = "Couleur", ValeurAttribut = "Argent,Gris" },

                // Roman (Produit ID 5)
                new AttributProduit { Id = 15, ProduitId = 5, NomAttribut = "Format", ValeurAttribut = "Broché" },
                new AttributProduit { Id = 16, ProduitId = 5, NomAttribut = "Langue", ValeurAttribut = "Français" },
                new AttributProduit { Id = 17, ProduitId = 5, NomAttribut = "Genre", ValeurAttribut = "Roman" },

                // Nike Air Max 270 (ID 29)
                new AttributProduit { Id = 18, ProduitId = 29, NomAttribut = "Pointure", ValeurAttribut = "39,40,41,42,43,44" },
                new AttributProduit { Id = 19, ProduitId = 29, NomAttribut = "Genre", ValeurAttribut = "Unisexe" },
                new AttributProduit { Id = 20, ProduitId = 29, NomAttribut = "Type", ValeurAttribut = "Baskets" },
                new AttributProduit { Id = 21, ProduitId = 29, NomAttribut = "Couleur", ValeurAttribut = "Noir,Blanc,Bleu" },
                new AttributProduit { Id = 22, ProduitId = 29, NomAttribut = "Matière", ValeurAttribut = "Tissu" },

                // Bottes Chelsea (ID 30)
                new AttributProduit { Id = 23, ProduitId = 30, NomAttribut = "Pointure", ValeurAttribut = "40,41,42,43,44,45" },
                new AttributProduit { Id = 24, ProduitId = 30, NomAttribut = "Genre", ValeurAttribut = "Homme" },
                new AttributProduit { Id = 25, ProduitId = 30, NomAttribut = "Type", ValeurAttribut = "Bottes" },
                new AttributProduit { Id = 26, ProduitId = 30, NomAttribut = "Couleur", ValeurAttribut = "Marron,Noir" },
                new AttributProduit { Id = 27, ProduitId = 30, NomAttribut = "Matière", ValeurAttribut = "Cuir" },

                // Sandales (ID 31)
                new AttributProduit { Id = 28, ProduitId = 31, NomAttribut = "Pointure", ValeurAttribut = "36,37,38,39,40,41" },
                new AttributProduit { Id = 29, ProduitId = 31, NomAttribut = "Genre", ValeurAttribut = "Femme" },
                new AttributProduit { Id = 30, ProduitId = 31, NomAttribut = "Type", ValeurAttribut = "Sandales" },
                new AttributProduit { Id = 31, ProduitId = 31, NomAttribut = "Couleur", ValeurAttribut = "Beige,Rose,Blanc" },
                new AttributProduit { Id = 32, ProduitId = 31, NomAttribut = "Matière", ValeurAttribut = "Synthétique" },

                // Escarpins (ID 32)
                new AttributProduit { Id = 33, ProduitId = 32, NomAttribut = "Pointure", ValeurAttribut = "36,37,38,39,40" },
                new AttributProduit { Id = 34, ProduitId = 32, NomAttribut = "Genre", ValeurAttribut = "Femme" },
                new AttributProduit { Id = 35, ProduitId = 32, NomAttribut = "Type", ValeurAttribut = "Escarpins" },
                new AttributProduit { Id = 36, ProduitId = 32, NomAttribut = "Couleur", ValeurAttribut = "Noir" },
                new AttributProduit { Id = 37, ProduitId = 32, NomAttribut = "Matière", ValeurAttribut = "Cuir" },

                // Baskets Montantes (ID 33)
                new AttributProduit { Id = 38, ProduitId = 33, NomAttribut = "Pointure", ValeurAttribut = "38,39,40,41,42,43" },
                new AttributProduit { Id = 39, ProduitId = 33, NomAttribut = "Genre", ValeurAttribut = "Unisexe" },
                new AttributProduit { Id = 40, ProduitId = 33, NomAttribut = "Type", ValeurAttribut = "Sneakers" },
                new AttributProduit { Id = 41, ProduitId = 33, NomAttribut = "Couleur", ValeurAttribut = "Blanc,Noir" },
                new AttributProduit { Id = 42, ProduitId = 33, NomAttribut = "Matière", ValeurAttribut = "Toile" },

                // Chanel N°5 (ID 34)
                new AttributProduit { Id = 43, ProduitId = 34, NomAttribut = "Famille Olfactive", ValeurAttribut = "Floral" },
                new AttributProduit { Id = 44, ProduitId = 34, NomAttribut = "Genre", ValeurAttribut = "Femme" },
                new AttributProduit { Id = 45, ProduitId = 34, NomAttribut = "Concentration", ValeurAttribut = "Eau de Parfum" },
                new AttributProduit { Id = 46, ProduitId = 34, NomAttribut = "Volume", ValeurAttribut = "100ml" },
                new AttributProduit { Id = 47, ProduitId = 34, NomAttribut = "Marque", ValeurAttribut = "Chanel" },
                new AttributProduit { Id = 48, ProduitId = 34, NomAttribut = "Intensité", ValeurAttribut = "Forte" },

                // Dior Sauvage (ID 35)
                new AttributProduit { Id = 49, ProduitId = 35, NomAttribut = "Famille Olfactive", ValeurAttribut = "Frais" },
                new AttributProduit { Id = 50, ProduitId = 35, NomAttribut = "Genre", ValeurAttribut = "Homme" },
                new AttributProduit { Id = 51, ProduitId = 35, NomAttribut = "Concentration", ValeurAttribut = "Eau de Toilette" },
                new AttributProduit { Id = 52, ProduitId = 35, NomAttribut = "Volume", ValeurAttribut = "100ml" },
                new AttributProduit { Id = 53, ProduitId = 35, NomAttribut = "Marque", ValeurAttribut = "Dior" },
                new AttributProduit { Id = 54, ProduitId = 35, NomAttribut = "Intensité", ValeurAttribut = "Moyenne" },

                // Black Opium YSL (ID 36)
                new AttributProduit { Id = 55, ProduitId = 36, NomAttribut = "Famille Olfactive", ValeurAttribut = "Oriental" },
                new AttributProduit { Id = 56, ProduitId = 36, NomAttribut = "Genre", ValeurAttribut = "Femme" },
                new AttributProduit { Id = 57, ProduitId = 36, NomAttribut = "Concentration", ValeurAttribut = "Eau de Parfum" },
                new AttributProduit { Id = 58, ProduitId = 36, NomAttribut = "Volume", ValeurAttribut = "50ml,90ml" },
                new AttributProduit { Id = 59, ProduitId = 36, NomAttribut = "Marque", ValeurAttribut = "Yves Saint Laurent" },
                new AttributProduit { Id = 60, ProduitId = 36, NomAttribut = "Intensité", ValeurAttribut = "Très Forte" },

                // Acqua di Gio (ID 37)
                new AttributProduit { Id = 61, ProduitId = 37, NomAttribut = "Famille Olfactive", ValeurAttribut = "Frais" },
                new AttributProduit { Id = 62, ProduitId = 37, NomAttribut = "Genre", ValeurAttribut = "Homme" },
                new AttributProduit { Id = 63, ProduitId = 37, NomAttribut = "Concentration", ValeurAttribut = "Eau de Toilette" },
                new AttributProduit { Id = 64, ProduitId = 37, NomAttribut = "Volume", ValeurAttribut = "75ml,100ml" },
                new AttributProduit { Id = 65, ProduitId = 37, NomAttribut = "Marque", ValeurAttribut = "Armani" },
                new AttributProduit { Id = 66, ProduitId = 37, NomAttribut = "Intensité", ValeurAttribut = "Légère" },

                // La Vie Est Belle (ID 38)
                new AttributProduit { Id = 67, ProduitId = 38, NomAttribut = "Famille Olfactive", ValeurAttribut = "Floral" },
                new AttributProduit { Id = 68, ProduitId = 38, NomAttribut = "Genre", ValeurAttribut = "Femme" },
                new AttributProduit { Id = 69, ProduitId = 38, NomAttribut = "Concentration", ValeurAttribut = "Eau de Parfum" },
                new AttributProduit { Id = 70, ProduitId = 38, NomAttribut = "Volume", ValeurAttribut = "50ml,100ml" },
                new AttributProduit { Id = 71, ProduitId = 38, NomAttribut = "Marque", ValeurAttribut = "Yves Saint Laurent" },
                new AttributProduit { Id = 72, ProduitId = 38, NomAttribut = "Intensité", ValeurAttribut = "Forte" }
            );
        }
    }
}
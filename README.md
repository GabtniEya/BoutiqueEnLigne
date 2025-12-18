🛍️ BoutiqueEnLigne
Application e-commerce complète développée avec ASP.NET Core MVC.

📋 Prérequis

.NET 7.0 SDK ou supérieur
SQL Server 2019+
Visual Studio 2022 (ou VS Code)


🚀 Installation Rapide
1. Cloner le projet
bashgit clone https://github.com/votre-username/BoutiqueEnLigne.git
cd BoutiqueEnLigne
2. Configurer la base de données
Ouvrez appsettings.json et modifiez la chaîne de connexion :
json{
  "ConnectionStrings": {
    "DefaultConnection": "Server=VOTRE_SERVEUR;Database=BoutiqueEnLigneDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
3. Créer la base de données
bashdotnet ef database update
4. Lancer l'application
bashdotnet run
```

Accédez à : `https://localhost:7077`

---

## 🔑 Identifiants par Défaut

**Administrateur :**
- Email : `admin@boutique.com`
- Mot de passe : `admin123`

---

## ✨ Fonctionnalités

### Espace Client
- ✅ Inscription et connexion
- ✅ Catalogue avec filtres (catégorie, prix, recherche)
- ✅ Panier d'achat
- ✅ Codes promo
- ✅ Historique des commandes

### Espace Admin
- ✅ Dashboard avec statistiques
- ✅ Gestion des produits (CRUD)
- ✅ Gestion des commandes
- ✅ Gestion des codes promo
- ✅ Liste des utilisateurs

---

## 🛠️ Technologies

- **Backend :** ASP.NET Core 7.0 MVC
- **Base de données :** SQL Server + Entity Framework Core
- **Sécurité :** BCrypt (hashing des mots de passe)
- **Frontend :** Bootstrap 5 + Razor Pages

---

## 📁 Structure
```
BoutiqueEnLigne/
├── Controllers/        # Logique métier
├── Models/            # Entités de données
├── ViewModels/        # Modèles pour les vues
├── Views/             # Interfaces utilisateur
├── Data/              # DbContext
├── Helpers/           # Utilitaires
└── wwwroot/           # CSS, JS, Images

🐛 Problèmes Courants
Erreur de connexion à la base de données :

Vérifiez que SQL Server est démarré
Vérifiez la chaîne de connexion dans appsettings.json

Erreur de migration :
bashdotnet ef database drop    # Supprimer la BD
dotnet ef database update  # Recréer

📞 Support
Pour toute question ou problème, ouvrez une issue.

📄 Licence
MIT License - Libre d'utilisation
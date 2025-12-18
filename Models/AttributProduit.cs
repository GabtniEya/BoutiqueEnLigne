namespace BoutiqueEnLigne.Models
{
    // Table principale des attributs
    public class AttributProduit
    {
        public int Id { get; set; }
        public int ProduitId { get; set; }
        public string NomAttribut { get; set; } // Ex: "Taille", "Couleur", "Pointure"
        public string ValeurAttribut { get; set; } // Ex: "M", "Rouge", "42"

        public Produit Produit { get; set; }
    }

    // Définition des attributs possibles par catégorie
    public class AttributCategorie
    {
        public int Id { get; set; }
        public int CategorieId { get; set; }
        public string NomAttribut { get; set; } // Ex: "Taille"
        public string TypeAttribut { get; set; } // Ex: "select", "text", "number"
        public string ValeursDisponibles { get; set; } // Ex: "XS,S,M,L,XL,XXL" (séparées par virgule)

        public Categorie Categorie { get; set; }
    }
}
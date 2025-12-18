namespace BoutiqueEnLigne.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public int NombreVues { get; set; } // Pour la popularité
        public DateTime DateAjout { get; set; }

        // Clé étrangère
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        // Relations
        public ICollection<LigneCommande> LignesCommande { get; set; }
        public ICollection<PanierItem> PaniersItems { get; set; }
        public ICollection<AttributProduit> Attributs { get; set; }
    }
}
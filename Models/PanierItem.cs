namespace BoutiqueEnLigne.Models
{
    public class PanierItem
    {
        public int Id { get; set; }
        public int Quantite { get; set; }

        // Clés étrangères
        public int PanierId { get; set; }
        public Panier Panier { get; set; }

        public int ProduitId { get; set; }
        public Produit Produit { get; set; }
    }
}
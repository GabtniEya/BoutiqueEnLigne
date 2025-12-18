namespace BoutiqueEnLigne.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        // Relations
        public ICollection<Produit> Produits { get; set; }
        public ICollection<AttributCategorie> AttributsDisponibles { get; set; }
    }
}
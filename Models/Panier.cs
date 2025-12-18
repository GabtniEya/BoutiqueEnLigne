namespace BoutiqueEnLigne.Models
{
    public class Panier
    {
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }

        // Clé étrangère
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        // Relations
        public ICollection<PanierItem> Items { get; set; }
    }
}
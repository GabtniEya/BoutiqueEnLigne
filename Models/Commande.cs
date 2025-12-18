namespace BoutiqueEnLigne.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public string NumeroCommande { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal MontantTotal { get; set; }
        public string StatutCommande { get; set; } // En cours, Expédiée, Livrée

        // Informations de livraison
        public string AdresseLivraison { get; set; }
        public string VilleLivraison { get; set; }
        public string CodePostalLivraison { get; set; }
        public string TelephoneLivraison { get; set; }
        // Code promo
        public string? CodePromoUtilise { get; set; }
        public decimal MontantReduction { get; set; }

        // Clé étrangère
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        // Relations
        public ICollection<LigneCommande> LignesCommande { get; set; }
    }
}
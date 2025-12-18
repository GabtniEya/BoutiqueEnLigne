namespace BoutiqueEnLigne.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasseHash { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public DateTime DateInscription { get; set; }

        // Relations
        public ICollection<Commande> Commandes { get; set; }
        public Panier Panier { get; set; }
    }
}
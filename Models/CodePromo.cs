namespace BoutiqueEnLigne.Models
{
    public class CodePromo
    {
        public int Id { get; set; }
        public string Code { get; set; } // Ex: NOEL2024
        public string Description { get; set; }
        public decimal Pourcentage { get; set; } // Ex: 10 pour 10%
        public decimal? MontantFixe { get; set; } // Ex: 5.00 pour 5€ de réduction
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public bool Actif { get; set; }
        public int? UtilisationsMax { get; set; } // Null = illimité
        public int UtilisationsActuelles { get; set; }
        public decimal? MontantMinimum { get; set; } // Montant minimum de commande
    }
}
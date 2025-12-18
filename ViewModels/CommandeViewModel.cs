using System.ComponentModel.DataAnnotations;

namespace BoutiqueEnLigne.ViewModels
{
    public class CommandeViewModel
    {
        [Required(ErrorMessage = "L'adresse est requise")]
        public string AdresseLivraison { get; set; }

        [Required(ErrorMessage = "La ville est requise")]
        public string VilleLivraison { get; set; }

        [Required(ErrorMessage = "Le code postal est requis")]
        public string CodePostalLivraison { get; set; }

        [Required(ErrorMessage = "Le téléphone est requis")]
        public string TelephoneLivraison { get; set; }

        public List<PanierItemViewModel> Items { get; set; }
        public decimal MontantTotal { get; set; }
        public string? CodePromo { get; set; }
        public decimal MontantReduction { get; set; }
        public decimal MontantAvantReduction { get; set; }
    }
}
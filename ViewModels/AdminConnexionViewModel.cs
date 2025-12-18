using System.ComponentModel.DataAnnotations;

namespace BoutiqueEnLigne.ViewModels
{
    public class AdminConnexionViewModel
    {
        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "Email invalide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis")]
        public string MotDePasse { get; set; }
    }
}
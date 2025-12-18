using Microsoft.AspNetCore.Mvc;
using BoutiqueEnLigne.Helpers;

namespace BoutiqueEnLigne.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Hash()
        {
            var motDePasse = "test123";
            var hash1 = PasswordHelper.HashPassword(motDePasse);
            var hash2 = "$2a$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi";

            var test1 = PasswordHelper.VerifyPassword(motDePasse, hash1);
            var test2 = PasswordHelper.VerifyPassword(motDePasse, hash2);

            return Content($@"
                Mot de passe testé : {motDePasse}
                
                Hash généré maintenant : {hash1}
                Vérification hash généré : {test1}
                
                Hash en DB : {hash2}
                Vérification hash DB : {test2}
            ");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using BoutiqueEnLigne.Data;
using BoutiqueEnLigne.Models;
using BoutiqueEnLigne.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BoutiqueEnLigne.Controllers
{
    public class SetupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SetupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Setup/CreateAdmin
        public async Task<IActionResult> CreateAdmin()
        {
            // Supprimer tous les admins existants
            var adminsExistants = await _context.Admins.ToListAsync();
            _context.Admins.RemoveRange(adminsExistants);
            await _context.SaveChangesAsync();

            // Créer un nouvel admin
            string email = "admin@boutique.com";
            string password = "Admin123";

            var hash = PasswordHelper.HashPassword(password);

            var admin = new Admin
            {
                Nom = "Administrateur",
                Email = email,
                MotDePasseHash = hash,
                DateCreation = DateTime.Now
            };

            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            // Vérifier que ça marche
            bool testVerification = PasswordHelper.VerifyPassword(password, hash);

            return Content($@"
✅ Admin créé avec succès !

Email : {email}
Mot de passe : {password}
Hash généré : {hash}
Longueur : {hash.Length}
Test de vérification : {testVerification}

---

Vous pouvez maintenant vous connecter sur /Admin/Connexion

❌ IMPORTANT : Supprimez ce contrôleur SetupController.cs après la création !
            ", "text/plain");
        }
    }
}
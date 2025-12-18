using Microsoft.AspNetCore.Mvc;
using BoutiqueEnLigne.Data;
using BoutiqueEnLigne.Models;
using BoutiqueEnLigne.ViewModels;
using BoutiqueEnLigne.Helpers;
using Microsoft.EntityFrameworkCore;


namespace BoutiqueEnLigne.Controllers
{
    public class CompteController : Controller
    {
        private readonly ApplicationDbContext _context;

        
        

        public CompteController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        // GET: Compte/Inscription
        [HttpGet]
        public IActionResult Inscription()
        {
            return View();
        }

        // POST: Compte/Inscription
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inscription(InscriptionViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Vérifier si l'email existe déjà
                var emailExiste = await _context.Utilisateurs
                    .AnyAsync(u => u.Email == model.Email);

                if (emailExiste)
                {
                    ModelState.AddModelError("Email", "Cet email est déjà utilisé");
                    return View(model);
                }

                // Créer le nouvel utilisateur
                var utilisateur = new Utilisateur
                {
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    Email = model.Email,
                    MotDePasseHash = PasswordHelper.HashPassword(model.MotDePasse),
                    Telephone = model.Telephone,
                    Adresse = model.Adresse,
                    Ville = model.Ville,
                    CodePostal = model.CodePostal,
                    DateInscription = DateTime.Now
                };

                _context.Utilisateurs.Add(utilisateur);
                await _context.SaveChangesAsync();
                // Envoyer l'email de bienvenue
                

                // Créer un panier pour l'utilisateur
                var panier = new Panier
                {
                    UtilisateurId = utilisateur.Id,
                    DateCreation = DateTime.Now
                };

                _context.Paniers.Add(panier);
                await _context.SaveChangesAsync();

                // Connecter automatiquement l'utilisateur
                HttpContext.Session.SetInt32("UtilisateurId", utilisateur.Id);
                HttpContext.Session.SetString("UtilisateurNom", utilisateur.Prenom);

                TempData["Success"] = "Inscription réussie ! Bienvenue " + utilisateur.Prenom;
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        // GET: Compte/Connexion
        [HttpGet]
        public IActionResult Connexion()
        {
            return View();
        }

        // POST: Compte/Connexion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Connexion(ConnexionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var utilisateur = await _context.Utilisateurs
                    .FirstOrDefaultAsync(u => u.Email == model.Email);

                if (utilisateur != null &&
                    PasswordHelper.VerifyPassword(model.MotDePasse, utilisateur.MotDePasseHash))
                {
                    // Connexion réussie
                    HttpContext.Session.SetInt32("UtilisateurId", utilisateur.Id);
                    HttpContext.Session.SetString("UtilisateurNom", utilisateur.Prenom);

                    TempData["Success"] = "Bienvenue " + utilisateur.Prenom + " !";
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Email ou mot de passe incorrect");
            }

            return View(model);
        }

        // GET: Compte/Deconnexion
        public IActionResult Deconnexion()
        {
            HttpContext.Session.Clear();
            TempData["Success"] = "Vous êtes déconnecté";
            return RedirectToAction("Index", "Home");
        }

        // GET: Compte/Profil
        public async Task<IActionResult> Profil()
        {
            var utilisateurId = HttpContext.Session.GetInt32("UtilisateurId");
            if (utilisateurId == null)
            {
                return RedirectToAction("Connexion");
            }

            var utilisateur = await _context.Utilisateurs
                .FindAsync(utilisateurId.Value);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // GET: Compte/MesCommandes
        public async Task<IActionResult> MesCommandes()
        {
            var utilisateurId = HttpContext.Session.GetInt32("UtilisateurId");
            if (utilisateurId == null)
            {
                return RedirectToAction("Connexion");
            }

            var commandes = await _context.Commandes
                .Include(c => c.LignesCommande)
                    .ThenInclude(l => l.Produit)
                .Where(c => c.UtilisateurId == utilisateurId.Value)
                .OrderByDescending(c => c.DateCommande)
                .ToListAsync();

            return View(commandes);
        }
    }
}
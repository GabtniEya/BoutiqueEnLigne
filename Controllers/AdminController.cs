using BoutiqueEnLigne.Data;
using BoutiqueEnLigne.Helpers;
using BoutiqueEnLigne.Models;
using BoutiqueEnLigne.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BoutiqueEnLigne.Controllers
{
    [ServiceFilter(typeof(AdminAuthorizationFilter))]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ========== AUTHENTIFICATION ==========

        [HttpGet]
        public IActionResult Connexion()
        {
            if (HttpContext.Session.GetInt32("AdminId") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Connexion(AdminConnexionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = await _context.Admins
                    .FirstOrDefaultAsync(a => a.Email == model.Email);

                if (admin != null &&
                    PasswordHelper.VerifyPassword(model.MotDePasse, admin.MotDePasseHash))
                {
                    HttpContext.Session.SetInt32("AdminId", admin.Id);
                    HttpContext.Session.SetString("AdminNom", admin.Nom);

                    TempData["Success"] = "Bienvenue " + admin.Nom + " !";
                    return RedirectToAction("Dashboard");
                }

                ModelState.AddModelError("", "Email ou mot de passe incorrect");
            }

            return View(model);
        }

        public async Task<IActionResult> Dashboard()
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null)
            {
                return RedirectToAction("Connexion");
            }

            ViewBag.NombreProduits = await _context.Produits.CountAsync();
            ViewBag.NombreCommandes = await _context.Commandes.CountAsync();
            ViewBag.NombreUtilisateurs = await _context.Utilisateurs.CountAsync();
            ViewBag.ChiffreAffaires = await _context.Commandes.SumAsync(c => (decimal?)c.MontantTotal) ?? 0;

            ViewBag.ProduitsRupture = await _context.Produits.CountAsync(p => p.Stock == 0);
            ViewBag.ProduitsStockFaible = await _context.Produits.CountAsync(p => p.Stock > 0 && p.Stock < 10);

            ViewBag.CommandesEnCours = await _context.Commandes
                .CountAsync(c => c.StatutCommande == "En cours");

            var dernieresCommandes = await _context.Commandes
                .Include(c => c.Utilisateur)
                .OrderByDescending(c => c.DateCommande)
                .Take(5)
                .ToListAsync();
            ViewBag.DernieresCommandes = dernieresCommandes;

            var produitsPopulaires = await _context.LignesCommande
                .Include(l => l.Produit)
                .GroupBy(l => new { l.ProduitId, l.Produit.Nom })
                .Select(g => new
                {
                    ProduitNom = g.Key.Nom,
                    QuantiteVendue = g.Sum(l => l.Quantite)
                })
                .OrderByDescending(x => x.QuantiteVendue)
                .Take(5)
                .ToListAsync();
            ViewBag.ProduitsPopulaires = produitsPopulaires;

            return View();
        }

        public IActionResult Deconnexion()
        {
            HttpContext.Session.Remove("AdminId");
            HttpContext.Session.Remove("AdminNom");
            TempData["Success"] = "Vous êtes déconnecté";
            return RedirectToAction("Connexion");
        }

        // ========== GESTION DES PRODUITS ==========

        public async Task<IActionResult> Produits(string recherche, int? categorieId)
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            var query = _context.Produits.Include(p => p.Categorie).AsQueryable();

            if (!string.IsNullOrEmpty(recherche))
            {
                query = query.Where(p => p.Nom.Contains(recherche) || p.Description.Contains(recherche));
            }

            if (categorieId.HasValue)
            {
                query = query.Where(p => p.CategorieId == categorieId.Value);
            }

            var produits = await query.OrderBy(p => p.Nom).ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

            return View(produits);
        }

        [HttpGet]
        public async Task<IActionResult> AjouterProduit()
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjouterProduit(Produit produit)
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            produit.DateAjout = DateTime.Now;
            produit.NombreVues = 0;

            if (string.IsNullOrWhiteSpace(produit.Nom))
            {
                TempData["Error"] = "Le nom du produit est requis";
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View(produit);
            }

            if (string.IsNullOrWhiteSpace(produit.Description))
            {
                TempData["Error"] = "La description est requise";
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View(produit);
            }

            if (produit.Prix <= 0)
            {
                TempData["Error"] = "Le prix doit être supérieur à 0";
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View(produit);
            }

            if (produit.CategorieId <= 0)
            {
                TempData["Error"] = "Veuillez sélectionner une catégorie";
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View(produit);
            }

            try
            {
                _context.Produits.Add(produit);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Produit ajouté avec succès !";
                return RedirectToAction("Produits");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Erreur lors de l'ajout : " + ex.Message;
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View(produit);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ModifierProduit(int id)
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
            {
                TempData["Error"] = "Produit introuvable";
                return RedirectToAction("Produits");
            }

            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(produit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifierProduit(Produit produit)
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            var produitExistant = await _context.Produits.FindAsync(produit.Id);
            if (produitExistant == null)
            {
                TempData["Error"] = "Produit introuvable";
                return RedirectToAction("Produits");
            }

            produitExistant.Nom = produit.Nom;
            produitExistant.Description = produit.Description;
            produitExistant.Prix = produit.Prix;
            produitExistant.Stock = produit.Stock;
            produitExistant.CategorieId = produit.CategorieId;
            produitExistant.ImageUrl = produit.ImageUrl;

            try
            {
                await _context.SaveChangesAsync();
                TempData["Success"] = "Produit modifié avec succès !";
                return RedirectToAction("Produits");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Erreur lors de la modification : " + ex.Message;
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View(produit);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SupprimerProduit(int id)
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            var produit = await _context.Produits.FindAsync(id);
            if (produit != null)
            {
                var aDesCommandes = await _context.LignesCommande.AnyAsync(l => l.ProduitId == id);

                if (aDesCommandes)
                {
                    TempData["Error"] = "Impossible de supprimer ce produit car il a des commandes associées";
                }
                else
                {
                    _context.Produits.Remove(produit);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Produit supprimé avec succès !";
                }
            }
            else
            {
                TempData["Error"] = "Produit introuvable";
            }

            return RedirectToAction("Produits");
        }

        // ========== GESTION DES COMMANDES ==========

        public async Task<IActionResult> Commandes(string statut, string recherche)
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            var query = _context.Commandes
                .Include(c => c.Utilisateur)
                .Include(c => c.LignesCommande)
                    .ThenInclude(l => l.Produit)
                .AsQueryable();

            if (!string.IsNullOrEmpty(statut))
            {
                query = query.Where(c => c.StatutCommande == statut);
            }

            if (!string.IsNullOrEmpty(recherche))
            {
                query = query.Where(c => c.NumeroCommande.Contains(recherche) ||
                                        c.Utilisateur.Nom.Contains(recherche) ||
                                        c.Utilisateur.Prenom.Contains(recherche));
            }

            var commandes = await query.OrderByDescending(c => c.DateCommande).ToListAsync();

            return View(commandes);
        }

        public async Task<IActionResult> DetailsCommande(int id)
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            var commande = await _context.Commandes
                .Include(c => c.Utilisateur)
                .Include(c => c.LignesCommande)
                    .ThenInclude(l => l.Produit)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (commande == null)
            {
                TempData["Error"] = "Commande introuvable";
                return RedirectToAction("Commandes");
            }

            return View(commande);
        }

        [HttpPost]
        public async Task<IActionResult> ChangerStatutCommande(int id, string statut)
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            var commande = await _context.Commandes.FindAsync(id);
            if (commande != null)
            {
                commande.StatutCommande = statut;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Statut de la commande modifié avec succès !";
            }
            else
            {
                TempData["Error"] = "Commande introuvable";
            }

            return RedirectToAction("DetailsCommande", new { id });
        }

        // ========== GESTION DES UTILISATEURS ==========

        public async Task<IActionResult> Utilisateurs(string recherche)
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            var query = _context.Utilisateurs
                .Include(u => u.Commandes)
                .AsQueryable();

            if (!string.IsNullOrEmpty(recherche))
            {
                query = query.Where(u => u.Nom.Contains(recherche) ||
                                        u.Prenom.Contains(recherche) ||
                                        u.Email.Contains(recherche));
            }

            var utilisateurs = await query.OrderBy(u => u.Nom).ToListAsync();

            return View(utilisateurs);
        }

        public async Task<IActionResult> DetailsUtilisateur(int id)
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            var utilisateur = await _context.Utilisateurs
                .Include(u => u.Commandes)
                    .ThenInclude(c => c.LignesCommande)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (utilisateur == null)
            {
                TempData["Error"] = "Utilisateur introuvable";
                return RedirectToAction("Utilisateurs");
            }

            return View(utilisateur);
        }

        // ========== GESTION DES CATÉGORIES ==========

        public async Task<IActionResult> Categories()
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            var categories = await _context.Categories
                .Include(c => c.Produits)
                .ToListAsync();

            return View(categories);
        }

        // ========== GESTION DES CODES PROMO ==========

        public async Task<IActionResult> CodesPromo()
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            var codes = await _context.CodesPromo
                .OrderByDescending(c => c.DateDebut)
                .ToListAsync();

            return View(codes);
        }

        [HttpGet]
        public IActionResult AjouterCodePromo()
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjouterCodePromo(CodePromo codePromo)
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            var codeExiste = await _context.CodesPromo.AnyAsync(c => c.Code == codePromo.Code.ToUpper());
            if (codeExiste)
            {
                ModelState.AddModelError("Code", "Ce code promo existe déjà");
                return View(codePromo);
            }

            codePromo.Code = codePromo.Code.ToUpper();
            codePromo.UtilisationsActuelles = 0;

            _context.CodesPromo.Add(codePromo);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Code promo créé avec succès !";
            return RedirectToAction("CodesPromo");
        }

        [HttpPost]
        public async Task<IActionResult> DesactiverCodePromo(int id)
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");
            if (adminId == null) return RedirectToAction("Connexion");

            var code = await _context.CodesPromo.FindAsync(id);
            if (code != null)
            {
                code.Actif = !code.Actif;
                await _context.SaveChangesAsync();
                TempData["Success"] = code.Actif ? "Code promo activé" : "Code promo désactivé";
            }

            return RedirectToAction("CodesPromo");
        }
    
    [HttpGet]
        public IActionResult TestBCrypt()
        {
            try
            {
                // Test 1 : Vérifier que BCrypt fonctionne
                string testPassword = "admin123";
                string testHash = BCrypt.Net.BCrypt.HashPassword(testPassword, 11);
                bool testVerify = BCrypt.Net.BCrypt.Verify(testPassword, testHash);

                // Test 2 : Le hash actuel de votre BD
                string hashFromDB = "$2a$11$8vJ3qXQZY.8XxZ9jC6L5Iu5nHZqGKxFQYXz0PZ7dH5QZdYxZNQqE2";

                var result = $@"
<!DOCTYPE html>
<html>
<head>
    <title>Test BCrypt</title>
    <style>
        body {{ font-family: Arial; margin: 40px; }}
        h2 {{ color: #333; }}
        .success {{ color: green; }}
        .error {{ color: red; }}
        code {{ background: #f4f4f4; padding: 2px 6px; border-radius: 3px; }}
    </style>
</head>
<body>
    <h2>🔐 Test BCrypt</h2>
    <p><strong>BCrypt fonctionne :</strong> <span class='{(testVerify ? "success" : "error")}'>{(testVerify ? "✅ OUI" : "❌ NON")}</span></p>
    <p><strong>Hash généré pour 'admin123' :</strong><br/><code>{testHash}</code></p>
    
    <hr/>
    <h3>📋 Test avec différents mots de passe sur le hash de la BD :</h3>
    <ul>
        <li>Mot de passe '<strong>admin</strong>' : <span class='{(BCrypt.Net.BCrypt.Verify("admin", hashFromDB) ? "success" : "error")}'>{(BCrypt.Net.BCrypt.Verify("admin", hashFromDB) ? "✅ VALIDE" : "❌ Invalide")}</span></li>
        <li>Mot de passe '<strong>admin123</strong>' : <span class='{(BCrypt.Net.BCrypt.Verify("admin123", hashFromDB) ? "success" : "error")}'>{(BCrypt.Net.BCrypt.Verify("admin123", hashFromDB) ? "✅ VALIDE" : "❌ Invalide")}</span></li>
        <li>Mot de passe '<strong>Admin123</strong>' : <span class='{(BCrypt.Net.BCrypt.Verify("Admin123", hashFromDB) ? "success" : "error")}'>{(BCrypt.Net.BCrypt.Verify("Admin123", hashFromDB) ? "✅ VALIDE" : "❌ Invalide")}</span></li>
        <li>Mot de passe '<strong>password</strong>' : <span class='{(BCrypt.Net.BCrypt.Verify("password", hashFromDB) ? "success" : "error")}'>{(BCrypt.Net.BCrypt.Verify("password", hashFromDB) ? "✅ VALIDE" : "❌ Invalide")}</span></li>
        <li>Mot de passe '<strong>boutique</strong>' : <span class='{(BCrypt.Net.BCrypt.Verify("boutique", hashFromDB) ? "success" : "error")}'>{(BCrypt.Net.BCrypt.Verify("boutique", hashFromDB) ? "✅ VALIDE" : "❌ Invalide")}</span></li>
    </ul>
    
    <hr/>
    <h3>💾 Données de la BD :</h3>
";

                // Test 3 : Lire depuis la BD
                var admin = _context.Admins.FirstOrDefault(a => a.Email == "admin@boutique.com");
                if (admin != null)
                {
                    result += $@"
        <p><strong>Email :</strong> {admin.Email}</p>
        <p><strong>Nom :</strong> {admin.Nom}</p>
        <p><strong>Hash en BD :</strong><br/><code>{admin.MotDePasseHash}</code></p>
        <p><strong>Longueur du hash :</strong> {admin.MotDePasseHash.Length} caractères</p>
        <p><strong>Hash identique au hash seed ?</strong> <span class='{(admin.MotDePasseHash == hashFromDB ? "success" : "error")}'>{(admin.MotDePasseHash == hashFromDB ? "✅ OUI" : "❌ NON")}</span></p>
        
        <hr/>
        <h3>🔧 Action recommandée :</h3>
        <p>Exécutez cette requête SQL pour mettre à jour avec un nouveau hash :</p>
        <pre style='background: #f4f4f4; padding: 15px; border-radius: 5px;'>
UPDATE Admins 
SET MotDePasseHash = '{testHash}'
WHERE Email = 'admin@boutique.com';
        </pre>
        <p>Puis connectez-vous avec : <strong>admin@boutique.com</strong> / <strong>admin123</strong></p>
";
                }
                else
                {
                    result += "<p class='error'>❌ Aucun admin trouvé dans la BD avec l'email 'admin@boutique.com'</p>";
                }

                result += @"
</body>
</html>";

                return Content(result, "text/html");
            }
            catch (Exception ex)
            {
                return Content($@"
<!DOCTYPE html>
<html>
<body style='font-family: Arial; margin: 40px;'>
    <h2 style='color: red;'>❌ ERREUR</h2>
    <p><strong>Message :</strong> {ex.Message}</p>
    <pre style='background: #f4f4f4; padding: 15px;'>{ex.StackTrace}</pre>
</body>
</html>", "text/html");
            }
        }

    } }
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoutiqueEnLigne.Data;
using BoutiqueEnLigne.Models;
using BoutiqueEnLigne.ViewModels;

namespace BoutiqueEnLigne.Controllers
{
    public class CommandesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommandesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Commandes/Validation
        public async Task<IActionResult> Validation()
        {
            var utilisateurId = HttpContext.Session.GetInt32("UtilisateurId");
            if (utilisateurId == null)
            {
                TempData["Error"] = "Veuillez vous connecter";
                return RedirectToAction("Connexion", "Compte");
            }

            var utilisateur = await _context.Utilisateurs.FindAsync(utilisateurId.Value);
            if (utilisateur == null)
            {
                TempData["Error"] = "Utilisateur introuvable";
                return RedirectToAction("Connexion", "Compte");
            }

            var panier = await _context.Paniers
                .Include(p => p.Items)
                    .ThenInclude(i => i.Produit)
                .FirstOrDefaultAsync(p => p.UtilisateurId == utilisateurId.Value);

            if (panier == null || !panier.Items.Any())
            {
                TempData["Error"] = "Votre panier est vide";
                return RedirectToAction("Index", "Panier");
            }

            var codePromoSession = HttpContext.Session.GetString("CodePromoApplique");
            var reductionSession = HttpContext.Session.GetString("MontantReduction");

            decimal montantReduction = 0;
            if (!string.IsNullOrEmpty(reductionSession))
            {
                decimal.TryParse(reductionSession, out montantReduction);
            }

            var montantAvantReduction = panier.Items.Sum(i => i.Produit.Prix * i.Quantite);

            var viewModel = new CommandeViewModel
            {
                AdresseLivraison = utilisateur.Adresse ?? "",
                VilleLivraison = utilisateur.Ville ?? "",
                CodePostalLivraison = utilisateur.CodePostal ?? "",
                TelephoneLivraison = utilisateur.Telephone ?? "",
                Items = panier.Items.Select(i => new PanierItemViewModel
                {
                    ProduitId = i.ProduitId,
                    NomProduit = i.Produit.Nom,
                    Prix = i.Produit.Prix,
                    Quantite = i.Quantite,
                    SousTotal = i.Produit.Prix * i.Quantite,
                    ImageUrl = i.Produit.ImageUrl
                }).ToList(),
                MontantAvantReduction = montantAvantReduction,
                MontantReduction = montantReduction,
                MontantTotal = montantAvantReduction - montantReduction,
                CodePromo = codePromoSession
            };

            return View(viewModel);
        }

        // POST: Commandes/AppliquerCodePromo
        [HttpPost]
        public async Task<IActionResult> AppliquerCodePromo(string codePromo)
        {
            var utilisateurId = HttpContext.Session.GetInt32("UtilisateurId");
            if (utilisateurId == null)
            {
                return Json(new { success = false, message = "Veuillez vous connecter" });
            }

            var utilisateur = await _context.Utilisateurs.FindAsync(utilisateurId.Value);
            if (utilisateur == null)
            {
                return Json(new { success = false, message = "Utilisateur introuvable" });
            }

            var panier = await _context.Paniers
                .Include(p => p.Items)
                    .ThenInclude(i => i.Produit)
                .FirstOrDefaultAsync(p => p.UtilisateurId == utilisateurId.Value);

            if (panier == null || !panier.Items.Any())
            {
                return Json(new { success = false, message = "Votre panier est vide" });
            }

            var montantAvantReduction = panier.Items.Sum(i => i.Produit.Prix * i.Quantite);
            var codePromoSession = HttpContext.Session.GetString("CodePromoApplique");
            var reductionSession = HttpContext.Session.GetString("MontantReduction");

            decimal montantReduction = 0;
            if (!string.IsNullOrEmpty(reductionSession))
            {
                decimal.TryParse(reductionSession, out montantReduction);
            }

            // Vérifier le code promo
            var code = await _context.CodesPromo
                .FirstOrDefaultAsync(c => c.Code == codePromo.ToUpper() && c.Actif);

            if (code == null)
            {
                return Json(new { success = false, message = "Code promo invalide" });
            }

            // Vérifier la date
            if (DateTime.Now < code.DateDebut || DateTime.Now > code.DateFin)
            {
                return Json(new { success = false, message = "Code promo expiré" });
            }

            // Vérifier les utilisations
            if (code.UtilisationsMax.HasValue && code.UtilisationsActuelles >= code.UtilisationsMax.Value)
            {
                return Json(new { success = false, message = "Code promo épuisé" });
            }

            var montantTotal = montantAvantReduction - montantReduction;

            // Vérifier le montant minimum
            if (code.MontantMinimum.HasValue && montantTotal < code.MontantMinimum.Value)
            {
                return Json(new
                {
                    success = false,
                    message = $"Montant minimum de {code.MontantMinimum.Value:C} requis"
                });
            }

            // Calculer la réduction
            decimal reduction = 0;
            if (code.Pourcentage > 0)
            {
                reduction = montantTotal * (code.Pourcentage / 100);
            }
            else if (code.MontantFixe.HasValue)
            {
                reduction = code.MontantFixe.Value;
            }

            // Ne pas dépasser le montant total
            if (reduction > montantTotal)
            {
                reduction = montantTotal;
            }

            var nouveauTotal = montantTotal - reduction;

            // Stocker en session
            HttpContext.Session.SetString("CodePromoApplique", codePromo.ToUpper());
            HttpContext.Session.SetString("MontantReduction", reduction.ToString());

            return Json(new
            {
                success = true,
                message = $"Code promo appliqué ! Réduction de {reduction:C}",
                reduction = reduction,
                nouveauTotal = nouveauTotal,
                montantAvantReduction = montantTotal
            });
        }

        // POST: Commandes/SupprimerCodePromo
        [HttpPost]
        public IActionResult SupprimerCodePromo()
        {
            HttpContext.Session.Remove("CodePromoApplique");
            HttpContext.Session.Remove("MontantReduction");

            return Json(new { success = true, message = "Code promo retiré" });
        }

        // POST: Commandes/Confirmer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirmer(CommandeViewModel model)
        {
            var utilisateurId = HttpContext.Session.GetInt32("UtilisateurId");
            if (utilisateurId == null)
            {
                TempData["Error"] = "Veuillez vous connecter";
                return RedirectToAction("Connexion", "Compte");
            }

            var panierUtilisateur = await _context.Paniers
                .Include(p => p.Items)
                    .ThenInclude(i => i.Produit)
                .FirstOrDefaultAsync(p => p.UtilisateurId == utilisateurId.Value);

            if (panierUtilisateur == null || !panierUtilisateur.Items.Any())
            {
                TempData["Error"] = "Votre panier est vide";
                return RedirectToAction("Index", "Panier");
            }

            // Vérifier le stock AVANT de créer la commande
            foreach (var item in panierUtilisateur.Items)
            {
                var produit = await _context.Produits.FindAsync(item.ProduitId);
                if (produit == null || produit.Stock < item.Quantite)
                {
                    TempData["Error"] = $"Stock insuffisant pour {item.Produit.Nom}";
                    return RedirectToAction("Validation");
                }
            }

            // Créer la commande
            var numeroCommande = "CMD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            var codePromoSession = HttpContext.Session.GetString("CodePromoApplique");
            var reductionSession = HttpContext.Session.GetString("MontantReduction");

            decimal montantReduction = 0;
            if (!string.IsNullOrEmpty(reductionSession))
            {
                decimal.TryParse(reductionSession, out montantReduction);
            }

            var montantAvantReduction = panierUtilisateur.Items.Sum(i => i.Produit.Prix * i.Quantite);

            var commande = new Commande
            {
                NumeroCommande = numeroCommande,
                DateCommande = DateTime.Now,
                MontantTotal = montantAvantReduction - montantReduction,
                CodePromoUtilise = codePromoSession,
                MontantReduction = montantReduction,
                UtilisateurId = utilisateurId.Value,
                AdresseLivraison = model.AdresseLivraison,
                VilleLivraison = model.VilleLivraison,
                CodePostalLivraison = model.CodePostalLivraison,
                TelephoneLivraison = model.TelephoneLivraison,
                StatutCommande = "En cours"
            };

            _context.Commandes.Add(commande);
            await _context.SaveChangesAsync();

            // Créer les lignes de commande et mettre à jour le stock
            foreach (var item in panierUtilisateur.Items)
            {
                var ligneCommande = new LigneCommande
                {
                    CommandeId = commande.Id,
                    ProduitId = item.ProduitId,
                    Quantite = item.Quantite,
                    PrixUnitaire = item.Produit.Prix
                };
                _context.LignesCommande.Add(ligneCommande);

                var produit = await _context.Produits.FindAsync(item.ProduitId);
                if (produit != null)
                {
                    produit.Stock -= item.Quantite;
                }
            }

            await _context.SaveChangesAsync();

            // Incrémenter l'utilisation du code promo
            if (!string.IsNullOrEmpty(codePromoSession))
            {
                var codePromo = await _context.CodesPromo
                    .FirstOrDefaultAsync(c => c.Code == codePromoSession);
                if (codePromo != null)
                {
                    codePromo.UtilisationsActuelles++;
                    await _context.SaveChangesAsync();
                }

                HttpContext.Session.Remove("CodePromoApplique");
                HttpContext.Session.Remove("MontantReduction");
            }

            // Vider le panier
            _context.PaniersItems.RemoveRange(panierUtilisateur.Items);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Commande confirmée avec succès !";
            return RedirectToAction("Confirmation", new { id = commande.Id });
        }

        // GET: Commandes/Confirmation/5
        public async Task<IActionResult> Confirmation(int id)
        {
            var utilisateurId = HttpContext.Session.GetInt32("UtilisateurId");
            if (utilisateurId == null)
            {
                TempData["Error"] = "Veuillez vous connecter";
                return RedirectToAction("Connexion", "Compte");
            }

            var commande = await _context.Commandes
                .Include(c => c.LignesCommande)
                    .ThenInclude(l => l.Produit)
                .FirstOrDefaultAsync(c => c.Id == id && c.UtilisateurId == utilisateurId.Value);

            if (commande == null)
            {
                TempData["Error"] = "Commande introuvable";
                return RedirectToAction("Index", "Home");
            }

            return View(commande);
        }
    }
}
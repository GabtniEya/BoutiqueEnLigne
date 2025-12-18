using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoutiqueEnLigne.Data;
using BoutiqueEnLigne.Models;
using BoutiqueEnLigne.ViewModels;

namespace BoutiqueEnLigne.Controllers
{
    public class PanierController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PanierController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Panier
        public async Task<IActionResult> Index()
        {
            var utilisateurId = HttpContext.Session.GetInt32("UtilisateurId");
            if (utilisateurId == null)
            {
                TempData["Error"] = "Veuillez vous connecter pour voir votre panier";
                return RedirectToAction("Connexion", "Compte");
            }

            var panier = await _context.Paniers
                .Include(p => p.Items)
                    .ThenInclude(i => i.Produit)
                .FirstOrDefaultAsync(p => p.UtilisateurId == utilisateurId.Value);

            if (panier == null || !panier.Items.Any())
            {
                return View(new PanierViewModel { Items = new List<PanierItemViewModel>(), Total = 0 });
            }

            var viewModel = new PanierViewModel
            {
                Items = panier.Items.Select(i => new PanierItemViewModel
                {
                    ProduitId = i.ProduitId,
                    NomProduit = i.Produit.Nom,
                    Prix = i.Produit.Prix,
                    Quantite = i.Quantite,
                    SousTotal = i.Produit.Prix * i.Quantite,
                    ImageUrl = i.Produit.ImageUrl
                }).ToList(),
                Total = panier.Items.Sum(i => i.Produit.Prix * i.Quantite)
            };

            return View(viewModel);
        }

        // POST: Panier/Ajouter
        [HttpPost]
        public async Task<IActionResult> Ajouter(int produitId, int quantite = 1)
        {
            var utilisateurId = HttpContext.Session.GetInt32("UtilisateurId");
            if (utilisateurId == null)
            {
                TempData["Error"] = "Veuillez vous connecter pour ajouter au panier";
                return RedirectToAction("Connexion", "Compte");
            }

            var produit = await _context.Produits.FindAsync(produitId);
            if (produit == null)
            {
                return NotFound();
            }

            if (produit.Stock < quantite)
            {
                TempData["Error"] = "Stock insuffisant";
                return RedirectToAction("Details", "Produits", new { id = produitId });
            }

            var panier = await _context.Paniers
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.UtilisateurId == utilisateurId.Value);

            if (panier == null)
            {
                panier = new Panier
                {
                    UtilisateurId = utilisateurId.Value,
                    DateCreation = DateTime.Now
                };
                _context.Paniers.Add(panier);
                await _context.SaveChangesAsync();
            }

            var itemExistant = panier.Items.FirstOrDefault(i => i.ProduitId == produitId);

            if (itemExistant != null)
            {
                itemExistant.Quantite += quantite;
            }
            else
            {
                var nouvelItem = new PanierItem
                {
                    PanierId = panier.Id,
                    ProduitId = produitId,
                    Quantite = quantite
                };
                _context.PaniersItems.Add(nouvelItem);
            }

            await _context.SaveChangesAsync();
            TempData["Success"] = "Produit ajouté au panier";
            return RedirectToAction("Index");
        }

        // POST: Panier/Modifier
        [HttpPost]
        public async Task<IActionResult> Modifier(int produitId, int quantite)
        {
            var utilisateurId = HttpContext.Session.GetInt32("UtilisateurId");
            if (utilisateurId == null)
            {
                return RedirectToAction("Connexion", "Compte");
            }

            var panier = await _context.Paniers
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.UtilisateurId == utilisateurId.Value);

            if (panier == null)
            {
                return NotFound();
            }

            var item = panier.Items.FirstOrDefault(i => i.ProduitId == produitId);
            if (item == null)
            {
                return NotFound();
            }

            if (quantite <= 0)
            {
                _context.PaniersItems.Remove(item);
            }
            else
            {
                item.Quantite = quantite;
            }

            await _context.SaveChangesAsync();
            TempData["Success"] = "Panier mis à jour";
            return RedirectToAction("Index");
        }

        // POST: Panier/Supprimer
        [HttpPost]
        public async Task<IActionResult> Supprimer(int produitId)
        {
            var utilisateurId = HttpContext.Session.GetInt32("UtilisateurId");
            if (utilisateurId == null)
            {
                return RedirectToAction("Connexion", "Compte");
            }

            var panier = await _context.Paniers
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.UtilisateurId == utilisateurId.Value);

            if (panier == null)
            {
                return NotFound();
            }

            var item = panier.Items.FirstOrDefault(i => i.ProduitId == produitId);
            if (item != null)
            {
                _context.PaniersItems.Remove(item);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Produit retiré du panier";
            }

            return RedirectToAction("Index");
        }
    }
}
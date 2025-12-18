using BoutiqueEnLigne.Data;
using BoutiqueEnLigne.Models;
using BoutiqueEnLigne.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoutiqueEnLigne.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const int PRODUITS_PAR_PAGE = 9;

        public ProduitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produits
        // GET: Produits
        public async Task<IActionResult> Index(
            int? categorieId,
            string recherche,
            string triPar,
            decimal? prixMin,
            decimal? prixMax,
            int page = 1)
        {
            var query = _context.Produits
                .Include(p => p.Categorie)
                .Include(p => p.Attributs)
                .AsQueryable();

            // Filtre par catégorie
            if (categorieId.HasValue)
            {
                query = query.Where(p => p.CategorieId == categorieId.Value);
            }

            // Filtre par recherche
            if (!string.IsNullOrEmpty(recherche))
            {
                query = query.Where(p => p.Nom.Contains(recherche) ||
                                        p.Description.Contains(recherche));
            }

            // Filtre par prix
            if (prixMin.HasValue)
            {
                query = query.Where(p => p.Prix >= prixMin.Value);
            }
            if (prixMax.HasValue)
            {
                query = query.Where(p => p.Prix <= prixMax.Value);
            }

            // Filtres dynamiques par attributs (ex: taille, couleur, etc.)
            var filtresAppliques = new Dictionary<string, string>();
            foreach (var key in Request.Query.Keys)
            {
                if (key.StartsWith("attr_"))
                {
                    var nomAttribut = key.Substring(5); // Enlever "attr_"
                    var valeur = Request.Query[key].ToString();

                    if (!string.IsNullOrEmpty(valeur))
                    {
                        filtresAppliques[nomAttribut] = valeur;

                        // Filtrer les produits qui ont cet attribut avec cette valeur
                        query = query.Where(p => p.Attributs.Any(a =>
                            a.NomAttribut == nomAttribut &&
                            a.ValeurAttribut.Contains(valeur)));
                    }
                }
            }

            // Tri
            query = triPar switch
            {
                "prix_asc" => query.OrderBy(p => p.Prix),
                "prix_desc" => query.OrderByDescending(p => p.Prix),
                "popularite" => query.OrderByDescending(p => p.NombreVues),
                "recent" => query.OrderByDescending(p => p.DateAjout),
                _ => query.OrderBy(p => p.Nom)
            };

            var totalProduits = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalProduits / (double)PRODUITS_PAR_PAGE);

            var produits = await query
                .Skip((page - 1) * PRODUITS_PAR_PAGE)
                .Take(PRODUITS_PAR_PAGE)
                .ToListAsync();

            var categories = await _context.Categories.ToListAsync();

            // Récupérer les filtres disponibles pour la catégorie sélectionnée
            List<AttributCategorie> filtresDisponibles = new List<AttributCategorie>();
            if (categorieId.HasValue)
            {
                filtresDisponibles = await _context.AttributsCategories
                    .Where(a => a.CategorieId == categorieId.Value)
                    .ToListAsync();
            }

            var viewModel = new ProduitListViewModel
            {
                Produits = produits,
                Categories = categories,
                PageActuelle = page,
                TotalPages = totalPages,
                CategorieSelectionnee = categorieId,
                RechercheTexte = recherche,
                TriPar = triPar,
                PrixMin = prixMin,
                PrixMax = prixMax,
                FiltresDisponibles = filtresDisponibles,
                FiltresAppliques = filtresAppliques
            };

            return View(viewModel);
        }

        // GET: Produits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produit = await _context.Produits
                .Include(p => p.Categorie)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (produit == null)
            {
                return NotFound();
            }

            // Incrémenter le nombre de vues
            produit.NombreVues++;
            await _context.SaveChangesAsync();

            return View(produit);
        }
    }
}
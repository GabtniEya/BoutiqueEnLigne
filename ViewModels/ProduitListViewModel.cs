using BoutiqueEnLigne.Models;

namespace BoutiqueEnLigne.ViewModels
{
    public class ProduitListViewModel
    {
        public List<Produit> Produits { get; set; }
        public List<Categorie> Categories { get; set; }
        public int PageActuelle { get; set; }
        public int TotalPages { get; set; }
        public int? CategorieSelectionnee { get; set; }
        public string RechercheTexte { get; set; }
        public string TriPar { get; set; }

        // Nouveaux filtres dynamiques
        public List<AttributCategorie> FiltresDisponibles { get; set; }
        public Dictionary<string, string> FiltresAppliques { get; set; }

        // Filtres de prix
        public decimal? PrixMin { get; set; }
        public decimal? PrixMax { get; set; }
    }
}
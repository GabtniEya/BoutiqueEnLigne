namespace BoutiqueEnLigne.ViewModels
{
    public class PanierViewModel
    {
        public List<PanierItemViewModel> Items { get; set; }
        public decimal Total { get; set; }
    }

    public class PanierItemViewModel
    {
        public int ProduitId { get; set; }
        public string NomProduit { get; set; }
        public decimal Prix { get; set; }
        public int Quantite { get; set; }
        public decimal SousTotal { get; set; }
        public string ImageUrl { get; set; }
    }
}
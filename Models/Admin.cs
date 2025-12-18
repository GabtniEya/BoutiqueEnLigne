namespace BoutiqueEnLigne.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string MotDePasseHash { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
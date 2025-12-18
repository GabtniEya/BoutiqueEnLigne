namespace BoutiqueEnLigne.Helpers
{
    public interface IEmailService
    {
        Task EnvoyerEmailInscription(string destinataire, string nomUtilisateur);
        Task EnvoyerEmailConfirmationCommande(string destinataire, string numeroCommande, decimal montant);
        Task EnvoyerEmailChangementStatut(string destinataire, string numeroCommande, string nouveauStatut);
    }

    public class EmailService : IEmailService
    {
        private readonly string _dossierEmails;

        public EmailService()
        {
            // Créer un dossier pour stocker les emails simulés
            _dossierEmails = Path.Combine(Directory.GetCurrentDirectory(), "EmailsEnvoyes");
            if (!Directory.Exists(_dossierEmails))
            {
                Directory.CreateDirectory(_dossierEmails);
            }
        }

        public async Task EnvoyerEmailInscription(string destinataire, string nomUtilisateur)
        {
            var sujet = "Bienvenue sur Boutique En Ligne !";
            var corps = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; }}
        .container {{ background: white; padding: 30px; border-radius: 10px; max-width: 600px; margin: 0 auto; }}
        .header {{ background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; padding: 20px; border-radius: 10px; text-align: center; }}
        .content {{ padding: 20px; }}
        .footer {{ text-align: center; color: #999; font-size: 12px; margin-top: 30px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🎉 Bienvenue {nomUtilisateur} !</h1>
        </div>
        <div class='content'>
            <p>Bonjour <strong>{nomUtilisateur}</strong>,</p>
            <p>Merci de vous être inscrit sur <strong>Boutique En Ligne</strong> !</p>
            <p>Votre compte a été créé avec succès. Vous pouvez maintenant :</p>
            <ul>
                <li>✅ Parcourir notre catalogue de produits</li>
                <li>✅ Ajouter des articles à votre panier</li>
                <li>✅ Passer des commandes en toute sécurité</li>
                <li>✅ Profiter de codes promo exclusifs</li>
            </ul>
            <p><strong>Bon shopping !</strong></p>
        </div>
        <div class='footer'>
            <p>© 2024 Boutique En Ligne - Tous droits réservés</p>
        </div>
    </div>
</body>
</html>";

            await SauvegarderEmail(destinataire, sujet, corps);
        }

        public async Task EnvoyerEmailConfirmationCommande(string destinataire, string numeroCommande, decimal montant)
        {
            var sujet = $"Confirmation de commande #{numeroCommande}";
            var corps = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; }}
        .container {{ background: white; padding: 30px; border-radius: 10px; max-width: 600px; margin: 0 auto; }}
        .header {{ background: linear-gradient(135deg, #11998e 0%, #38ef7d 100%); color: white; padding: 20px; border-radius: 10px; text-align: center; }}
        .commande {{ background: #f8f9fa; padding: 20px; border-radius: 8px; margin: 20px 0; }}
        .montant {{ font-size: 24px; color: #11998e; font-weight: bold; }}
        .footer {{ text-align: center; color: #999; font-size: 12px; margin-top: 30px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>✅ Commande Confirmée !</h1>
        </div>
        <div class='content'>
            <p>Bonjour,</p>
            <p>Votre commande a été confirmée avec succès !</p>
            <div class='commande'>
                <p><strong>Numéro de commande :</strong> {numeroCommande}</p>
                <p><strong>Montant total :</strong> <span class='montant'>{montant:C}</span></p>
                <p><strong>Statut :</strong> En cours de préparation</p>
            </div>
            <p>📦 Votre commande sera expédiée sous 24-48h.</p>
            <p>Vous recevrez un email de confirmation dès l'expédition de votre colis.</p>
            <p><strong>Merci de votre confiance !</strong></p>
        </div>
        <div class='footer'>
            <p>© 2024 Boutique En Ligne</p>
        </div>
    </div>
</body>
</html>";

            await SauvegarderEmail(destinataire, sujet, corps);
        }

        public async Task EnvoyerEmailChangementStatut(string destinataire, string numeroCommande, string nouveauStatut)
        {
            var sujet = $"Mise à jour de votre commande #{numeroCommande}";
            var icone = nouveauStatut == "Expédiée" ? "🚚" : "✅";
            var couleur = nouveauStatut == "Expédiée" ? "#2193b0" : "#11998e";

            var corps = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; }}
        .container {{ background: white; padding: 30px; border-radius: 10px; max-width: 600px; margin: 0 auto; }}
        .header {{ background: linear-gradient(135deg, {couleur} 0%, #6dd5ed 100%); color: white; padding: 20px; border-radius: 10px; text-align: center; }}
        .statut {{ background: #f8f9fa; padding: 20px; border-radius: 8px; margin: 20px 0; text-align: center; }}
        .badge {{ display: inline-block; background: {couleur}; color: white; padding: 10px 20px; border-radius: 20px; font-weight: bold; }}
        .footer {{ text-align: center; color: #999; font-size: 12px; margin-top: 30px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>{icone} Mise à Jour de Commande</h1>
        </div>
        <div class='content'>
            <p>Bonjour,</p>
            <p>Votre commande <strong>#{numeroCommande}</strong> a été mise à jour.</p>
            <div class='statut'>
                <p><strong>Nouveau statut :</strong></p>
                <span class='badge'>{nouveauStatut}</span>
            </div>
            {(nouveauStatut == "Expédiée" ?
                "<p>📦 Votre colis est en route ! Vous devriez le recevoir sous 2-3 jours ouvrés.</p>" :
                "<p>✅ Votre commande a été livrée ! Nous espérons que vous êtes satisfait de votre achat.</p>")}
            <p><strong>Merci pour votre commande !</strong></p>
        </div>
        <div class='footer'>
            <p>© 2024 Boutique En Ligne</p>
        </div>
    </div>
</body>
</html>";

            await SauvegarderEmail(destinataire, sujet, corps);
        }

        private async Task SauvegarderEmail(string destinataire, string sujet, string corps)
        {
            var nomFichier = $"{DateTime.Now:yyyyMMdd_HHmmss}_{destinataire.Replace("@", "_at_")}.html";
            var cheminComplet = Path.Combine(_dossierEmails, nomFichier);

            var contenuComplet = $@"
<!--
À : {destinataire}
Sujet : {sujet}
Date : {DateTime.Now:dd/MM/yyyy HH:mm:ss}
-->
{corps}";

            await File.WriteAllTextAsync(cheminComplet, contenuComplet);

            // Log dans la console pour debug
            Console.WriteLine($"📧 Email envoyé à {destinataire} : {sujet}");
            Console.WriteLine($"   Fichier : {nomFichier}");
        }
    }
}
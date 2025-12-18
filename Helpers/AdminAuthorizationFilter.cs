using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BoutiqueEnLigne.Helpers
{
    public class AdminAuthorizationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var adminId = context.HttpContext.Session.GetInt32("AdminId");
            var actionName = context.RouteData.Values["action"]?.ToString();

            // Autoriser l'accès à ces pages sans authentification
            if (actionName == "Connexion" || actionName == "TestBCrypt")
            {
                return;
            }

            if (adminId == null)
            {
                context.Result = new RedirectToActionResult("Connexion", "Admin", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Ne rien faire après l'exécution
        }
    }
}
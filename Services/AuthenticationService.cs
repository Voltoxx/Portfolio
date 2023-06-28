using Azure;
using System.Net;

namespace Portfolio.Services
{
	public class AuthenticationService
	{
		public void CreateCookie(string name, string value, int expirationDays)
		{
			CookieContainer cookieContainer = new CookieContainer();

			// Créer un cookie
			Cookie cookie = new Cookie("mon_cookie", "valeur_du_cookie");
			cookie.Domain = "localhost";
			cookie.Path = "/";

			// Ajouter le cookie au CookieContainer
			cookieContainer.Add(cookie);

			Console.WriteLine("Cookie créé et ajouté au CookieContainer avec succès.");
		}
	}

}

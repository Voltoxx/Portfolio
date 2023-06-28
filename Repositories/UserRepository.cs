using System.Net;
using System;
using System.Web;
using Portfolio.Context;
using Portfolio.Models;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Portfolio.Repositories
{
    public class UserRepository
    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
	        this._context = context;
        }

		//Les méthodes   

		//Créer un cookie

		//public void CreateCookie(string name, string value, int expirationDays)
		//{
		//	CookieContainer container = new CookieContainer();
		//	Cookie cookie = new Cookie(name, value);
		//	cookie.Expires = DateTime.Now.AddDays(expirationDays);
		//	container.Add(cookie);

		//	// Utilisez la logique appropriée pour envoyer le cookie à votre destination souhaitée.
		//	// Par exemple, si vous effectuez une requête HTTP, vous pouvez l'ajouter à l'en-tête "Cookie".
		//	// Voici un exemple d'utilisation avec HttpClient :

		//	using (HttpClient client = new HttpClient())
		//	{
		//		client.BaseAddress = new Uri("https://localhost:7239/");
		//		client.DefaultRequestHeaders.Add("Cookie", container.GetCookieHeader(client.BaseAddress));

		//		// Effectuez vos opérations avec le client HttpClient ici
		//	}
		//}
		public static void CreateCookie(string name, string value, int expirationDays)
		{
			CookieContainer container = new CookieContainer();
			container.Add(new Cookie(name, value)
			{
				Expires = DateTime.Now.AddDays(expirationDays)
			});
		}

		//Register

		public void Registrer(Users user)
        {
	        user.IsAdmin = false;

			var exist = _context.User.Any(x => x.Username == user.Username);
			if (exist)
	        {
		        return;
	        }
			else
			{
				// Hasher le mot de passe
				string hashedPassword = BCryptNet.HashPassword(user.Password);

				// Utiliser le mot de passe haché
				user.Password = hashedPassword;
				_context.User.Add(user);
				_context.SaveChanges();
			}
	       
		}

		//Login

		public void Login(Users user)
		{
			var existingUser = _context.User.FirstOrDefault(x => x.Username == user.Username);
			if (existingUser != null && BCryptNet.Verify(user.Password, existingUser.Password))
			{
				// Utiliser le jeton pour la suite du traitement
			}
			else
			{
				return;
			}
		}

		//public bool IsConnected(string token)
		//{

		//}

		//Verif si admin
		public bool IsAdmin(Users user)
		{
			var admin = _context.User.FirstOrDefault(x => x.Id == user.Id && x.IsAdmin == true);
			if (admin != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

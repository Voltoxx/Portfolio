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
				//Création du cookie avec le controller
				var httpContextAccessor = new HttpContextAccessor();
				var httpContext = httpContextAccessor.HttpContext;
				string cookieValue = httpContext.Request.Cookies["Session"];
				user.CookieValue = cookieValue;
				_context.SaveChanges();
				//insère la valeur du cookie dans le champ CookieValue
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

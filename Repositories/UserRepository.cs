using System.Net;
using System;
using System.Web;
using Portfolio.Context;
using Portfolio.Models;
using Portfolio.Services;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Portfolio.Repositories
{
    public class UserRepository
    {

	    private readonly AppDbContext _context;
	    private readonly AuthenticationService _authenticationService = null!;

		public UserRepository(AppDbContext context)
		{
			this._context = context;

		}

		//Les méthodes   

		//Register

		public void Registrer(Users user)
        {
	        user.IsAdmin = false;

			var exist = _context.Users.Any(x => x.Username == user.Username);
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
				_context.Users.Add(user);
				_context.SaveChanges();
			}
	       
		}

		//Login

		public void Login(Users user, HttpResponse cookieResponse)
		{
			var existingUser = _context.Users.FirstOrDefault(x => x.Username == user.Username);
			if (existingUser != null && BCryptNet.Verify(user.Password, existingUser.Password))
			{
				//Créer le cookie et l'insere dans la base de données
				string token = Guid.NewGuid().ToString();
				_authenticationService.CreateCookie("Session", token, 7, cookieResponse);
				user.CookieValue = token;
				_context.SaveChanges();
			}
			else
			{
				return;
			}
		}

		//Verif si admin
		public bool IsAdmin(Users user)
		{
			var admin = _context.Users.FirstOrDefault(x => x.Id == user.Id && x.IsAdmin == true);
			if (admin != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public Users GetUserConnected(string token)
		{
			return _context.Users.FirstOrDefault(u => u.CookieValue == token);
		}
	}
}

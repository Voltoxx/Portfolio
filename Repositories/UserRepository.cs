using Portfolio.Context;
using Portfolio.Models;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Portfolio.Repositories
{
    public class UserRepository
    {

	    private readonly AppDbContext _context;

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

		public void Login(Users user, string token)
		{
			user.CookieValue = token;
			_context.SaveChanges();
		}

		public Users GetUserByName(Users user)
		{
			return _context.Users.First(x => x.Username == user.Username);
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
			return _context.Users.First(u => u.CookieValue == token);
		}
	}
}

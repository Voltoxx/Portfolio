using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Context;
using Portfolio.Models;

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
				_context.User.Add(user);
				_context.SaveChanges();
			}
	       
		}

        //Login

        public void Login(Users user)
        {

	        var exist = _context.User.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
	        if (exist != null)
	        {
				//mettre les infos du User dans un jeton.
			}
			else
	        {
				return;
	        }
        }

        public bool IsConnect(/*le jeton*/)
        {
	        //bool isAuthenticated = Récupération avec le jeton;
	        //return isAuthenticated;
        }
    }
}

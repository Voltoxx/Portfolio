using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.Services;

namespace Portfolio.Controllers
{
	public class UserController : Controller
	{

		private readonly UserRepository _userRepository;
		private readonly AuthenticationServices _authenticationServices;
		public UserController(UserRepository userRepository, AuthenticationServices Auth)
		{
			_userRepository = userRepository;
			_authenticationServices = Auth;
		}

		public IActionResult ViewRegister()
		{
			return View();
		}

		public IActionResult ViewLogin()
		{
			return View();
		}
		public IActionResult Test()
		{
			// Appel de la méthode CreateCookie du service d'authentification
			string key = "username";
			string value = "JohnDoe";
			int expiration = 7; // Durée de validité en jours

			_authenticationServices.CreateCookie(key, value, expiration);

			// Autres actions...

			return View();
		}

		public void CreateCookie(string key, string value, int expiration)
		{
			_authenticationServices.CreateCookie(key, value, expiration);
		}

		public bool IsAdmin(Users user)
		{
			return _userRepository.IsAdmin(user);
		}

		//public bool IsConnected(string token)
		//{

		//}

		public ActionResult Register(Users user)
		{
			_userRepository.Registrer(user);
			return RedirectToAction(nameof(ViewRegister));
		}

		public ActionResult Login(Users user)
		{
			_userRepository.Login(user);
			return RedirectToAction(nameof(ViewLogin));
		}
	}
}

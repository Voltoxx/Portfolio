using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.Services;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Portfolio.Controllers
{
	public class UserController : CustomControllerBase
	{

		private readonly UserRepository _userRepository;
		private readonly AuthenticationService _authenticationService;

		public UserController(UserRepository userRepository, AuthenticationService Auth) : base(Auth)
        {
			_userRepository = userRepository;
			_authenticationService = Auth;
        }

		public IActionResult ViewRegister()
		{
			return View();
		}

		public IActionResult ViewLogin()
		{
			return View();
		}

		public IActionResult ViewLogout()
		{
			return View();
		}

		public bool IsAdmin(Users user)
		{
			return _userRepository.IsAdmin(user);
		}

		public ActionResult Register(Users user)
		{
			_userRepository.Registrer(user);
			return RedirectToAction("Index", "Portfolio");
		}

		public ActionResult Login(Users user)
		{
			var existingUser = _userRepository.GetUserByName(user);
			if (existingUser != null && BCryptNet.Verify(user.Password, existingUser.Password))
			{
				//Créer le cookie et l'insere dans le requete Http
				string token = Guid.NewGuid().ToString();
				_authenticationService.CreateCookie("Session", token, 7, Response);
				_userRepository.Login(existingUser, token);
			}
			else
			{
				return new EmptyResult();
			}
			return RedirectToAction("Index", "Portfolio");
		}

		public ActionResult Logout()
		{
			string token = _authenticationService.GetUser()!.CookieValue;
			Users user = _userRepository.GetUserConnected(token);
			_userRepository.Logout(user);
			_authenticationService.DeleteCookie();
			return RedirectToAction("Index", "Portfolio");
		}
	}

	
}

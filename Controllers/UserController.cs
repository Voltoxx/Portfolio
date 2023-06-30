using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.Services;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Portfolio.Controllers
{
	public class UserController : Controller
	{

		private readonly UserRepository _userRepository;
		private readonly AuthenticationService _authenticationService;

		public UserController(UserRepository userRepository, AuthenticationService Auth)
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

		public Users GetUserConnected()
		{
			var user = _authenticationService.GetUserConnected();
			return user;
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
			return RedirectToAction(nameof(ViewLogin));
		}

		//public ActionResult Logout()
		//{
		//	_userRepository.Logout(user);
		//	return RedirectToAction(nameof(ViewLogout));
		//}
	}

	
}

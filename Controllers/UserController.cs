using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Context;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.Services;

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
			var user = _authenticationService.GetUserConnected(HttpContext);
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
			_userRepository.Login(user, HttpContext.Response);
			return RedirectToAction(nameof(ViewLogin));
		}

		//public ActionResult Logout()
		//{
		//	_userRepository.Logout(user);
		//	return RedirectToAction(nameof(ViewLogout));
		//}
	}

	
}

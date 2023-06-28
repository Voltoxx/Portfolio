using Microsoft.AspNetCore.Mvc;
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

		[HttpGet("CreateCookie")]
		public IActionResult CreateCookie(string key, string value, int expiration)
		{
			_authenticationService.CreateCookie(key, value, expiration);
			return Ok();
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

using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Controllers
{
	public class UserController : Controller
	{
		private readonly UserRepository _userRepository;
		public UserController(UserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Manage()
		{
			return View();
		}

		public string GenerateToken(Users user)
		{
			return _userRepository.GenerateToken(user);
		}

		public bool IsAdmin(Users user)
		{
			return _userRepository.IsAdmin(user);
		}

		public bool IsConnected(string token)
		{

			return _userRepository.IsConnected(token);
		}

		public ActionResult Register(Users user)
		{
			_userRepository.Registrer(user);
			return RedirectToAction(nameof(Index));
		}

		public ActionResult Login(Users user)
		{
			_userRepository.Login(user);
			return RedirectToAction(nameof(Index));
		}
	}
}

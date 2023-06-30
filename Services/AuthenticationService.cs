using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Services
{
	public class AuthenticationService
	{

		private readonly UserRepository _userRepository;
		public AuthenticationService(UserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public void CreateCookie(string name, string value, int expirationDays, HttpResponse cookieResponse)
		{
			var cookieOptions = new CookieOptions
			{
				Path = "/",
				Expires = DateTimeOffset.UtcNow.AddDays(expirationDays),
				Secure = true,
				IsEssential = true
			};

			cookieResponse.Cookies.Append(name, value, cookieOptions);
		}

		public Users GetUserConnected(HttpContext cookie)
		{
			var token = cookie.Request.Cookies["Session"];
			// Comparaison du cookie avec ceux de la base de données
			var userConnected = _userRepository.GetUserConnected(token);

			return userConnected;
		}
	}

}

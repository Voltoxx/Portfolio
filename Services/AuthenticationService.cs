using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Services
{
	public class AuthenticationService
	{
        private readonly UserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private Users? User = null;

		public AuthenticationService(UserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
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

        public Users? GetUser()
        {
            try
            {
                var request = _httpContextAccessor.HttpContext.Request;
                var token = request.Cookies["Session"];
                // Comparaison du cookie avec ceux de la base de données
                User = _userRepository.GetUserConnected(token);
            }
            catch (Exception)
            {
            }

            return User;
        }
    }

}

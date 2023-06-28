using Azure;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Services
{
	public class AuthenticationService
	{
		
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
	}

}

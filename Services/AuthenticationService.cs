using System.Net;

namespace Portfolio.Services
{
	public class AuthenticationService
	{

		public void CreateCookie(string name, string value, int expirationDays)
		{
			CookieContainer container = new CookieContainer();
			container.Add(new Cookie(name, value)
			{
				Expires = DateTime.Now.AddDays(expirationDays)
			});
		}



	}
}

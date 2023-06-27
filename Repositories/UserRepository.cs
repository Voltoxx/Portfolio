using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Context;
using Portfolio.Models;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Portfolio.Repositories
{
    public class UserRepository
    {

        private readonly ApplicationDbContext _context;

        private readonly IConfiguration _config;

		public UserRepository(ApplicationDbContext context, IConfiguration config)
        {
	        this._context = context;
	        _config = config;
        }

		//Les méthodes   

		//Verif si admin

		public string GenerateToken(Users user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Role, user.IsAdmin.ToString()), //Surement pas bon car IsAdmin est bool !!!!!!!!!!!!!!!
				new Claim(ClaimTypes.Name, user.Username),
			};
			var tokenOptions = new JwtSecurityToken(
				issuer: _config["Jwt:Issuer"],
				audience: _config["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(15),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
		}

		//Register

        public void Registrer(Users user)
        {
	        user.IsAdmin = false;

			var exist = _context.User.Any(x => x.Username == user.Username);
			if (exist)
	        {
		        return;
	        }
			else
			{
				// Hasher le mot de passe
				string hashedPassword = BCryptNet.HashPassword(user.Password);

				// Utiliser le mot de passe haché
				user.Password = hashedPassword;
				_context.User.Add(user);
				_context.SaveChanges();
			}
	       
		}

		//Login

		public void Login(Users user)
		{
			var existingUser = _context.User.FirstOrDefault(x => x.Username == user.Username);
			if (existingUser != null && BCryptNet.Verify(user.Password, existingUser.Password))
			{
				string token = GenerateToken(existingUser);
				// Utiliser le jeton pour la suite du traitement
			}
			else
			{
				return;
			}
		}

		public bool IsConnect(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

			try
			{
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = securityKey,
					ValidateIssuer = true,
					ValidIssuer = _config["Jwt:Issuer"],
					ValidateAudience = true,
					ValidAudience = _config["Jwt:Audience"],
					ClockSkew = TimeSpan.Zero
				}, out SecurityToken validatedToken);

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool IsAdmin(Users user)
		{
			var admin = _context.User.FirstOrDefault(x => x.Id == user.Id && x.IsAdmin == true);
			if (admin != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

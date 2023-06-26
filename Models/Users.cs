using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
	[Table("Users")]
	public class Users
	{
		[Key]
		public int Id { get; set; }

		public string Username { get; set; } = string.Empty;

		public string Password { get; set; } = string.Empty;

		public bool IsAdmin { get; set; }

	}
}

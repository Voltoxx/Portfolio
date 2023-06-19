using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    [Table("Projets")]
    public class Projets
    {
        [Key] 
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImagePrincipale { get; set; } = string.Empty;

        public Categorie Categorie { get; set; } = null!;

        public Images Images { get; set; } = null!;
    }
}

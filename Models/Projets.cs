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

        public string Categorie { get; set; } = string.Empty;

        public string FirstImage { get; set; } = string.Empty;

        public string SecondImage { get; set; } = string.Empty;

        public string ThirdImage { get; set; } = string.Empty;
    }
}

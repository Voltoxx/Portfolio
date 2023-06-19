using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    [Table("Categorie")]
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }

        public string CategorieName { get; set; } = string.Empty;

    }
}

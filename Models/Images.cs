using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    [Table("Images")]
    public class Images
    {
        [Key]
        public int ImagesId { get; set; }

        public string ImageName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string ImageType { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Albums.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        public string? PictureURL { get; set; }

        [Required]
        public string FullName { get; set; }

        public string? Bio { get; set; }
        public DateTime? BirthDate { get; set; }

        public string? AstroSign { get; set; }

        public Producer? Producer { get; set; }

        public List<Artist_Band>? Artists_Bands { get; set; }

        public List<Artist_Song>? Artists_Songs { get; set; }
    }
}
        



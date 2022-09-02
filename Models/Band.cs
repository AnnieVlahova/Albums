using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Albums.Models
{
    public class Band
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string? Bio { get; set; }

        public DateTime? Created { get; set; }

        public Producer? Producer { get; set; }

        public List<Artist_Band>? Artists_Bands { get; set; }

        public List<Band_Song>? Bands_Songs { get; set; }



    }
}

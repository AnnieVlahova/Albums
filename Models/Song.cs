using System.ComponentModel.DataAnnotations;

namespace Albums.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public Artist? Artist { get; set; }

        public Band? Band { get; set; }

        public DateTime? Released { get; set; }

        public Album? Album { get; set; }

        public double Price { get; set; }

        public List<Artist_Song>? Artists_Songs { get; set; }

        public List<Band_Song>? Bands_Songs { get; set; }
    }
}

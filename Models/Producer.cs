using System.ComponentModel.DataAnnotations;

namespace Albums.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string? PictureURL { get; set; }

        [Required]
        public string FullName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Bio { get; set; }

        public List<Artist>? Artists { get; set; }

        public List<Band>? Bands { get; set; }

        public List<Album>? Albums { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Albums.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Title { get; set; }

        public Artist? Artist { get; set; }

        public Band? Band { get; set; }

        public Producer? Producer { get; set; }

        public DateTime? Released { get; set; }

        public List<Song>? Songs { get; set; }
        [Display(Name = "Profile Picture")]
        public string? AlbumPictureURL { get; set; }
        public string? Description { get; set; }

        public double Price { get; set; }

    }
}

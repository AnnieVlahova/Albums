using System.ComponentModel.DataAnnotations.Schema;

namespace Albums.Models
{
    public class Artist_Band
    {
        public int? ArtistId { get; set; }

        public Artist? Artist { get; set; }

        public int? BandId { get; set; }

        public Band? Band { get; set; }

    }
}

namespace Albums.Models
{
    public class Artist_Song
    {
        public int? ArtistId { get; set; }

        public Artist? Artist { get; set; }

        public int? SongId { get; set; }

        public Song? Song { get; set; }
    }
}

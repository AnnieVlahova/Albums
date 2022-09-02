namespace Albums.Models
{
    public class Band_Song
    {
        public int? BandId { get; set; }

        public Band? Band { get; set; }

        public int? SongId { get; set; }

        public Song? Song { get; set; }
    }
}

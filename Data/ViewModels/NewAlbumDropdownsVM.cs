using Albums.Controllers;
using Albums.Models;

namespace Albums.Data.ViewModels
{
    public class NewAlbumDropdownsVM
    {
        public NewAlbumDropdownsVM()
        {
            Artists = new List<Artist>();
            Bands = new List<Band>();
            Producers = new List<Producer>();
        }

        public List<Artist> Artists { get; set; }

        public List<Band> Bands { get; set; }

        public List<Producer> Producers { get; set; }
    }
}

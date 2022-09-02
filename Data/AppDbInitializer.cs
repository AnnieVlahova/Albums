using Albums.Models;

namespace Albums.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Songs.Any())
                {
                    Console.WriteLine("ehoo song");
                    context.Songs.AddRange(new List<Song>()
                    {
                        new Song()
                        {
                             Title = "Yen",
                             Released = DateTime.Now

                        }

                    });
                    context.SaveChanges();

                }
                if (!context.Artists.Any())
                {
                    Console.WriteLine("ehoo art");
                    context.Artists.AddRange(new List<Artist>()
                    {

                        new Artist()
                        {
                             FullName = "Corey Tayler"

                        }

                    });
                    context.SaveChanges();

                }
                if (!context.Bands.Any())
                {
                    Console.WriteLine("ehoo band");
                    context.Bands.AddRange(new List<Band>()
                    {

                        new Band()
                        {
                            
                            Name = "Slipknot"

                        }

                    });
                    context.SaveChanges();

                }
                if (!context.Albums.Any())
                {
                    context.Albums.AddRange(new List<Album>()
                    {
                        new Album()
                        {
                             Title = "The End, So Far"

                        },
                        new Album()
                        {
                             Title = "The Endar"

                        }

                    });
                    context.SaveChanges();

                }
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                             FullName = "Pesho"

                        }

                    });
                    context.SaveChanges();

                }
                if (!context.Artists_Songs.Any())
                {

                }
                if (!context.Artists_Bands.Any())
                {

                }
                if (!context.Bands_Songs.Any())
                {

                }
            }
        }
    }
}

using Albums.Models;
using Microsoft.EntityFrameworkCore;

namespace Albums.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist_Band>().HasKey(ab => new
            {
                ab.ArtistId,
                ab.BandId
            });

            modelBuilder.Entity<Artist_Band>().HasOne(a => a.Artist).WithMany(ab => ab.Artists_Bands).HasForeignKey(a => a.ArtistId);
            modelBuilder.Entity<Artist_Band>().HasOne(a => a.Band).WithMany(ab => ab.Artists_Bands).HasForeignKey(a => a.BandId);

            modelBuilder.Entity<Artist_Song>().HasKey(ab => new
            {
                ab.ArtistId,
                ab.SongId
            });

            modelBuilder.Entity<Artist_Song>().HasOne(a => a.Artist).WithMany(ab => ab.Artists_Songs).HasForeignKey(a => a.ArtistId);
            modelBuilder.Entity<Artist_Song>().HasOne(a => a.Song).WithMany(ab => ab.Artists_Songs).HasForeignKey(a => a.SongId);

            modelBuilder.Entity<Band_Song>().HasKey(ab => new
            {
                ab.BandId,
                ab.SongId
            });

            modelBuilder.Entity<Band_Song>().HasOne(a => a.Band).WithMany(ab => ab.Bands_Songs).HasForeignKey(a => a.BandId);
            modelBuilder.Entity<Band_Song>().HasOne(a => a.Song).WithMany(ab => ab.Bands_Songs).HasForeignKey(a => a.SongId);

            modelBuilder.Entity<Producer>().HasMany(p => p.Albums).WithOne(a => a.Producer);
            modelBuilder.Entity<Producer>().HasMany(p => p.Artists).WithOne(a => a.Producer);
            modelBuilder.Entity<Producer>().HasMany(p => p.Bands).WithOne(a => a.Producer);

            modelBuilder.Entity<Album>().HasMany(a => a.Songs).WithOne(s => s.Album);


            base.OnModelCreating(modelBuilder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //var connectionString = configuration.GetConnectionString("DefaultConnectionString");
            //optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Albums.Models.Album>? Albums { get; set; }
        public DbSet<Albums.Models.Artist>? Artists { get; set; }
        public DbSet<Albums.Models.Band>? Bands { get; set; }
        public DbSet<Albums.Models.Producer>? Producers { get; set; }
        public DbSet<Albums.Models.Song>? Songs { get; set; }

        public DbSet<Artist_Band>? Artists_Bands { get; set; }
        public DbSet<Artist_Song>? Artists_Songs { get; set; }

        public DbSet<Band_Song>? Bands_Songs { get; set; }


    }
}

// <auto-generated />
using System;
using Albums.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Albums.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220902124007_songsRequiredNot")]
    partial class songsRequiredNot
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Albums.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlbumPictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int?>("BandId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("ProducerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Released")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("BandId");

                    b.HasIndex("ProducerId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Albums.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AstroSign")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProducerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Albums.Models.Artist_Band", b =>
                {
                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int?>("BandId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId", "BandId");

                    b.HasIndex("BandId");

                    b.ToTable("Artists_Bands");
                });

            modelBuilder.Entity("Albums.Models.Artist_Song", b =>
                {
                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int?>("SongId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("Artists_Songs");
                });

            modelBuilder.Entity("Albums.Models.Band", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProducerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("Albums.Models.Band_Song", b =>
                {
                    b.Property<int?>("BandId")
                        .HasColumnType("int");

                    b.Property<int?>("SongId")
                        .HasColumnType("int");

                    b.HasKey("BandId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("Bands_Songs");
                });

            modelBuilder.Entity("Albums.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("Albums.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int?>("BandId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Released")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("BandId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("Albums.Models.Album", b =>
                {
                    b.HasOne("Albums.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.HasOne("Albums.Models.Band", "Band")
                        .WithMany()
                        .HasForeignKey("BandId");

                    b.HasOne("Albums.Models.Producer", "Producer")
                        .WithMany("Albums")
                        .HasForeignKey("ProducerId");

                    b.Navigation("Artist");

                    b.Navigation("Band");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("Albums.Models.Artist", b =>
                {
                    b.HasOne("Albums.Models.Producer", "Producer")
                        .WithMany("Artists")
                        .HasForeignKey("ProducerId");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("Albums.Models.Artist_Band", b =>
                {
                    b.HasOne("Albums.Models.Artist", "Artist")
                        .WithMany("Artists_Bands")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Albums.Models.Band", "Band")
                        .WithMany("Artists_Bands")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Band");
                });

            modelBuilder.Entity("Albums.Models.Artist_Song", b =>
                {
                    b.HasOne("Albums.Models.Artist", "Artist")
                        .WithMany("Artists_Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Albums.Models.Song", "Song")
                        .WithMany("Artists_Songs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("Albums.Models.Band", b =>
                {
                    b.HasOne("Albums.Models.Producer", "Producer")
                        .WithMany("Bands")
                        .HasForeignKey("ProducerId");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("Albums.Models.Band_Song", b =>
                {
                    b.HasOne("Albums.Models.Band", "Band")
                        .WithMany("Bands_Songs")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Albums.Models.Song", "Song")
                        .WithMany("Bands_Songs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Band");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("Albums.Models.Song", b =>
                {
                    b.HasOne("Albums.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId");

                    b.HasOne("Albums.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.HasOne("Albums.Models.Band", "Band")
                        .WithMany()
                        .HasForeignKey("BandId");

                    b.Navigation("Album");

                    b.Navigation("Artist");

                    b.Navigation("Band");
                });

            modelBuilder.Entity("Albums.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Albums.Models.Artist", b =>
                {
                    b.Navigation("Artists_Bands");

                    b.Navigation("Artists_Songs");
                });

            modelBuilder.Entity("Albums.Models.Band", b =>
                {
                    b.Navigation("Artists_Bands");

                    b.Navigation("Bands_Songs");
                });

            modelBuilder.Entity("Albums.Models.Producer", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Artists");

                    b.Navigation("Bands");
                });

            modelBuilder.Entity("Albums.Models.Song", b =>
                {
                    b.Navigation("Artists_Songs");

                    b.Navigation("Bands_Songs");
                });
#pragma warning restore 612, 618
        }
    }
}

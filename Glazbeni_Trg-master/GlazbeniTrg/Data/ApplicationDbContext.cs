
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GlazbeniTrg.Models;

namespace GlazbeniTrg.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Album> Album { get; set; }
        public DbSet<CartAlbum> CartAlbum { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Label> Label { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<SongPerson> SongPerson { get; set; }
       
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

           

            modelBuilder.Entity<SongPerson>()
               .HasKey(c => new { c.SongID, c.PersonID });

            modelBuilder.Entity<Rating>()
               .HasKey(c => new { c.AlbumID, c.Id });

            modelBuilder.Entity<AlbumGenre>()
               .HasKey(c => new { c.AlbumID, c.GenreID });

            modelBuilder.Entity<SongAlbum>()
              .HasKey(c => new { c.SongID, c.AlbumID });

            modelBuilder.Entity<SongGenre>()
             .HasKey(c => new { c.SongID, c.GenreID });

            modelBuilder.Entity<AlbumGenre>()
                .HasOne(ag => ag.Genre)
                .WithMany("AlbumGenres");


            modelBuilder.Entity<AlbumGenre>()
                .HasOne(ag => ag.Album)
                .WithMany("AlbumGenres");


            modelBuilder.Entity<SongPerson>()
                .HasOne(sp => sp.Song)
                .WithMany("SongPersons");

            modelBuilder.Entity<SongPerson>()
                .HasOne(sp => sp.Person)
                .WithMany("SongPersons");


            modelBuilder.Entity<SongGenre>()
                .HasOne(sg => sg.Genre)
                .WithMany("SongGenres");
                

            modelBuilder.Entity<SongGenre>()
                .HasOne(sg => sg.Song)
                .WithMany("SongGenres");
                
            modelBuilder.Entity<SongAlbum>()
                .HasOne(sa => sa.Song)
                .WithMany("SongAlbums");


            modelBuilder.Entity<SongAlbum>()
                .HasOne(sa => sa.Album)
                .WithMany("SongAlbums");


            modelBuilder.Entity<Rating>()
               .HasOne(r => r.ApplicationUser)
               .WithMany("Ratings");


            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Album)
                .WithMany("Ratings");

           


        }

    }
}

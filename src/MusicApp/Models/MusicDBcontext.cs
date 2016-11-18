using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MusicApp.Models
{
    public class MusicDbContext : IdentityDbContext <ApplicationUser>
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PlaylistExtension>()
                .HasKey(a => new { a.playlistID, a.albumID });

            modelBuilder.Entity<PlaylistExtension>()
                .HasOne(pl => pl.playlist)
                .WithMany(l => l.list)
                .HasForeignKey(pl => pl.playlistID);

            modelBuilder.Entity<PlaylistExtension>()
                .HasOne(pl => pl.album)
                .WithMany(l => l.list)
                .HasForeignKey(pl => pl.albumID);
        }
    }
}

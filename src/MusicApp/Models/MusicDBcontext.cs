﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicApp.Models
{
    public class MusicDbContext : DbContext
    {
        internal Album AlbumID;

        public MusicDbContext(DbContextOptions<MusicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; internal set; }
        public DbSet<Genre> Genres { get; set; }
    }
}

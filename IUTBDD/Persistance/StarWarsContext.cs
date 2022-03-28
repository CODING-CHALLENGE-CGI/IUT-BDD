using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Persistance.Models;
using System;
using System.IO;

namespace Persistance
{
    public class StarWarsContext : DbContext
    {




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            base.OnConfiguring(optionsBuilder);

            var sqlitePath = Path.Combine(
       Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
       @"StarWars.db");

            optionsBuilder.UseSqlite("Data Source="+sqlitePath);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // episodes
            modelBuilder.Entity<Episode>().HasKey(c => c.Id);
            modelBuilder.Entity<Episode>().Property(e => e.Id).ValueGeneratedNever();

            // planets
            modelBuilder.Entity<Planet>().HasKey(c => c.Id);
            modelBuilder.Entity<Planet>().Property(e => e.Id).ValueGeneratedNever();

            // characters
            modelBuilder.Entity<Character>().HasKey(c => c.Id);
            modelBuilder.Entity<Character>().Property(e => e.Id).ValueGeneratedNever();

            // characters-friends
            modelBuilder.Entity<CharacterFriend>().HasKey(t => new { t.CharacterId, t.FriendId });

            modelBuilder.Entity<CharacterFriend>()
                .HasOne(cf => cf.Character)
                .WithMany(c => c.CharacterFriends)
                .HasForeignKey(cf => cf.CharacterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CharacterFriend>()
                .HasOne(cf => cf.Friend)
                .WithMany(t => t.FriendCharacters)
                .HasForeignKey(cf => cf.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            // characters-episodes
            modelBuilder.Entity<CharacterEpisode>().HasKey(t => new { t.CharacterId, t.EpisodeId });

            modelBuilder.Entity<CharacterEpisode>()
                .HasOne(cf => cf.Character)
                .WithMany(c => c.CharacterEpisodes)
                .HasForeignKey(cf => cf.CharacterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CharacterEpisode>()
                .HasOne(cf => cf.Episode)
                .WithMany(t => t.CharacterEpisodes)
                .HasForeignKey(cf => cf.EpisodeId)
                .OnDelete(DeleteBehavior.Restrict);

            // humans
            modelBuilder.Entity<Human>().HasOne(h => h.HomePlanet).WithMany(p => p.Humans);
        }



        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<CharacterFriend> CharacterFriends { get; set; }
        public virtual DbSet<CharacterEpisode> CharacterEpisodes { get; set; }
        public virtual DbSet<Droid> Droids { get; set; }
        public virtual DbSet<Human> Humans { get; set; }
    }
}

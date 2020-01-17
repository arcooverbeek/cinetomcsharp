using System;
using CineTom.Models;
using Microsoft.EntityFrameworkCore;

namespace CineTom.Persistence
{
    public class DBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Room> Rooms { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;database=cinetom;user=cinetom;password=password123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RoomNumber).IsRequired();
            });

        }
    }
}

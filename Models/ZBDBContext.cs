using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Zealandic_Booking.Models
{
    public class ZBDBContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        protected ZBDBContext(DbSet<Booking> bookings, DbSet<Building> buildings, DbSet<Location> locations, DbSet<Room> rooms, DbSet<User> users)
        {
            Bookings = bookings;
            Buildings = buildings;
            Locations = locations;
            Rooms = rooms;
            Users = users;
        }

        public ZBDBContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ZealandBookingDB; Integrated Security=True; Connect Timeout=10; Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder DatabaseBuilder)
        {
            DatabaseBuilder.Entity<Booking>().ToTable(nameof(Bookings))
                .HasOne(r => r.Room);
            DatabaseBuilder.Entity<Booking>().ToTable(nameof(Bookings))
                .HasOne(u => u.User);
            DatabaseBuilder.Entity<Room>().ToTable(nameof(Rooms))
                .HasOne(b => b.Building);
            DatabaseBuilder.Entity<Room>().ToTable(nameof(Rooms))
                .HasOne(l => l.Location);
            DatabaseBuilder.Entity<Building>().ToTable(nameof(Buildings))
                .HasOne(l => l.Location);
        }
    }
}

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
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ZBDB; Integrated Security=True; Connect Timeout=10; Encrypt=False");
        }
    }
}

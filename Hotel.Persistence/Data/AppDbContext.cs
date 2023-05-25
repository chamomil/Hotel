using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        DbSet<User> Users { get; }
        DbSet<BookingData> Bookings { get; }
        DbSet<Room> Rooms { get; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<BookingData>().HasKey(b => b.Id);
            modelBuilder.Entity<Room>().HasKey(b => b.Id);

            modelBuilder.Entity<BookingData>().HasOne(b => b.User).WithMany(s => s.BookedRooms).HasForeignKey(b => b.UserId);
            modelBuilder.Entity<BookingData>().HasOne(b => b.Room).WithMany(s => s.Bookings).HasForeignKey(b => b.RoomId);

            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<BookingData>().Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Room>().Property(r => r.Id).ValueGeneratedOnAdd();
        }
    }
}

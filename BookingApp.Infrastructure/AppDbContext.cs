using BookingApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookingApp.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("data source=.;Initial Catalog = BookingAppDB; Integrated Security = True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var resources = new Resource[10] ;
            for (int i = 0; i < 10; i++)
            {
                resources[i] = new Resource() { Id = i+1, Name = "resource_" + i, Quantity = 10 };
            }
            modelBuilder.Entity<Resource>().HasData(resources);

            var bookings = new Booking[10] ;
            for (int i = 0; i < 10; i++)
            {
                bookings[i] = new Booking() { Id = i+1, ResourceId = i+1, BookedQuantity = 0,DateFrom=DateTime.Now,DateTo=DateTime.Now.AddDays(i) };
            }
            modelBuilder.Entity<Booking>().HasData(bookings);


            base.OnModelCreating(modelBuilder);
        }
    }
}

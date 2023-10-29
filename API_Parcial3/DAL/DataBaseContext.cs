
using API_Parcial3.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Parcial3.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasIndex("Address", "City").IsUnique();

            modelBuilder.Entity<Room>().HasIndex("Number", "HotelId").IsUnique();
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}

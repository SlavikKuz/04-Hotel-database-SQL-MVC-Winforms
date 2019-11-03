using HotelDB.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelDb.DataLayer.Context
{
    public class HotelDbContext : DbContext
    {
        public DbSet <ClientModel> Clients { get; set; }
        public DbSet <BookingModel> Bookings { get; set; }
        public DbSet <RoomModel> Rooms { get; set; }
        public DbSet<DayModel> Holidays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=ht_localdb;Trusted_Connection=True;");
        }
    }
}

using HotelDb.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HotelDb.DataLayer.Context
{
    public class HotelDbContext : DbContext
    {
        private ILoggerFactory MyConsoleLoggerFactory;
        public HotelDbContext()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder
                        .AddConsole()
                        .AddFilter
                        (DbLoggerCategory.Database.Command.Name, LogLevel.Information));

            MyConsoleLoggerFactory = serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
        }

        public HotelDbContext(DbContextOptions<HotelDbContext> options)
            :base(options) { }

        public DbSet<ClientDL> Clients { get; set; }
        public DbSet<BookingDL> Bookings { get; set; }
        public DbSet<RoomDL> Rooms { get; set; }
        public DbSet<DayDL> Holidays { get; set; }
        public DbSet<GuestDL> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestDL>()
                .HasKey(x => new { x.ClientId, x.BookingId });
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                .EnableSensitiveDataLogging(true);
        }
    }
}

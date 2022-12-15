using FootballBooking.Entities.EntityConfigurations;
using FootballBooking.Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace FootballBooking.Entities
{
    public class FootballBookingDbContext : DbContext
    {
        public FootballBookingDbContext(DbContextOptions<FootballBookingDbContext> options)
            : base(options)
        {
        }

        public FootballBookingDbContext()
        {
        }

        public DbSet<Booker> Booker { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Stadium> Stadium { get; set; }
        public DbSet<StadiumOwner> StadiumOwner { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StadiumEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StadiumOwnerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AddressEntityConfiguration());
        }
    }
}
using FootballBooking.Entities.EntityConfigurations;
using FootballBooking.Entities.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FootballBooking.Entities
{
    public class FootballBookingDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public FootballBookingDbContext(DbContextOptions<FootballBookingDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("FootballBooking");
        }

        public FootballBookingDbContext()
        {
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

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
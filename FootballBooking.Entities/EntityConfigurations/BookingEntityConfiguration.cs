using FootballBooking.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBooking.Entities.EntityConfigurations
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");

            builder.HasKey("Id");

            builder
             .HasOne(booker => booker.Booker)
             .WithMany(booker => booker.Bookings)
             .HasForeignKey(booker => booker.BookerId);

            builder
            .HasOne(stadium => stadium.Stadium)
            .WithMany(stadium => stadium.Bookings)
            .HasForeignKey(stadium => stadium.StadiumId);
        }
    }
}
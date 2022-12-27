using FootballBooking.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBooking.Entities.EntityConfigurations
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            //builder.ToTable("Booking");

            //builder.HasKey("Id");

            //builder
            // .HasOne(booker => booker.Booker)
            // .WithMany(booker => booker.Bookings)
            // .HasForeignKey(booker => booker.BookerId);

            builder.ToTable("Booking");

            builder.HasIndex(e => e.BookerId, "IX_Booking_BookerId");

            builder.HasIndex(e => e.StadiumId, "IX_Booking_StadiumId");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasOne(d => d.Booker)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BookerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_User");
        }
    }
}
using FootballBooking.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBooking.Entities.EntityConfigurations
{
    public class BookingStadiumEntityConfiguration : IEntityTypeConfiguration<StadiumBooking>
    {
        public void Configure(EntityTypeBuilder<StadiumBooking> builder)
        {
            //builder.ToTable("BookingDetails");

            //builder.HasKey(e => new { e.BookingId, e.StadiumId });

            //builder
            //    .HasOne(bs => bs.Booking)
            //    .WithMany(b => b.BookingStadiums)
            //    .HasForeignKey(b => b.BookingId);

            //builder
            //  .HasOne(bs => bs.Stadium)
            //  .WithMany(b => b.BookingStadiums)
            //  .HasForeignKey(b => b.StadiumId);

            builder.HasNoKey();

            builder.ToTable("StadiumBooking");

            builder.HasOne(d => d.Booking)
                .WithMany()
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StadiumBooking_Booking");

            builder.HasOne(d => d.Stadium)
                .WithMany()
                .HasForeignKey(d => d.StadiumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StadiumBooking_Stadium");
        }
    }
}
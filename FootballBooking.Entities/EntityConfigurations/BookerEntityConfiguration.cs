using FootballBooking.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBooking.Entities.EntityConfigurations
{
    public class BookerEntityConfiguration : IEntityTypeConfiguration<Booker>
    {
        public void Configure(EntityTypeBuilder<Booker> builder)
        {
            builder.ToTable("Booker");
            builder.HasKey("Id");

            builder
                .HasOne(s => s.Address)
                .WithOne(ad => ad.Booker)
                .HasForeignKey<Address>(ad => ad.BookerId)
                .IsRequired(false);
        }
    }
}
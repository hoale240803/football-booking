using FootballBooking.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBooking.Entities.EntityConfigurations
{
    public class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            //builder.ToTable("Address");

            //builder.HasKey("Id");

            //builder.Property(address => address.Region)
            //    .IsRequired(false);

            //builder.Property(address => address.Street)
            //    .IsRequired(false);

            builder.ToTable("Address");

            builder.HasIndex(e => e.BookerId, "IX_Address_BookerId")
                .IsUnique()
                .HasFilter("([BookerId] IS NOT NULL)");

            builder.HasIndex(e => e.StadiumId, "IX_Address_StadiumId")
                .IsUnique()
                .HasFilter("([StadiumId] IS NOT NULL)");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasOne(d => d.Booker)
                .WithOne(p => p.Address)
                .HasForeignKey<Address>(d => d.BookerId)
                .HasConstraintName("FK_Address_User");

            builder.HasOne(d => d.Stadium)
                .WithOne(p => p.Address)
                .HasForeignKey<Address>(d => d.StadiumId);
        }
    }
}
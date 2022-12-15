using FootballBooking.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBooking.Entities.EntityConfigurations
{
    public class StadiumEntityConfiguration : IEntityTypeConfiguration<Stadium>
    {
        public void Configure(EntityTypeBuilder<Stadium> builder)
        {
            builder.ToTable("Stadium");

            builder.HasKey("Id");

            builder
                .HasOne(stadium => stadium.StadiumOwner)
                .WithMany(stadiOwner => stadiOwner.Stadiums)
                .HasForeignKey(stadiOwner => stadiOwner.StadiumOwnerId);

            builder
                .HasOne(a => a.Address)
                .WithOne(s => s.Stadium)
                .HasForeignKey<Address>(s => s.StadiumId)
                .IsRequired(false);
        }
    }
}
using FootballBooking.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBooking.Entities.EntityConfigurations
{
    public class StadiumEntityConfiguration : IEntityTypeConfiguration<Stadium>
    {
        public void Configure(EntityTypeBuilder<Stadium> builder)
        {
            //builder.ToTable("Stadium");

            //builder.HasKey("Id");

            //builder
            //    .HasOne(a => a.Address)
            //    .WithOne(s => s.Stadium)
            //    .HasForeignKey<Address>(s => s.StadiumId)
            //    .IsRequired(false);

            builder.ToTable("Stadium");

            builder.HasIndex(e => e.StadiumOwnerId, "IX_Stadium_StadiumOwnerId");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Name).HasMaxLength(255);

            //builder.HasOne(d => d.StadiumOwner)
            //    .WithMany(p => p.)
            //    .HasForeignKey(d => d.StadiumOwnerId);
        }
    }
}
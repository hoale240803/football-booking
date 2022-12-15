using FootballBooking.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBooking.Entities.EntityConfigurations
{
    public class StadiumOwnerEntityConfiguration : IEntityTypeConfiguration<StadiumOwner>
    {
        public void Configure(EntityTypeBuilder<StadiumOwner> builder)
        {
            builder.ToTable("StadiumOwner");

            builder.HasKey("Id");
        }
    }
}
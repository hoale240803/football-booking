using FootballBooking.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBooking.Entities.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.ToTable("User");

            //builder.HasKey("Id");

            //builder
            //.HasOne(s => s.Address)
            //.WithOne(ad => ad.Booker)
            //.IsRequired(false);
            builder.ToTable("User");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.HashedPassword).HasMaxLength(255);

            builder.Property(e => e.UserName).HasMaxLength(255);
            builder.Property(e => e.FirstName).HasMaxLength(255);
            builder.Property(e => e.PhoneNumber).HasMaxLength(255).IsRequired(false);
            builder.Property(e => e.UserType);
        }
    }
}
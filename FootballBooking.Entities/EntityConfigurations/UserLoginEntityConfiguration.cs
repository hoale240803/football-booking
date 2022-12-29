using FootballBooking.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBooking.Entities.EntityConfigurations
{
    public class UserLoginEntityConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {

            builder.ToTable("UserLogin");

            builder.HasKey(t => t.Id);  

            builder.Property(e => e.HashedPassword).HasMaxLength(255);

            builder.Property(e => e.UserName).HasMaxLength(255);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class AddressDbMap : EntityTypeConfiguration<Address>
    {
        public override void Map(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.AddressId);

            builder.Property(x => x.Address1).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Address2).IsRequired().HasMaxLength(250);

            builder.Property(x => x.City).IsRequired().HasMaxLength(50).HasDefaultValue("HYDERABAD");
            builder.Property(x => x.State).IsRequired().HasMaxLength(50).HasDefaultValue("TELANGANA");
            builder.Property(x => x.Country).IsRequired().HasMaxLength(50).HasDefaultValue("INDIA");
            builder.Property(x => x.PostCode).IsRequired();
        }
    }
}

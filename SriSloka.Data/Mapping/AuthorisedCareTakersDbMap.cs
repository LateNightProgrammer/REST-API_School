using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class AuthorisedCareTakersDbMap : EntityTypeConfiguration<AuthorisedCareTakers>
    {
        public override void Map(EntityTypeBuilder<AuthorisedCareTakers> builder)
        {
            builder.HasKey(x => x.AuthorisedCareTakersId);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(12);
            builder.Property(x => x.Relationship).IsRequired().HasMaxLength(50);
        }
    }
}

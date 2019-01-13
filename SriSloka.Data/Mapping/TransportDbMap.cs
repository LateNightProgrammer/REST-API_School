using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class TransportDbMap : EntityTypeConfiguration<Transport>
    {
        public override void Map(EntityTypeBuilder<Transport> builder)
        {
            builder.Property(x => x.DistanceInKms).IsRequired();
        }
    }
}

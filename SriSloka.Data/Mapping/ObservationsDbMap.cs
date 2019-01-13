using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class ObservationsDbMap : EntityTypeConfiguration<Observations>
    {
        public override void Map(EntityTypeBuilder<Observations> builder)
        {
            builder.HasKey(x => x.ObservationsId);

            builder.Property(x => x.Notes).HasMaxLength(500).IsRequired();

            builder.Property(x => x.InsertedTime).IsRequired();

            builder.Property(x => x.UpdatedTime).IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class LiabilitiesDbMap : EntityTypeConfiguration<Liabilities>
    {
        public override void Map(EntityTypeBuilder<Liabilities> builder)
        {
            builder.HasKey(x => x.LiabilitiesId);

            builder.Property(x => x.AmountPayable).IsRequired();

            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.Property(x => x.InsertedTime).IsRequired();

            builder.Property(x => x.UpdatedTime).IsRequired();
        }
    }
}

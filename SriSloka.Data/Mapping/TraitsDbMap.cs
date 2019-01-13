using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class TraitsDbMap :EntityTypeConfiguration<Traits>
    {
        public override void Map(EntityTypeBuilder<Traits> builder)
        {
            builder.HasKey(x => x.TraitsId);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}

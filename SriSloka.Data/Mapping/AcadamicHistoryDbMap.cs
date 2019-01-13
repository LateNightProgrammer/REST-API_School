using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class AcadamicHistoryDbMap: EntityTypeConfiguration<AcadamicHistory>
    {
        public override void Map(EntityTypeBuilder<AcadamicHistory> builder)
        {
            builder.HasKey(x => x.AcadamicHistoryId);
        }
    }
}

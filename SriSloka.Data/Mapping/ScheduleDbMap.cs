using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class ScheduleDbMap : EntityTypeConfiguration<Schedule>
    {
        public override void Map(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.ScheduleId);

            builder.Property(x => x.EventName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.From).IsRequired();

            builder.Property(x => x.To).IsRequired();
        }
    }
}

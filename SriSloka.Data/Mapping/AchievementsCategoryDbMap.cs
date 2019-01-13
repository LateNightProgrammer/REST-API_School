using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class AchievementsCategoryDbMap : EntityTypeConfiguration<AchievementsCategory>
    {
        public override void Map(EntityTypeBuilder<AchievementsCategory> builder)
        {
            builder.HasKey(x => x.AchievementsCategoryId);

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
        }
    }
}

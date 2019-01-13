using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class AchievementsDbMap : EntityTypeConfiguration<Achievements>
    {
        public override void Map(EntityTypeBuilder<Achievements> builder)
        {
            builder.HasKey(x => x.AchievementsId);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            
        }
    }
}

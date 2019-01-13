using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class HomeworkDbMap: EntityTypeConfiguration<Homework>
    {
        public override void Map(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(x => x.HomeworkId);

            builder.Property(x => x.CreatedDateTime).IsRequired().HasColumnType("Date");

            builder.Property(x => x.LastDateToSubmit).IsRequired().HasColumnType("Date");

            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        }
    }
}

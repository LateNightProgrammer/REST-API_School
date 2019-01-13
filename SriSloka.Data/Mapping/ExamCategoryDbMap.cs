using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class ExamCategoryDbMap : EntityTypeConfiguration<ExamCategory>
    {
        public override void Map(EntityTypeBuilder<ExamCategory> builder)
        {
            builder.HasKey(x => x.ExamCategoryId);

            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(100);
        }
    }
}

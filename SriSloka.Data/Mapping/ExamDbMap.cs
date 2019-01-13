using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class ExamDbMap: EntityTypeConfiguration<Exam>
    {
        public override void Map(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(x => x.ExamId);

            builder.Property(x => x.ExamDate).IsRequired();

            builder.Property(x => x.MaximumMarks).IsRequired();

            builder.Property(x => x.MinimumMarks).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);

            builder.Property(x => x.InsertedTime).IsRequired();

            builder.Property(x => x.UpdatedTime).IsRequired();
        }
    }
}

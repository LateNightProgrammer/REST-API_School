using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class ExamResultsDbMap : EntityTypeConfiguration<ExamResults>
    {
        public override void Map(EntityTypeBuilder<ExamResults> builder)
        {
            builder.HasKey(x => x.ExamResultsId);

            builder.Property(x => x.Grade).IsRequired();

            builder.Property(x => x.Marks).IsRequired();

            builder.Property(x => x.ResultsPublishedDate).IsRequired().HasColumnType("Date");

            builder.Property(x => x.Remarks).HasMaxLength(150);
        }
    }
}

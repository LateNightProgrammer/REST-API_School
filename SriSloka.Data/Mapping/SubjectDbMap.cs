using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class SubjectDbMap : EntityTypeConfiguration<Subject>
    {
        public override void Map(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.SubjectId);

            builder.Property(x => x.SubjectName).HasMaxLength(30).IsRequired();
        }
    }
}

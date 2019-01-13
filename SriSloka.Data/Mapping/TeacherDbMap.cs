using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class TeacherDbMap : EntityTypeConfiguration<Teacher>
    {
        public override void Map(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.TeacherId);
            builder.Property(x => x.YearsOfExperience).IsRequired();
        }
    }
}

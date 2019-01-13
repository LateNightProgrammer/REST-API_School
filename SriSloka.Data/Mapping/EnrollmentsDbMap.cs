using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class EnrollmentsDbMap : EntityTypeConfiguration<Enrollments>
    {
        public override void Map(EntityTypeBuilder<Enrollments> builder)
        {
            builder.HasKey(x => x.EnrollmentsId);
            builder.Property(x => x.EnrollmentDate).HasColumnType("Date").IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class StudentDetailsDbMap : EntityTypeConfiguration<StudentDetails>
    {
        public override void Map(EntityTypeBuilder<StudentDetails> builder)
        {
            builder.Property(x => x.FatherFirstname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FatherLastname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MotherFirstname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MotherLastname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FatherMobileNumber).IsRequired().HasMaxLength(15);
            builder.Property(x => x.MotherMobileNumber).HasMaxLength(15);
            builder.Property(x => x.FatherWorkingAs).HasMaxLength(50);
            builder.Property(x => x.MotherWokringAs).HasMaxLength(50);
            builder.Property(x => x.PreviousSchoolName).HasMaxLength(50);
            builder.Property(x => x.ReasonForChange).HasMaxLength(150);
            builder.Property(x => x.ReasonForLeaving).HasMaxLength(150);
        }
    }
}

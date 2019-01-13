using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class StudentDbMap : EntityTypeConfiguration<Student>
    {
        public override void Map(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentId);

            builder.Property(x => x.Firstname).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Sex).IsRequired();

            builder.Property(x => x.DateOfBirth).IsRequired().HasColumnType("Date");

            builder.Property(x => x.InsertedTime).IsRequired();

            builder.Property(x => x.UpdatedTime).IsRequired();

            builder.HasOne(x => x.StudentDetails).WithOne(s => s.Student);
        }
    }
}

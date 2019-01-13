using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class SalaryDbMap : EntityTypeConfiguration<Salary>
    {
        public override void Map(EntityTypeBuilder<Salary> builder)
        {
            builder.HasKey(x => x.SalaryId);

            builder.Property(x => x.SalaryStartDate).IsRequired().HasColumnType("Date");

            builder.Property(x => x.MonthlySalary).IsRequired();
        }
    }
}

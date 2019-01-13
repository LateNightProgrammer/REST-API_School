using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class TermsDbMap : EntityTypeConfiguration<Terms>
    {
        public override void Map(EntityTypeBuilder<Terms> builder)
        {
            builder.HasKey(x => x.TermsId);

            builder.Property(x => x.AcadamicYear).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            builder.Property(x => x.End).IsRequired().HasColumnType("Date");

            builder.Property(x => x.Start).IsRequired().HasColumnType("Date");
        }
    }
}

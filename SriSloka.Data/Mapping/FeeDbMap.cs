using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class FeeDbMap : EntityTypeConfiguration<Fee>
    {
        public override void Map(EntityTypeBuilder<Fee> builder)
        {
            builder.HasKey(x => x.FeeId);

            builder.Property(x => x.ActualAmountPaid).IsRequired();

            builder.Property(x => x.AmountPayable).IsRequired();

            builder.Property(x => x.InsertedTime).IsRequired();

            builder.Property(x => x.UpdatedTime).IsRequired();
        }
    }
}

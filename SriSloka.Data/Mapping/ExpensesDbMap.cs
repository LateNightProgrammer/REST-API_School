using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class ExpensesDbMap: EntityTypeConfiguration<Expenses>
    {
        public override void Map(EntityTypeBuilder<Expenses> builder)
        {
            builder.HasKey(x => x.ExpensesId);

            builder.Property(x => x.Amount).IsRequired();

            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(25);

            builder.Property(x => x.InsertedTime).IsRequired();

            builder.Property(x => x.UpdatedTime).IsRequired();
        }
    }
}

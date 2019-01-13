using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SriSloka.Data
{
    public abstract class EntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
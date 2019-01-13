using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class PhotosDbMap : EntityTypeConfiguration<Photos>
    {
        public override void Map(EntityTypeBuilder<Photos> builder)
        {
            builder.HasKey(x => x.PhotosId);

            builder.Property(x => x.Photo).IsRequired();
        }
    }
}

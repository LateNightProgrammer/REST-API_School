using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class ApplicationUserDbMap : EntityTypeConfiguration<ApplicationUser>
    {
      public override void Map(EntityTypeBuilder<ApplicationUser> builder)
      {
        builder.ToTable("Users");
        builder.HasMany(u => u.Tokens).WithOne(i => i.User);
      }
    }
}

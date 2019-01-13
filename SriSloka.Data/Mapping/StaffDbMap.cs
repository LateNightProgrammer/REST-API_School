using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class StaffDbMap : EntityTypeConfiguration<Staff>
    {
        public override void Map(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(x => x.StaffId);

            builder.Property(x => x.HireDate).IsRequired().HasColumnType("Date");

            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);

            builder.Property(x => x.DateOfBirth).IsRequired().HasColumnType("Date");

            builder.Property(x => x.AadhaarCardNo).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Firstname).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(50);

            builder.Property(x => x.FatherName).HasMaxLength(50);

            builder.Property(x => x.MobileNo).IsRequired();

            builder.Property(x => x.Sex).IsRequired();
        }
    }
}

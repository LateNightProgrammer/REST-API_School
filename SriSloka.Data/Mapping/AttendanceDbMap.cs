using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SriSloka.Model;

namespace SriSloka.Data.Mapping
{
    public class AttendanceDbMap : EntityTypeConfiguration<Attendance>
    {
        public override void Map(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(x => x.AttendanceId);

            builder.Property(x => x.Date).IsRequired().HasColumnType("Date");

            builder.Property(x => x.IsPresent).IsRequired().HasDefaultValue("false");

            builder.Property(x => x.ReasonForAbsence).HasMaxLength(250);
        }
    }
}

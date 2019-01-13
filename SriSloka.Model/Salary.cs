using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SriSloka.Model
{
    public class Salary:TrackableEntity
    {
        [Key]
        public int SalaryId { get; set; }

        public DateTime SalaryStartDate { get; set; }

        public Decimal MonthlySalary { get; set; }

        public Decimal? YearlyBonus { get; set; }

        public Decimal? Allowance { get; set; }

        [ForeignKey("Staff")]
        public int StaffId { get; set; }
    }
}

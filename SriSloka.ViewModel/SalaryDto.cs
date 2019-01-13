using System;
using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class SalaryDto:TrackableEntity
    {
        public int SalaryId { get; set; }

        public DateTime SalaryStartDate { get; set; }

        public Decimal MonthlySalary { get; set; }

        public Decimal? YearlyBonus { get; set; }

        public Decimal? Allowance { get; set; }
        
        public int StaffId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SriSloka.Model
{
    public class Liabilities: TrackableEntity
    {
        [Key]
        public int LiabilitiesId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal AmountPayable { get; set; }
        
        public RecurringFrequency Frequency { get; set; }

        [ForeignKey("ExpenseCategory")]
        public int ExpenseCategoryId { get; set; }

        public bool IsActive { get; set; }
    }
}

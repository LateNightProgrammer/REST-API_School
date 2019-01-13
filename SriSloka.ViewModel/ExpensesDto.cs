using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class ExpensesDto: TrackableEntity
    {
        public int ExpensesId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public bool IsPaid { get; set; }

        public bool IsProofSubmitted { get; set; }

        public bool IsRecurring { get; set; }

        public RecurringFrequency Frequency { get; set; }
        
        public int ExpenseCategoryId { get; set; }
    }

    public enum RecurringFrequency
    {
        OneTimePayment,
        Weekly,
        Forthnightly,
        Monthly,
        Yearly
    }
}

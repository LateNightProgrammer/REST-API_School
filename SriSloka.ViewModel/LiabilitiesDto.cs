using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class LiabilitiesDto: TrackableEntity
    {
        public int LiabilitiesId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal AmountPayable { get; set; }
        
        public RecurringFrequency Frequency { get; set; }
        
        public int ExpenseCategoryId { get; set; }

        public bool IsActive { get; set; }
    }
}

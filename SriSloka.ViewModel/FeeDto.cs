using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class FeeDto: TrackableEntity
    {
        public int FeeId { get; set; }

        public decimal ActualAmountPaid { get; set; }
     
        public int TermId { get; set; }

        public decimal AmountPayable { get; set; }

        public bool IsFullyPaid { get; set; }
        
        public int StudentId { get; set; }

        public bool IsDelete { get; set; }
    }
}

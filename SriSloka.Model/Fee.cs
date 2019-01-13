using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SriSloka.Model
{
    public class Fee: TrackableEntity
    {
        [Key]
        public int FeeId { get; set; }

        public decimal ActualAmountPaid { get; set; }

        [ForeignKey("Term")]
        public int TermId { get; set; }

        public decimal AmountPayable { get; set; }

        public bool IsFullyPaid { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public bool IsDelete { get; set; }
    }
}

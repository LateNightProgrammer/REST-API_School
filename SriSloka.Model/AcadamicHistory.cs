using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SriSloka.Model
{
    public class AcadamicHistory
    {
        public AcadamicHistory()
        { 
            ExamResults = new List<ExamResults>();
            Achivements = new List<Achievements>();
            Observations = new List<Observations>();
        }
        [Key]
        public int AcadamicHistoryId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public int AcadamicYear { get; set; }

        public virtual ICollection<ExamResults> ExamResults { get; set; }

        public virtual ICollection<Achievements> Achivements { get; set; }

        public virtual ICollection<Observations> Observations { get; set; }
    }
}

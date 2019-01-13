using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SriSloka.Model
{
    public class Exam : TrackableEntity
    {
        [Key]
        public int ExamId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        [ForeignKey("Standard")]
        public int StandardId { get; set; }

        [ForeignKey("ExamCategory")]
        public int ExamCategoryId { get; set; }

        public Decimal MinimumMarks { get; set; }

        public Decimal MaximumMarks { get; set; }

        public DateTime ExamDate { get; set; }

        public int TeacherId { get; set; }

        public DateTime UpdatedDate { get; set; }
        
        public virtual ExamCategory ExamCategory { get; set; }

        public bool IsActive { get; set; }
    }
}

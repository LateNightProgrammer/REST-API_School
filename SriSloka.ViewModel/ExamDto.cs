using System;

namespace SriSloka.ViewModel
{
    public class ExamDto 
    {
        public int ExamId { get; set; }

        public string Name { get; set; }
     
        public int SubjectId { get; set; }
        
        public int StandardId { get; set; }
        
        public int ExamCategoryId { get; set; }

        public Decimal MinimumMarks { get; set; }

        public Decimal MaximumMarks { get; set; }

        public DateTime ExamDate { get; set; }

        public int TeacherId { get; set; }

        public DateTime UpdatedDate { get; set; }
        
        public ExamCategoryDto ExamCategory { get; set; }

        public bool IsActive { get; set; }
    }
}

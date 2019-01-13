using System;
using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class ExamResultsDto: TrackableEntity
    {
        public int ExamResultsId { get; set; }
        
        public int ExamId { get; set; }
        
        public int AcadamicHistoryId { get; set; }

        public decimal Marks { get; set; }
        
        public int TeacherId { get; set; }

        public Grade Grade { get; set; }

        public bool IsPublished { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        public bool IsFailed { get; set; }

        public string Remarks { get; set; }

        public DateTime ResultsPublishedDate { get; set; }
    }
    public enum Grade
    {
        A, B, C, D, F
    }
}

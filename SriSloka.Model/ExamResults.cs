using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SriSloka.Model
{
    public class ExamResults: TrackableEntity
    {
        [Key]
        public int ExamResultsId { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        [ForeignKey("AcadamicHistory")]
        public int AcadamicHistoryId { get; set; }

        public decimal Marks { get; set; }

        [ForeignKey("Teacher")]
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

using System.Collections.Generic;
using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class AcadamicHistoryDto
    {
        public AcadamicHistoryDto()
        { 
            ExamResults = new List<ExamResults>();
            Achivements = new List<Achievements>();
            Observations = new List<Observations>();
        }
        
        public int AcadamicHistoryId { get; set; }

        public int StudentId { get; set; }

        public int AcadamicYear { get; set; }

        public  ICollection<ExamResults> ExamResults { get; set; }

        public  ICollection<Achievements> Achivements { get; set; }

        public  ICollection<Observations> Observations { get; set; }
    }
}

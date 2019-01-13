using System.Collections.Generic;
using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class TeacherDto
    {
        public TeacherDto()
        {
            Subjects = new List<Subject>();

            Standards = new List<Standard>();

            Schedule = new List<Schedule>();

            ExamResults = new List<ExamResults>();

            Observations = new List<Observations>();
        }
        
        public int TeacherId { get; set; }

        public decimal YearsOfExperience { get; set; }

        public ICollection<Subject> Subjects { get; set; }

        public ICollection<Standard> Standards { get; set; }

        public ICollection<Schedule> Schedule { get; set; }

        public ICollection<ExamResults> ExamResults { get; set; }

        public ICollection<Observations> Observations { get; set; }
    }
}

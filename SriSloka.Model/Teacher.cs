using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SriSloka.Model
{
    public class Teacher
    {
        public Teacher()
        {
            Subjects = new List<Subject>();

            Standards = new List<Standard>();

            Schedule = new List<Schedule>();

            ExamResults = new List<ExamResults>();

            Observations = new List<Observations>();

            Homeworks = new List<Homework>();
        }
        [Key]
        public int TeacherId { get; set; }

        public decimal YearsOfExperience { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<Standard> Standards { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }

        public virtual ICollection<ExamResults> ExamResults { get; set; }

        public virtual ICollection<Observations> Observations { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SriSloka.Model
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        public string Description { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        [ForeignKey("Standard")]
        public int StandardId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastDateToSubmit { get; set; }

        [ForeignKey("Subjects")]
        public int SubjectsId { get; set; }
    }
}

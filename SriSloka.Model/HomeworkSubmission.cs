using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SriSloka.SharedKernel;

namespace SriSloka.Model
{
    public class HomeworkSubmission : IStateObject
    {
        [Key, ForeignKey("Homework")]
        public int HomeworkId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public DateTime SubmissionDate { get; set; }

        public Grade Grade { get; set; }
        
        public virtual Homework Homework { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        private HomeworkSubmission(){}

        public HomeworkSubmission(int studentId)
        {
            StudentId = studentId;
        }
    }
}

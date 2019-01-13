using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SriSloka.SharedKernel;

namespace SriSloka.Model
{
    public class Enrollments : IStateObject
    {
        [Key]
        public int EnrollmentsId { get; set; }

        [ForeignKey("Standard")]
        public int StandardId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public bool IsActive { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        public Enrollments(int standardId)
        {
            StandardId = standardId;
            IsActive = true;
        }

        private Enrollments() { }
    }
}

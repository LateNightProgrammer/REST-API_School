using System;
using System.ComponentModel.DataAnnotations;

namespace SriSloka.ViewModel
{
    public class StudentsEnrollmentsDto
    {
        public int EnrollmentsId { get; set; }
     
        [Required]
        public int StandardId { get; set; }
     
        [Required]
        public int StudentId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public bool IsActive { get; set; }
    }
}

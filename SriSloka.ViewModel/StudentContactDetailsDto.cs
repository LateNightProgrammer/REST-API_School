using System;
using System.ComponentModel.DataAnnotations;
using SriSloka.Model;

namespace SriSloka.ViewModel
{
    [Serializable]
    public class StudentContactDetailsDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FatherFirstname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FatherLastname { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string FatherWorkingAs { get; set; }
        
        public Qualification FatherHighestQualification { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string MotherFirstname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string MotherLastname { get; set; }

        public Qualification MotherHighestQualification { get; set; }
        
        [StringLength(50, MinimumLength = 3)]
        public string MotherWokringAs { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 10)]
        public string FatherMobileNumber { get; set; }

        [StringLength(15, MinimumLength = 10)]
        public string MotherMobileNumber { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string PreviousSchoolName { get; set; }

        [StringLength(150, MinimumLength = 3)]
        public string ReasonForChange { get; set; }

        [StringLength(150, MinimumLength = 3)]
        public string ReasonForLeaving { get; set; }
    }
}
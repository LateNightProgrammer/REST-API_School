using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SriSloka.SharedKernel;

namespace SriSloka.Model
{
    public class StudentDetails : IStateObject
    {
        [Key, ForeignKey("Student")]
        public int StudentId { get; set; }

        public string FatherFirstname { get; set; }
        
        public string FatherLastname { get; set; }

        public string FatherWorkingAs { get; set; }

        public Qualification FatherHighestQualification { get; set; }

        public string MotherFirstname { get; set; }

        public string MotherLastname { get; set; }

        public Qualification MotherHighestQualification { get; set; }

        public string MotherWokringAs { get; set; }

        public string FatherMobileNumber { get; set; }

        public string MotherMobileNumber { get; set; }

        public string PreviousSchoolName { get; set; }

        public string ReasonForChange { get; set; }

        public string ReasonForLeaving { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        
        public virtual Address Address { get; set; }
        
        public virtual Student Student { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}

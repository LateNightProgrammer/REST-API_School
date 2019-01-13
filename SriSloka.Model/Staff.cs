using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SriSloka.Model
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string Email { get; set; }

        public string PlaceOfBirth { get; set; }

        public int MobileNo { get; set; }

        public string AadhaarCardNo { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime LastWorkingDay { get; set; }

        public Gender Sex { get; set; }

        public Qualification HighestQualification { get; set; }

        public string HighestQualificationMajorSubject { get; set; }

        public bool IsPoliceVerificationDone { get; set; }

        public bool IsWorkingForUs { get; set; }

        public virtual Salary Salary { get; set; }

        public virtual Address Address { get; set; }

        public virtual Photos Photos { get; set; }

        public virtual ICollection<Attendance> StaffAttendance { get; set; }
    }

    public enum Qualification
    {
        Metric,
        Intermediate,
        Graduation,
        PostGraduation,
        Phd
    }
}

using System;
using System.Collections.Generic;
using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class StaffDto
    {
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

        /// Is currently working for us?
        public bool IsWorkingForUs { get; set; }

        public Salary Salary { get; set; }

        public Address Address { get; set; }

        public Photos Photos { get; set; }

        public ICollection<Attendance> StaffAttendance { get; set; }
    }
    
}

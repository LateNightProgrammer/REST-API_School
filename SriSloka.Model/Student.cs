using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SriSloka.Model
{
    public class Student : TrackableEntity
    {
        [Key]
        public int StudentId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Sex { get; set; }

        public bool IsActive { get; set; }

        public virtual StudentDetails StudentDetails { get; set; }

        public virtual ICollection<Enrollments> Enrollments { get; set; }

        public virtual ICollection<Transport> Transport { get; set; }

        public virtual AcadamicHistory AcadamicHistory { get; set; }

        public virtual Photos Photos { get; set; }

        public virtual ICollection<Attendance> StudentAttendance { get; set; }

        public virtual ICollection<AuthorisedCareTakers> CareTakers { get; set; }

        public virtual ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; }

        public virtual ICollection<Fee> Fees { get; set; }

        public Student(string firstName, string lastName, DateTime dob, Gender sex)
        {
            Firstname = firstName;
            Lastname = lastName;
            DateOfBirth = dob;
            Sex = sex;
            InsertedTime = DateTime.Now;
            UpdatedTime = DateTime.Now;
            IsActive = true;
            StudentDetails = new StudentDetails {Address = new Address()};
        }

        /// <summary>
        /// Entity Framework need a parameterless constructor.
        /// </summary>
        private Student() { }
    }

    public enum Gender
    {
        Male, Female
    }
}

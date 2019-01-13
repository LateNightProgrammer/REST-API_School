using System;
using System.ComponentModel.DataAnnotations;
using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class StudentDto 
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Sex { get; set; }

        public bool IsActive { get; set; }

        public StudentContactDetailsDto StudentContactDetails { get; set; }

        public AddressDto AddressDetails { get; set; }
        public StudentDto(string firstName, string lastName, DateTime dob, Gender sex)
        {
            Firstname = firstName;
            Lastname = lastName;
            DateOfBirth = dob;
            Sex = sex;
            IsActive = true;

            StudentContactDetails = new StudentContactDetailsDto();
            AddressDetails = new AddressDto();
        }

        public StudentDto()
        {
            StudentContactDetails = new StudentContactDetailsDto();
            AddressDetails = new AddressDto();
        }
    }
}

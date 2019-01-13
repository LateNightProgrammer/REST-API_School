using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SriSloka.SharedKernel;

namespace SriSloka.Model
{
    public class AuthorisedCareTakers : IStateObject
    {
        [Key]
        public int AuthorisedCareTakersId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Relationship { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        public AuthorisedCareTakers(int studentId)
        {
            StudentId = studentId;
        }
        private AuthorisedCareTakers()
        {

        }
    }
}

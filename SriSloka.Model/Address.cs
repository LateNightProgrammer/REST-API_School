using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SriSloka.SharedKernel;

namespace SriSloka.Model
{
    public class Address : IStateObject
    {
        [Key]
        public int AddressId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string State { get; set; }

        public string City { get; set; }
        
        public string Country { get; set; }

        public int PostCode { get; set; }

        [ForeignKey("Student")]
        public int? StudentId { get; set; }

        [ForeignKey("Staff")]
        public int? StaffId { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        public Address(){}

        public Address(string address1, string address2, int postcode)
        {
            Address1 = address1;
            Address2 = address2;
            City = "Hyderabad";
            State = "Telangana";
            Country = "INDIA";
            PostCode = postcode;
        }
    }
}

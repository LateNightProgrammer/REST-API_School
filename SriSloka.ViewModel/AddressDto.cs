using System;

namespace SriSloka.ViewModel
{
    [Serializable]
    public class AddressDto
    {
        public int AddressId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int PostCode { get; set; }

        public AddressDto(string address1, string address2, int postcode)
        {
            Address1 = address1;
            Address2 = address2;
            City = "Hyderabad";
            State = "Telangana";
            Country = "INDIA";
            PostCode = postcode;
        }

        public AddressDto() { }
    }
}

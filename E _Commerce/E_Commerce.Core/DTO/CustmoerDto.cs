using System.ComponentModel.DataAnnotations;

namespace E__Commerce.DTO
{
    public class CustmoerDto
    {
        public int IdCustmoerdto { get; set; }

        public string FirstNameCustmoerdto { get; set; }
        public string LastNameCustmoerdto { get; set; }
        [EmailAddress]
        public string EmailCustmoerdto { get; set; }
        [Phone]
        public string PhoneNumberCustmoerdto { get; set; }
        public string CityCustmoerdto { get; set; }
        public string StreetAddressCustmoerdto { get; set; }
    }
}

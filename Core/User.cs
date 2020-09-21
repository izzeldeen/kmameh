
using Microsoft.AspNetCore.Identity;


namespace Core
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public int? PictureID { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
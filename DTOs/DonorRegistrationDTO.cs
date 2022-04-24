using System;

namespace BDMS_APIs.DTOs
{
    public class DonorRegistrationDTO
    {
        public string NIC { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime DOB { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
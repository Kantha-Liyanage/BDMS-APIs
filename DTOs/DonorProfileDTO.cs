using System;
using BDMS_APIs.Models;

namespace BDMS_APIs.DTOs
{
    public class DonorProfileDTO
    {
        public string NIC { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public DateTime DOB { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public void MapTo(Donor donor)
        {
            donor.NIC = NIC;
            donor.FirstName = FirstName;
            donor.LastName = LastName;
            donor.District = District;
            donor.City = City;
            donor.DOB = DOB;
            donor.BloodGroup = BloodGroup;
            donor.Gender = Gender;
            donor.Email = Email;
            donor.Phone = Phone;
        }
    }
}
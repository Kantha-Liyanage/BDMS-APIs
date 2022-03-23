using System;
using BDMS_APIs.Models;

namespace BDMS_APIs.DTOs
{
    public class HospitalUpdateDTO
    {
        public string HospitalID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string City { get; set; }

        public void MapTo(Hospital hospital)
        {
            hospital.HospitalID = HospitalID;
            hospital.Name = Name;
            hospital.Address = Address;
            hospital.District = District;
            hospital.ContactNo1 = ContactNo1;
            hospital.ContactNo2 = ContactNo2;
            hospital.City = City;
        }
    }
}
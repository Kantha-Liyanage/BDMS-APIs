using System;

namespace BDMS_APIs.DTOs
{
    public class HospitalRegistrationDTO
    {
        public string HospitalID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
    }
}
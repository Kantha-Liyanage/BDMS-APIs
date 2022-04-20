using System;

namespace BDMS_APIs.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentID { get; set; }
        public string CampaignID { get; set; }
        public string DonorNIC { get; set; }
        public int TimeSlot { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
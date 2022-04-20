using System;
using BDMS_APIs.Models;

namespace BDMS_APIs.DTOs
{
    public class DonationCampaignDTO
    {
        public string CampaignID { get; set; }
        public string HospitalID { get; set; }
        public string CampaignName { get; set; }
        public string[] BloodGroups { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public DateTime DateAndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public int TimeSlots { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        public void MapTo(DonationCampaign donationCampaign)
        {
            donationCampaign.CampaignName = CampaignName;
            donationCampaign.BloodGroups = BloodGroups;
            donationCampaign.City = City;
            donationCampaign.Location = Location;
            donationCampaign.DateAndTime = DateAndTime;
            donationCampaign.Duration = Duration;
            donationCampaign.TimeSlots = TimeSlots;
            donationCampaign.Status = Status;
            donationCampaign.LastModifiedDateTime = LastModifiedDateTime;
        }
    }

}
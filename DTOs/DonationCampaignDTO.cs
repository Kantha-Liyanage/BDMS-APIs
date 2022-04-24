using System;
using BDMS_APIs.Models;

namespace BDMS_APIs.DTOs
{
    public class DonationCampaignDTO
    {
        public string CampaignID { get; set; }
        public string HospitalID { get; set; }
        public string CampaignName { get; set; }
        public string BloodGroups { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public DateTime CampaignDate { get; set; }
        public int TimeSlots { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public void MapTo(DonationCampaign donationCampaign)
        {
            donationCampaign.CampaignName = CampaignName;
            donationCampaign.BloodGroups = BloodGroups;
            donationCampaign.City = City;
            donationCampaign.Location = Location;
            donationCampaign.CampaignDate = CampaignDate;
            donationCampaign.Remarks = Remarks;
            donationCampaign.TimeSlots = TimeSlots;
            donationCampaign.Status = Status;
        }
    }

}
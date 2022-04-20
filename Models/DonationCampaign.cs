using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDMS_APIs.Models
{

    [Table("DonationCampaign")]
    public class DonationCampaign
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string CampaignID { get; set; }
        public string HospitalID { get; set; }
        public string CampaignName { get; set; }
        public string BloodGroups { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public DateTime DateAndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public int TimeSlots { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
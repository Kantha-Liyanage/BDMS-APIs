using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDMS_APIs.Models
{

    [Table("Appointment")]
    public class Appointment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AppointmentID { get; set; }
        public string CampaignID { get; set; }
        public string DonorNIC { get; set; }
        public int TimeSlot { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
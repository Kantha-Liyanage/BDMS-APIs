using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDMS_APIs.Models{

    [Table("Donors")]
    public class Donor{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Key]
        public string NIC {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string District {get;set;}
        public string City {get;set;}
        public string BloodGroup {get;set;}
        public string Gender {get;set;}
        public string PasswordHash {get;set;}
    }
}

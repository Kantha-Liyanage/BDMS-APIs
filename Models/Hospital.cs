using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDMS_APIs.Models{

    [Table("Hospitals")]
    public class Hospital{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Key]
        public string HospitalID {get;set;}
        public string Name {get;set;}
        public string District {get;set;}
        public string City {get;set;}
        public string PasswordHash {get;set;}
    }
}

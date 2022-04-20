using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDMS_APIs.Models
{

    [Table("Hospitals")]
    public class Hospital
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string HospitalID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string City { get; set; }
        public string Password { get; set; }

        public void hashPassword(string plainTextPassword)
        {
            this.Password = BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
        }

        public bool isPasswordCorrect(string plainTextPassword)
        {
            if (BCrypt.Net.BCrypt.Verify(plainTextPassword, this.Password))
            {
                return true;
            }
            return false;
        }
    }
}

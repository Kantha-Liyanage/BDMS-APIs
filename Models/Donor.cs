using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDMS_APIs.Models
{

    [Table("Donors")]
    public class Donor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string NIC { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
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

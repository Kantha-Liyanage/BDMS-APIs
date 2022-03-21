using BDMS_APIs.DTOs;
using BDMS_APIs.Models;
using BDMS_APIs.Providers;
using Microsoft.AspNetCore.Mvc;

namespace BDMS_APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        private readonly DataContext dataContext;

        public AuthController(IJWTAuthenticationManager jWTAuthenticationManager, DataContext dataContext)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
            this.dataContext = dataContext;
        }

        [HttpPost("AuthenticateDonor")]
        public ActionResult AuthenticateDonor(DonorAuthDTO donorAuthDTO)
        {
            Donor donor = this.dataContext.Donors.Find(donorAuthDTO.NIC);
            if (donor == null)
            {
                return NotFound();
            }

            if (donor.isPasswordCorrect(donorAuthDTO.Password))
            {
                //JWT Payload
                DonorAuthResultDTO authResult = new DonorAuthResultDTO();
                authResult.NIC = donor.NIC;
                authResult.FirstName = donor.FirstName;
                authResult.LastName = donor.LastName;

                //Token
                authResult.Token = jWTAuthenticationManager.Authenticate(donor.NIC, UserType.Donor);

                return Ok(authResult);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPatch("ChangePasswordDonor")]
        public ActionResult ChangePasswordDonor(PasswordChangeDTO passwordChangeDTO)
        {
            Donor donor = this.dataContext.Donors.Find(passwordChangeDTO.UserID);
            if (donor == null)
            {
                return NotFound();
            }

            if (donor.isPasswordCorrect(passwordChangeDTO.OldPassword))
            {
                donor.hashPassword(passwordChangeDTO.NewPassword);
                this.dataContext.Donors.Update(donor);
                int rows = this.dataContext.SaveChanges();
                if (rows == 1)
                {
                    return Ok(new MessageDTO("Password changed."));
                }
                return BadRequest(new MessageDTO("No records updated."));
            }
            else
            {
                return BadRequest(new MessageDTO("Incorrect old password."));
            }
        }

        [HttpPost("AuthenticateHospital")]
        public ActionResult AuthenticateHospital(HospitalAuthDTO hospitalAuthDTO)
        {
            Hospital hospital = this.dataContext.Hospitals.Find(hospitalAuthDTO.HospitalID);
            if (hospital == null)
            {
                return NotFound();
            }

            if (hospital.isPasswordCorrect(hospitalAuthDTO.Password))
            {
                //JWT Payload
                HospitalAuthResultDTO authResult = new HospitalAuthResultDTO();
                authResult.HospitalID = hospital.HospitalID;
                authResult.Name = hospital.Name;

                //Token
                authResult.Token = jWTAuthenticationManager.Authenticate(hospital.HospitalID, UserType.Hospital);

                return Ok(authResult);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPatch("ChangePasswordHospital")]
        public ActionResult ChangePasswordHospital(PasswordChangeDTO passwordChangeDTO)
        {
            Hospital hospital = this.dataContext.Hospitals.Find(passwordChangeDTO.UserID);
            if (hospital == null)
            {
                return NotFound();
            }

            if (hospital.isPasswordCorrect(passwordChangeDTO.OldPassword))
            {
                hospital.hashPassword(passwordChangeDTO.NewPassword);
                this.dataContext.Hospitals.Update(hospital);
                int rows = this.dataContext.SaveChanges();
                if (rows == 1)
                {
                    return Ok(new MessageDTO("Password changed."));
                }
                return BadRequest(new MessageDTO("No records updated."));
            }
            else
            {
                return BadRequest(new MessageDTO("Incorrect old password."));
            }
        }

        public enum UserType
        {
            Donor,
            Hospital
        }
    }
}
using BDMS_APIs.DTOs;
using BDMS_APIs.Models;
using BDMS_APIs.Providers;
using Microsoft.AspNetCore.Mvc;

namespace BDMS_APIs.Controllers{
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
            if (donor == null) {
                return NotFound();
            }

            if (donor.PasswordHash.Equals(donorAuthDTO.Password))
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

        [HttpPost("AuthenticateHospital")]
        public ActionResult AuthenticateHospital(HospitalAuthDTO hospitalAuthDTO)
        {
            Hospital hospital = this.dataContext.Hospitals.Find(hospitalAuthDTO.HospitalID);
            if (hospital == null) {
                return NotFound();
            }

            if (hospital.PasswordHash.Equals(hospitalAuthDTO.Password))
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

        public enum UserType{
            Donor,
            Hospital
        }
    }
}
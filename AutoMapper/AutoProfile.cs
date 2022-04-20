using AutoMapper;
using BDMS_APIs.DTOs;
using BDMS_APIs.Models;

namespace BDMS_APIs.AutoMapper
{
    public class AutoProfile : Profile
    {
        public AutoProfile()
        {
            CreateMap<DonorRegistrationDTO, Donor>();
            CreateMap<DonorProfileDTO, Donor>();
            CreateMap<Donor, DonorProfileDTO>();

            CreateMap<HospitalRegistrationDTO, Hospital>();
            CreateMap<HospitalUpdateDTO, Hospital>();
            CreateMap<Hospital, HospitalUpdateDTO>();

            CreateMap<DonationCampaignDTO, DonationCampaign>();
            CreateMap<DonationCampaign, DonationCampaignDTO>();
        }
    }
}
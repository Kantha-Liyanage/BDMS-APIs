using System;
using AutoMapper;
using BDMS_APIs.DTOs;
using BDMS_APIs.Models;
using Microsoft.AspNetCore.Mvc;

namespace BDMS_APIs.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public AppointmentController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult Create([FromBody] AppointmentDTO appointmentDTO)
        {
            try
            {
                Appointment entity = this.mapper.Map<Appointment>(appointmentDTO);
                this.dataContext.Appointments.Add(entity);
                int rows = this.dataContext.SaveChanges();
                if (rows == 1)
                {
                    return Created("", appointmentDTO);
                }
                return BadRequest(new MessageDTO("No records created."));
            }
            catch (Exception er)
            {
                return BadRequest(new MessageDTO(er.InnerException.Message));
            }
        }

        // need to fix

        [HttpGet]
        public ActionResult Read(string campaignID)
        {
            try
            {
                DonationCampaign entity = this.dataContext.DonationCampaigns.Find(campaignID);
                DonationCampaignDTO dto = this.mapper.Map<DonationCampaignDTO>(entity);
                return Ok(dto);
            }
            catch (Exception er)
            {
                return BadRequest(new MessageDTO(er.InnerException.Message));
            }
        }

        [HttpGet("AllOpen")]
        public ActionResult ReadAllOpen()
        {
            return Ok();
        }

        [HttpGet("DonationCampaignOpen")]
        public ActionResult ReadDonationCampaignOpen()
        {
            return Ok();
        }

        [HttpPatch]
        public ActionResult Update([FromBody] DonationCampaignDTO donationCampaignDTO)
        {
            try
            {
                DonationCampaign entity = this.dataContext.DonationCampaigns.Find(donationCampaignDTO.CampaignID);
                donationCampaignDTO.MapTo(entity);
                this.dataContext.DonationCampaigns.Update(entity);
                int rows = this.dataContext.SaveChanges();
                if (rows == 1)
                {
                    return Ok(donationCampaignDTO);
                }
                return BadRequest(new MessageDTO("No records updated."));
            }
            catch (Exception er)
            {
                return BadRequest(new MessageDTO(er.Message));
            }
        }
    }
}
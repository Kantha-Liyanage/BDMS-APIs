using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BDMS_APIs.DTOs;
using BDMS_APIs.Models;
using Microsoft.AspNetCore.Mvc;

namespace BDMS_APIs.Controllers
{
    [Route("api/[controller]")]
    public class DonationCampaignController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public DonationCampaignController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult Create([FromBody] DonationCampaignDTO donationCampaignDTO)
        {
            try
            {
                DonationCampaign entity = this.mapper.Map<DonationCampaign>(donationCampaignDTO);
                this.dataContext.DonationCampaigns.Add(entity);
                int rows = this.dataContext.SaveChanges();
                if (rows == 1)
                {
                    return Created("", donationCampaignDTO);
                }
                return BadRequest(new MessageDTO("No records created."));
            }
            catch (Exception er)
            {
                return BadRequest(new MessageDTO(er.InnerException.Message));
            }
        }

        [HttpGet("HospitalOpenAll")]
        public ActionResult HospitalOpenAll(string hospitalID)
        {
            try
            {
                List<DonationCampaign> donationCampaigns = this.dataContext.DonationCampaigns.Where(campaign => campaign.HospitalID == hospitalID).ToList();
                List<DonationCampaignDTO> outList = new List<DonationCampaignDTO>();
                foreach (var campaign in donationCampaigns)
                {
                    DonationCampaignDTO dto = this.mapper.Map<DonationCampaignDTO>(campaign);
                    outList.Add(dto);
                }
                return Ok(outList);
            }
            catch (Exception er)
            {
                return BadRequest(new MessageDTO(er.InnerException.Message));
            }
        }

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
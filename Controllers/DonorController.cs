using System;
using System.Security.Claims;
using AutoMapper;
using BDMS_APIs.DTOs;
using BDMS_APIs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BDMS_APIs.Controllers
{
    [Route("api/[controller]")]
    public class DonorController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public DonorController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult Create([FromBody] DonorRegistrationDTO donorRegistrationDTO)
        {
            try
            {
                Donor entity = this.mapper.Map<Donor>(donorRegistrationDTO);
                entity.hashPassword(entity.Password);
                this.dataContext.Donors.Add(entity);
                int rows = this.dataContext.SaveChanges();
                if (rows == 1)
                {
                    return Created("", donorRegistrationDTO);
                }
                return BadRequest(new MessageDTO("No records created."));
            }
            catch (Exception er)
            {
                if (er.InnerException != null)
                {
                    return BadRequest(new MessageDTO(er.InnerException.Message));
                }
                else
                {
                    return BadRequest(new MessageDTO(er.Message));
                }
            }
        }

        [HttpGet]
        public ActionResult Read(string nic)
        {
            try
            {
                /*
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    nic = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                }
                */
                Donor entity = this.dataContext.Donors.Find(nic);
                DonorProfileDTO dto = this.mapper.Map<DonorProfileDTO>(entity);
                return Ok(dto);
            }
            catch (Exception er)
            {
                if (er.InnerException != null)
                {
                    return BadRequest(new MessageDTO(er.InnerException.Message));
                }
                else
                {
                    return BadRequest(new MessageDTO(er.Message));
                }
            }
        }

        [HttpPatch]
        public ActionResult Update([FromBody] DonorProfileDTO donorProfileDTO)
        {
            try
            {
                Donor entity = this.dataContext.Donors.Find(donorProfileDTO.NIC);
                donorProfileDTO.MapTo(entity);
                this.dataContext.Donors.Update(entity);
                int rows = this.dataContext.SaveChanges();
                if (rows == 1)
                {
                    return Ok(donorProfileDTO);
                }
                return BadRequest(new MessageDTO("No records updated."));
            }
            catch (Exception er)
            {
                if (er.InnerException != null)
                {
                    return BadRequest(new MessageDTO(er.InnerException.Message));
                }
                else
                {
                    return BadRequest(new MessageDTO(er.Message));
                }
            }
        }
    }
}
using System;
using AutoMapper;
using BDMS_APIs.DTOs;
using BDMS_APIs.Models;
using Microsoft.AspNetCore.Mvc;

namespace BDMS_APIs.Controllers
{
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public HospitalController(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            //Test
        }

        [HttpPost]
        public ActionResult Create([FromBody] HospitalRegistrationDTO hospitalRegistrationDTO)
        {
            try
            {
                Hospital entity = this.mapper.Map<Hospital>(hospitalRegistrationDTO);
                entity.hashPassword(entity.Password);
                this.dataContext.Hospitals.Add(entity);
                int rows = this.dataContext.SaveChanges();
                if (rows == 1)
                {
                    return Created("", hospitalRegistrationDTO);
                }
                return BadRequest(new MessageDTO("No records created."));
            }
            catch (Exception er)
            {
                return BadRequest(new MessageDTO(er.InnerException.Message));
            }
        }

        [HttpPatch]
        public ActionResult Update([FromBody] HospitalUpdateDTO hospitalUpdateDTO)
        {
            try
            {
                Hospital entity = this.mapper.Map<Hospital>(hospitalUpdateDTO);
                this.dataContext.Hospitals.Update(entity);
                int rows = this.dataContext.SaveChanges();
                if (rows == 1)
                {
                    return Ok(hospitalUpdateDTO);
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
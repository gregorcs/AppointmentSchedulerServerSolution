﻿using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.Models;
using AppointmentSchedulerServer.Repositories;
using AppointmentSchedulerServer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentDAO _appointmentDAO;

        public AppointmentController(IAppointmentDAO appointmentDAO)
        {
            _appointmentDAO = appointmentDAO;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> FindAllByAccountIdAsync(int id)
        {
            var result = await _appointmentDAO.FindAllByAccountId(id);
            return result == null
                ? BadRequest(ControllerErrorMessages.AppointmentError)
                : Ok(result);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        //todo figure out how to get appointment, employee, account into controller -> repository
        [HttpPost]
        public async void Post([FromBody] AppointmentDTO appointmentDTO)
        {

            var result = await _appointmentDAO.Save(appointmentDTO);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

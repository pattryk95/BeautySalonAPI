using BeautySalonAPI.Models;
using BeautySalonAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateAppointmentDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _appointmentService.Update(id, dto);
            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _appointmentService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateEmployee([FromBody] CreateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var appointmentId = _appointmentService.Create(dto);

            return Created($"/api/appointment/{appointmentId}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppointmentDto>> GetAll([FromQuery]string searchPhrase)
        {
            var appointmentDtos = _appointmentService.GetAll(searchPhrase);

            return Ok(appointmentDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<AppointmentDto> Get([FromRoute] int id)
        {
            var appointment = _appointmentService.GetById(id);

            if (appointment is null)
            {
                return NotFound();
            }

            return Ok(appointment);

        }
    }
}

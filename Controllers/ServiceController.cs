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
    [Route("api/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ServiceDto>> GetAll([FromQuery] string searchPhrase)
        {
            var serviceDto = _serviceService.GetAll(searchPhrase);

            return Ok(serviceDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceDto> Get([FromRoute] int id)
        {
            var service = _serviceService.GetById(id);

            if (service is null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        [HttpPost]
        public ActionResult CreateService([FromBody] CreateServiceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var serviceId = _serviceService.Create(dto);

            return Created($"/api/service/{serviceId}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _serviceService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateServiceDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _serviceService.Update(id, dto);
            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}

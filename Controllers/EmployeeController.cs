using AutoMapper;
using BeautySalonAPI.Entities;
using BeautySalonAPI.Models;
using BeautySalonAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateEmployeeDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _employeeService.Update(id, dto);
            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _employeeService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateEmployee([FromBody] CreateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var employeeId = _employeeService.Create(dto);

            return Created($"/api/epmployee/{employeeId}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetAll([FromQuery] string searchPhrase)
        {
            var employeesDtos = _employeeService.GetAll(searchPhrase);

            return Ok(employeesDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> Get([FromRoute] int id)
        {
            var employee = _employeeService.GetById(id);

            if (employee is null)
            {
                return NotFound();
            }

            return Ok(employee);

        }
    }
}

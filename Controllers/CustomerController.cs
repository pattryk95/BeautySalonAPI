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
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetAll([FromQuery] string searchPhrase)
        {
            var customerDtos = _customerService.GetAll(searchPhrase);

            return Ok(customerDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDto> Get([FromRoute] int id)
        {
            var customer = _customerService.GetById(id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public ActionResult CreateCustomer([FromBody] CreateCustomerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var customerId = _customerService.Create(dto);

            return Created($"/api/customer/{customerId}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _customerService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateCustomerDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _customerService.Update(id, dto);
            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}

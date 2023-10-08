using CallCustomerAPI.Models;
using CallCustomerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            try
            {
                var customers = await _customerService.GetCustomersAsync();
                return Ok(customers);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching a customer list");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerById(string id)
        {
            try
            {
                var customers = await _customerService.GetCustomerByIdAsync(id);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching a customer");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                var createdCustomer = await _customerService.CreateCustomerAsync(customer);
                return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, createdCustomer);
            }
            catch
            {
                return StatusCode(500, "An error occurred while creating a customer");
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> EditCustomer(string id, [FromBody] Customer customer)
        {
            try
            {
                var editedCustomer = await _customerService.EditCustomerAsync(id, customer);
                return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, editedCustomer);
            }
            catch
            {
                return StatusCode(500, "An error occurred while updating a customer");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "An error occurred while deleting a customer");
            }
        }
    }
}

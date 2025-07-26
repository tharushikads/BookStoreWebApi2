using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreWebApi2.Models;

namespace BookStoreWebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        
        {
            _customerService = customerService;
            _logger = logger;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get Customers()
        {
            try
            {logger.LogInformation("Fetching all customers.");
                var customers = await _customerService.GetAllCustomersAsync();
                if (customers == null || !customers.Any())
                {
                    _logger.LogWarning("No customers found.");
                    return NotFound("No customers found.");
                }
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching customers.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // GET: api/Customer/2
        [HttpGet("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            try
            {
                if (id != customer.CustomerId)
                {
                    _logger.LogWarning("Customer ID mismatch.");
                    return BadRequest("Customer ID mismatch.");
                }

                await _customerService.UpdateCustomerAsync(id, customer);
                _logger.LogInformation($"Customer with ID {id} updated.");
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _customerService.GetCustomerByIdAsync(id) == null)
                {
                    _logger.LogWarning($"Customer with ID {id} not found for update.");
                    return NotFound($"Customer with ID {id} not found.");
                }
                else
                {
                    _logger.LogError("Error updating customer.");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the customer.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


        // PUT: api/Customer/2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


         // PUT: api/Customer/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            try
            {
                if (id != customer.CustomerId)
                {
                    _logger.LogWarning("Customer ID mismatch.");
                    return BadRequest("Customer ID mismatch.");
                }

                await _customerService.UpdateCustomerAsync(id, customer);
                _logger.LogInformation($"Customer with ID {id} updated.");
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _customerService.GetCustomerByIdAsync(id) == null)
                {
                    _logger.LogWarning($"Customer with ID {id} not found for update.");
                    return NotFound($"Customer with ID {id} not found.");
                }
                else
                {
                    _logger.LogError("Error updating customer.");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the customer.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


         // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    _logger.LogWarning("Received empty customer object.");
                    return BadRequest("Customer data cannot be null.");
                }

                await _customerService.AddCustomerAsync(customer);
                _logger.LogInformation($"Customer with ID {customer.CustomerId} created.");
                return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the customer.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

         // DELETE: api/Customers/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    _logger.LogWarning($"Customer with ID {id} not found.");
                    return NotFound($"Customer with ID {id} not found.");
                }

                await _customerService.DeleteCustomerAsync(id);
                _logger.LogInformation($"Customer with ID {id} deleted.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the customer.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}



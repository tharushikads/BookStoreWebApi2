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
public class CustomersController : ControllerBase
{
private readonly ICustomerService _customerService;
private readonly ILogger<CustomersController> _logger;
public CustomersController(ICustomerService customerService, ILogger<CustomersController> logger)
{
_customerService = customerService;
_logger = logger;
}
// GET: api/Students
[HttpGet]
public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
{
try
{
_logger.LogInformation("Fetching all students.");
var customers = await _customerService.GetAllCustomerAsync();
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
// GET: api/Students/5
[HttpGet("{id}")]
public async Task<ActionResult<Customer>> GetCustomers(int id)
{
try
{
_logger.LogInformation($"Fetching student with ID {id}");
var customer = await _customerService.GetCustomerByIdAsync(id);
if (customer == null)
{
_logger.LogWarning($"Customer with ID {id} not found.");
return NotFound($"Cusotmer with ID {id} not found.");
}
return Ok(customer);
}
catch (Exception ex)
{
_logger.LogError(ex, "An error occurred while fetching the customer.");
return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
}
}
// PUT: api/Students/5
[HttpPut("{id}")]
public async Task<IActionResult> PutCustomer(int id, Customer customer)
{
try
{
if (id != customer.Id)
{
_logger.LogWarning("Customer ID mismatch.");
return BadRequest("Customer ID mismatch.");
}
await _customerService.UpdateCustomerAsync(id, customer);
_logger.LogInformation($"Student with ID {id} updated.");
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
// POST: api/Students
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
_logger.LogInformation($"Customer with ID {customer.Id} created.");
return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
}
catch (Exception ex)
{
_logger.LogError(ex, "An error occurred while creating the customer.");
return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
}
}
// DELETE: api/Students/5
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
_logger.LogInformation($"Cusotmer with ID {id} deleted.");
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

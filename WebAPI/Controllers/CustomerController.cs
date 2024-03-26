using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ModelsDTO;
using WebAPI.Repositories.IRepository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/Customer
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CustomerDTO>))]
        public async Task<IActionResult> GetCustomer()
        {
            var Customer = await _customerRepository.Get();
            return Ok(Customer);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(Guid id)
        {
            if (_customerRepository == null)
            {
                return NotFound();
            }

            var customer = await _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, UpdateCustomerDTO updateCustomer)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                if (_customerRepository.CustomerExists(id))
                {
                    await _customerRepository.Update(id, updateCustomer);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CustomerDTO))]
        public async Task<IActionResult> PostCustomer(CreateCustomerDTO createCustomer)
        {
            if (_customerRepository == null)
            {
                return Problem("Entity set 'SnackShopDbContext.Customer'  is null.");
            }

            var customer = await _customerRepository.Create(createCustomer);

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id, DeleteCustomerDTO deleteCustomer)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                if (_customerRepository.CustomerExists(id))
                {
                    await _customerRepository.Delete(id, deleteCustomer);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

    }
}

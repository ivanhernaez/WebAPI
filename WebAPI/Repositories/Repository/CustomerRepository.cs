using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.SqlServerDbContext.DatabaseContext;
using WebAPI.Data.Models;
using WebAPI.ModelsDTO;
using WebAPI.Repositories.IRepository;

namespace WebAPI.Repositories.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SnackShopDbContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(SnackShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Create(CreateCustomerDTO createCustomer)
        {
            var customer = _mapper.Map<Customer>(createCustomer);
            customer.UpdatedBy = customer.CreatedBy;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<CustomerDTO>(customer);

            return result;
        }

        public async Task<IEnumerable<CustomerDTO>> Get()
        {
            var customers = await _context.Customers.Where(x => x.IsDeleted == false).ToListAsync();
            var results = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return results;
        }

        public async Task<CustomerDTO> GetById(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            var result = _mapper.Map<CustomerDTO>(customer);
            return result;
        }

        public async Task Update(Guid id, UpdateCustomerDTO updateCustomer)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer != null)
                {
                    customer.Name = updateCustomer.Name ?? customer.Name;
                    customer.Phase = updateCustomer.Phase != 0 ? updateCustomer.Phase : customer.Phase;
                    customer.Block = updateCustomer.Block != 0 ? updateCustomer.Block : customer.Block;
                    customer.Lot = updateCustomer.Lot != 0 ? updateCustomer.Lot : customer.Lot;
                    customer.Email = updateCustomer.Email ?? customer.Email;
                    customer.Sex = updateCustomer.Sex ?? customer.Sex;
                    customer.UpdatedBy = updateCustomer.UpdatedBy;
                    customer.UpdatedDate = DateTime.Now;
                    _context.Entry(customer).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task Delete(Guid id, DeleteCustomerDTO deleteCustomer)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer != null)
                {
                    customer.IsDeleted = true;
                    customer.UpdatedBy = deleteCustomer.DeletedBy;
                    customer.UpdatedDate = DateTime.Now;
                    _context.Entry(customer).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public bool CustomerExists(Guid id)
        {
            return (_context.Customers?.Any(e => e.Id == id && e.IsDeleted == false)).GetValueOrDefault();
        }
    }
}

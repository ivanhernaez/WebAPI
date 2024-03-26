using WebAPI.ModelsDTO;

namespace WebAPI.Repositories.IRepository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDTO>> Get();
        Task<CustomerDTO> GetById(Guid id);
        Task<CustomerDTO> Create(CreateCustomerDTO createCustomer);
        Task Update(Guid id, UpdateCustomerDTO updateCustomer);
        Task Delete(Guid id, DeleteCustomerDTO deleteCustomer);
        bool CustomerExists(Guid id);
    }
}

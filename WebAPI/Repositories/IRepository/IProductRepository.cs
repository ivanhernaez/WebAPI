using WebAPI.ModelsDTO;

namespace WebAPI.Repositories.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> Get();
        Task<ProductDTO> GetById(Guid id);
        Task<ProductDTO> Create(CreateProductDTO createProduct);
        Task Update(Guid id, UpdateProductDTO updateProduct);
        Task Delete(Guid id, DeleteProductDTO deleteProduct);
        bool ProductExists(Guid id);
    }
}

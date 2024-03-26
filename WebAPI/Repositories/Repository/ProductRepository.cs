using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.SqlServerDbContext.DatabaseContext;
using WebAPI.Data.Models;
using WebAPI.ModelsDTO;
using WebAPI.Repositories.IRepository;

namespace WebAPI.Repositories.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SnackShopDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(SnackShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(CreateProductDTO createProduct)
        {
            var product = _mapper.Map<Product>(createProduct);
            product.UpdatedBy = product.CreatedBy;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ProductDTO>(product);

            return result;
        }

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var products = await _context.Products.Where(x => x.IsDeleted == false).ToListAsync();
            var results = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return results;
        }

        public async Task<ProductDTO> GetById(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            var result = _mapper.Map<ProductDTO>(product);
            return result;
        }

        public async Task Update(Guid id, UpdateProductDTO updateProduct)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    product.Name = updateProduct.Name ?? product.Name;
                    product.Price = updateProduct.Price != 0 ? updateProduct.Price : product.Price;
                    product.UpdatedBy = updateProduct.UpdatedBy;
                    product.UpdatedDate = DateTime.Now;
                    _context.Entry(product).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task Delete(Guid id, DeleteProductDTO deleteProduct)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    product.IsDeleted = true;
                    product.UpdatedBy = deleteProduct.DeletedBy;
                    product.UpdatedDate = DateTime.Now;
                    _context.Entry(product).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public bool ProductExists(Guid id)
        {
            return (_context.Products?.Any(e => e.Id == id && e.IsDeleted == false)).GetValueOrDefault();
        }
    }
}

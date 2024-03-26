using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ModelsDTO;
using WebAPI.Repositories.IRepository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProduct()
        {
            var Product = await _productRepository.Get();
            return Ok(Product);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(Guid id)
        {
            if (_productRepository == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, UpdateProductDTO updateProduct)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                if (_productRepository.ProductExists(id))
                {
                    await _productRepository.Update(id, updateProduct);
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

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProduct(CreateProductDTO createProduct)
        {
            if (_productRepository == null)
            {
                return Problem("Entity set 'SnackShopDbContext.Product'  is null.");
            }

            var product = await _productRepository.Create(createProduct);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id, DeleteProductDTO deleteProduct)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                if (_productRepository.ProductExists(id))
                {
                    await _productRepository.Delete(id, deleteProduct);
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

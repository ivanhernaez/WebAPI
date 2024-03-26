using System.ComponentModel.DataAnnotations;

namespace WebAPI.ModelsDTO
{
    public class ProductDTO : CreateProductDTO
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public string UpdatedBy { get; set; } = null!;
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateProductDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public double Price { get; set; }
        [Required]
        public string CreatedBy { get; set; } = null!;
    }

    public class UpdateProductDTO
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        [Required]
        public string UpdatedBy { get; set; } = null!;
    }

    public class DeleteProductDTO
    {
        [Required]
        public string DeletedBy { get; set; } = null!;

    }

    public class DisplayProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
    }
}

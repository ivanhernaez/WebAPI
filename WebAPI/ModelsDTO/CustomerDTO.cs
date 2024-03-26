using System.ComponentModel.DataAnnotations;

namespace WebAPI.ModelsDTO
{
    public class CustomerDTO : CreateCustomerDTO
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public string UpdatedBy { get; set; } = null!;
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateCustomerDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        public short Phase { get; set; }
        public short Block { get; set; }
        public short Lot { get; set; }
        public string Email { get; set; } = null!;
        public string Sex { get; set; } = null!;
        [Required]
        public string CreatedBy { get; set; } = null!;
    }

    public class UpdateCustomerDTO
    {
        public string? Name { get; set; }
        public short Phase { get; set; }
        public short Block { get; set; }
        public short Lot { get; set; }
        public string? Email { get; set; }
        public string? Sex { get; set; }
        [Required]
        public string UpdatedBy { get; set; } = null!;
    }

    public class DeleteCustomerDTO
    {
        [Required]
        public string DeletedBy { get; set; } = null!;
    }

    public class CustomerDetailsDTO
    {
        public string Name { get; set; } = null!;
        public short Phase { get; set; }
        public short Block { get; set; }
        public short Lot { get; set; }
        public string Email { get; set; } = null!;
        public string Sex { get; set; } = null!;
    }
}

namespace WebAPI.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            //OrderProductMappings = new HashSet<OrderProductMapping>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = null!;
        public DateTime UpdatedDate { get; set; }

        //public virtual ICollection<OrderProductMapping> OrderProductMappings { get; set; }
    }
}

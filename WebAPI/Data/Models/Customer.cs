namespace WebAPI.Data.Models
{
    public partial class Customer
    {
        public Customer()
        {
            //Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public short Phase { get; set; }
        public short Block { get; set; }
        public short Lot { get; set; }
        public string Email { get; set; } = null!;
        public string Sex { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = null!;
        public DateTime UpdatedDate { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
    }
}

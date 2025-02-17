namespace EntityLayer.Concrete {
    public class Category {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public List<Product>? ProductsBelongThisCategory { get; set; }

    }
}
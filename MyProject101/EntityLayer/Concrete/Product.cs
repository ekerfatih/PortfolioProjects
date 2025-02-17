namespace EntityLayer.Concrete {
    public class Product {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public int CategoryId { get; set; }
        public Category ProductCategory { get; set; } = null!;
        public int Stock { get; set; }
    }
}

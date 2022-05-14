namespace Order.Entity.DtoModel
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public string UnitPrice { get; set; }
    }
}

namespace Application.Domains
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? isShow { get; set; }
        public bool? isDel { get; set; }
        public int? Price { get; set; }
        public int? SaleCount { get; set; }
        public string Image { get; set; }
        public int? CategoryId { get; set; }
        public int? WireId { get; set; }
        public int? BandId { get; set; }
        //Nav property
        public Band Band { get; set; }
        public Category Category { get; set; }
        public Wire TypeWire { get; set; }
        public ProductDetail ProductDetail { get; set; }
    }
}
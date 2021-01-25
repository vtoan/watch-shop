namespace Web.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int SaleCount { get; set; }
        public string Image { get; set; }
        public string CategoryName { get; set; }
        public string WireName { get; set; }
        public string BandName { get; set; }
        public int CategoryId { get; set; }
        public int BandId { get; set; }
        public int WireId { get; set; }
        public int PromotionId { get; set; }
        public double Discount { get; set; }
    }
}
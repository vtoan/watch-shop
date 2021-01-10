namespace Application.Domains
{
    public class ProductProm
    {
        public int Id { get; set; }
        public double Discount { get; set; }
        public string ProductIds { get; set; }
        public int? CategoryId { get; set; }
        public int? BandId { get; set; }
        public int? PromotionId { get; set; }
        //Nav property
        public Promotion Promotion { get; set; }
    }
}
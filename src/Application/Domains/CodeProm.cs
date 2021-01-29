namespace Application.Domains
{
    public class CodeProm
    {
        public int Id { get; set; }
        public string CodeCoupon { get; set; }
        public double? Discount { get; set; }

        public int? PromotionId { get; set; }
        //Nav property
        public Promotion Promotion { get; set; }
    }
}
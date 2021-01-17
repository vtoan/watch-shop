namespace Application.Domains
{
    public class BillProm
    {
        public int Id { get; set; }
        public double? Discount { get; set; }
        public byte? ConditionItem { get; set; }
        public int? ConditionAmount { get; set; }
        public int? PromotionId { get; set; }
        //Nav property
        public Promotion Promotion { get; set; }
    }
}
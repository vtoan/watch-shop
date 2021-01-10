namespace Application.Domains
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string TypeGlass { get; set; }
        public string TypeBorder { get; set; }
        public string TypeMachine { get; set; }
        public string Parameter { get; set; }
        public string ResistWater { get; set; }
        public string Warranty { get; set; }
        public string Origin { get; set; }
        public string Color { get; set; }
        public string Func { get; set; }
        //SE
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public int? ProductId {get;set;}
        //Nav property
        public Product Product { get; set; }
    }
}
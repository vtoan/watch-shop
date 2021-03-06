using System.Collections.Generic;

namespace Application.Domains
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public bool? isShow { get; set; }
        //SEO
        public string SeoImage { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        //Nav property
        public List<Product> Products { get; set; }
    }
}
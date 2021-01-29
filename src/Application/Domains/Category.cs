using System.Collections.Generic;
using Application.Interfaces.Helper;

namespace Application.Domains
{
    public class Category : ISeoDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? isShow { get; set; }
        //SEO
        public string SeoImage { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        // Nav property
        public List<Product> Products { get; set; }
    }
}
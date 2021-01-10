using System.Collections.Generic;

namespace Application.Domains
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Nav property
        public List<Product> Products { get; set; }
    }
}
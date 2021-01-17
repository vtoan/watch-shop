using System.Collections.Generic;

namespace Application.Domains
{
    public class Wire
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? isShow { get; set; }
        public bool? isDel { get; set; }
        // Nav property
        public List<Product> Products { get; set; }
    }
}
using Application.Interfaces.Helper;

namespace Application.Domains
{
    public class InfoShop : ISeoDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WorkTime { get; set; }
        public string Email { get; set; }
        //SEO
        public string SeoImage { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
    }
}
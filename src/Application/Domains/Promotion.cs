using System;

namespace Application.Domains
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool isShow { get; set; }
        public byte? Type { get; set; }
        public bool isAlways { get; set; }
        //Nav property
    }
}
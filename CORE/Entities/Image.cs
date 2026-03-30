using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

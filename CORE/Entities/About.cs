using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Entities
{
    public class About : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
    }
}

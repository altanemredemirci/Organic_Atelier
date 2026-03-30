using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Entities
{
    public class Contact:BaseEntity
    {
        public string Address { get; set; }
        public string Map { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
    }

    
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }

        //public string ApplicationUserId { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }


    }
}

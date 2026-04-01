using CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORE.DTOs.Product
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "İsim alanı boş geçilemez")]
        [StringLength(30)]
        public string Name { get; set; }

        public decimal ListPrice { get; set; }

        [Range(1, 1000)]
        public int Stock { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public bool IsFavorite { get; set; }

        [Range(0, 100)]
        public int Discount { get; set; }

        public int CategoryId { get; set; }

        public List<Image> Images { get; set; }

        public CreateProductDTO()
        {
            Images = new List<Image>();
        }
    }
}

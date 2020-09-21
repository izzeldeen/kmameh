using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(0.1 , double.MaxValue , ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
        [Required]
        [Range(0.1, 50, ErrorMessage = "Price must be greater than 0")]
        public int Quantity { get; set; }
        [Required]
        public List<ProductPicture> ProductPictuer { get; set; }
        [Required]
        public string category { get; set; }
    }
}

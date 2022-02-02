using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Entities.Concrete.Dtos
{
    public class ProductUpdateDto
    {
        [Required]
        public int ProductId { get; set; }

        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olmamlıdır.")]
        public string ProductName { get; set; }
        [DisplayName("Ürün Fiyatı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

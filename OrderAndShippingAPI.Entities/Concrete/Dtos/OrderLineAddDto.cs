using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Entities.Concrete.Dtos
{
    public class OrderLineAddDto
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public int OrderId { get; set; }
    }
}

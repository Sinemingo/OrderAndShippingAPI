using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderAndShippingAPI.Entities.Abstract.Enums;

namespace OrderAndShippingAPI.Entities.Concrete.Dtos
{
    public class OrderAddDto
    {
        [Required]
        public double TotalOrderPrice { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public EShippingStatu Statu { get; set; }
        public ShippingCompany ShippingCompany { get; set; }
        public int UserId { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}

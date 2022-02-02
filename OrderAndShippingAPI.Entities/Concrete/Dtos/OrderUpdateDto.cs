using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderAndShippingAPI.Entities.Abstract.Enums;

namespace OrderAndShippingAPI.Entities.Concrete.Dtos
{
    public class OrderUpdateDto
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public Guid OrderGuidId { get; set; }
        [Required]
        public double TotalOrderPrice { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public EShippingStatu Statu { get; set; }
        public int ShippingCompanyId { get; set; }
        public ShippingCompany ShippingCompany { get; set; }
    }
}

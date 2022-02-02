using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderAndShippingAPI.Entities.Abstract.Enums;

namespace OrderAndShippingAPI.Entities.Concrete.Dtos
{
    public class OrderLineDto
    {
        public OrderLine OrderLine { get; set; }
        public EResultStatu ResultStatus { get; set; }
    }
}

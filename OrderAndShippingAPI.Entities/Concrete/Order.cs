using OrderAndShippingAPI.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderAndShippingAPI.Entities.Abstract.Enums;

namespace OrderAndShippingAPI.Entities.Concrete
{
    public class Order: IEntity
    {
        public int OrderId { get; set; }
        public double TotalOrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public EShippingStatu Statu { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        public Order()
        {
            OrderLines=new HashSet<OrderLine>();
        }
    }
}

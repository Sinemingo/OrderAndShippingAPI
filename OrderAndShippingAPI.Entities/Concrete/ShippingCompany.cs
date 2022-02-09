using OrderAndShippingAPI.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Entities.Concrete
{
    public class ShippingCompany:IEntity
    {
        public int ShippingCompanyId{get; set; }
        public string ShippingCompanyName { get; set; }
        public ICollection<Category> Categories { get; set; }

        public ShippingCompany()
        {
            Categories=new HashSet<Category>();
        }
    }
}

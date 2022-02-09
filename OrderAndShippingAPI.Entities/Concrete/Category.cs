using OrderAndShippingAPI.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Entities.Concrete
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ShippingCompanyId { get; set; }
        public ShippingCompany ShippingCompany { get; set; }
        public ICollection<Product> Products { get; set; }

        public Category()
        {
            Products=new HashSet<Product>();
        }
       
    }
}

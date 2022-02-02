using OrderAndShippingAPI.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Entities.Concrete
{
    public class Role: IEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public ICollection<User> Users { get; set; }
        public Role()
        {
            Users= new HashSet<User>();
        }
    }
}

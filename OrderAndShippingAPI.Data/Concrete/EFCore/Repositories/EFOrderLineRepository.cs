using Microsoft.EntityFrameworkCore;
using OrderAndShippingAPI.Data.Abstract;
using OrderAndShippingAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Data.Concrete.EFCore.Repositories
{
    public class EFOrderLineRepository : EFEntityRepositoryBase<OrderLine>, IOrderLineRepository
    {
        public EFOrderLineRepository(DbContext context) : base(context)
        {
        }
    }
}

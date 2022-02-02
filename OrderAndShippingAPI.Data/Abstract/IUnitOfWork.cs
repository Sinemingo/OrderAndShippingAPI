using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IShippingCompanyRepository ShippingCompanies { get; }
        IOrderLineRepository OrderLines { get; }

        Task<int> SaveAsync();

    }
}

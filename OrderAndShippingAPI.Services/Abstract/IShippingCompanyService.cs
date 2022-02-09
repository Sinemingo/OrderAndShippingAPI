using OrderAndShippingAPI.Entities.Concrete;
using OrderAndShippingAPI.Entities.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Services.Abstract
{
    public interface IShippingCompanyService
    {
        Task<IDataResult<ShippingCompany>> Get(int shippingCompanyId);
        Task<IDataResult<IList<ShippingCompany>>> GetAll();
        Task<IResult> Add(ShippingCompany shippingCompany);
        Task<IResult> Update(ShippingCompany shippingCompany);
        Task<IResult> Delete(int shippingCompanyId);
    }
}

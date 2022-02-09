using OrderAndShippingAPI.Entities.Concrete;
using OrderAndShippingAPI.Entities.Utilities.Results.Abstract;
using OrderAndShippingAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Services.Concrete
{
    public class ShippingCompanyManager : IShippingCompanyService
    {
        public Task<IResult> Add(ShippingCompany shippingCompany)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int shippingCompanyId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ShippingCompany>> Get(int shippingCompanyId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<ShippingCompany>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(ShippingCompany shippingCompany)
        {
            throw new NotImplementedException();
        }
    }
}

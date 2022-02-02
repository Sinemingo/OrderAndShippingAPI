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
    public class RoleManager : IRoleService
    {
        public Task<IResult> Add(Role roleAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Role>> Get(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<Role>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(Role roleUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}

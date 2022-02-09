using OrderAndShippingAPI.Entities.Concrete;
using OrderAndShippingAPI.Entities.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Services.Abstract
{
    public interface IRoleService
    {
        Task<IDataResult<Role>> Get(int roleId);
        Task<IDataResult<IList<Role>>> GetAll();
        Task<IResult> Add(Role roleAddDto);
        Task<IResult> Update(Role roleUpdateDto);
        Task<IResult> Delete(int roleId);
    }
}

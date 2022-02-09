using OrderAndShippingAPI.Entities.Concrete;
using OrderAndShippingAPI.Entities.Concrete.Dtos;
using OrderAndShippingAPI.Entities.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Services.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<UserDto>> Get(int userId);
        Task<IDataResult<UserListDto>> GetAll();
        Task<IResult> Add(UserAddDto userAddDto);
        Task<IResult> Update(User userUpdateDto);
        Task<IResult> Delete(int userId);
    }
}

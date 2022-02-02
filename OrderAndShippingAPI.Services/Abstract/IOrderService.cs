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
    public interface IOrderService
    {
        Task<IDataResult<OrderDto>> Get(int orderId);
        Task<IDataResult<OrderListDto>> GetAll(int userId);
        Task<IResult> Add(OrderAddDto orderAddDto);
        Task<IResult> Update(OrderUpdateDto orderUpdateDto);
        Task<IResult> Delete(int orderId,Role role);
    }
}

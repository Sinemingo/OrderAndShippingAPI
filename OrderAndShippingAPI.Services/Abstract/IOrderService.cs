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
        Task<IDataResult<Order>> Get(int orderId);
        Task<IDataResult<IList<OrderAddDto>>> GetAll(int userId);
        Task<IResult> Add(OrderAddDto orderAddDto);
        Task<IResult> Update(Order order);
        Task<IResult> Delete(int orderId,Role role);
    }
}

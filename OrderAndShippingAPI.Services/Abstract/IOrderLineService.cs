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
    public interface IOrderLineService
    {
        Task<IDataResult<OrderLine>> Get(int orderLineId);
        Task<IDataResult<IList<OrderLine>>> GetAll(int userId);
        Task<IResult> Add(OrderLineAddDto orderLineAddDto);
        Task<IResult> Update();
        Task<IResult> Delete(int orderLineId);
    }
}

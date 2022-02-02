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
        Task<IDataResult<OrderLineDto>> Get(int orderLineId);
        Task<IDataResult<OrderLineListDto>> GetAll();
        Task<IResult> Add(OrderLineAddDto orderLineAddDto);
        Task<IResult> Update(OrderLineUpdateDto orderLineUpdateDto);
        Task<IResult> Delete(int orderLineId);
    }
}

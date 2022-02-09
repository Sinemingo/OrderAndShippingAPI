using AutoMapper;
using OrderAndShippingAPI.Data.Abstract;
using OrderAndShippingAPI.Entities.Concrete;
using OrderAndShippingAPI.Entities.Concrete.Dtos;
using OrderAndShippingAPI.Entities.Utilities.Results.Abstract;
using OrderAndShippingAPI.Entities.Utilities.Results.Concrete;
using OrderAndShippingAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Services.Concrete
{
    public class OrderLineManager : IOrderLineService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderLineManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> Add(OrderLineAddDto orderLineAddDto)
        {
            var orderLine = _mapper.Map<OrderLine>(orderLineAddDto);
            await _unitOfWork.OrderLines.AddAsync(orderLine);
            await _unitOfWork.SaveAsync();
            return new Result(Entities.Abstract.Enums.EResultStatu.Success, $"{orderLineAddDto} adlı sipariş alınmıştır.");
        }

        public async Task<IResult> Delete(int orderLineId)
        {
            var orderLine = await _unitOfWork.OrderLines.GetAsync(ol => ol.OrderLineId == orderLineId);
            if (orderLine != null)
            {
                await _unitOfWork.OrderLines.DeleteAsync(orderLine);
                await _unitOfWork.SaveAsync();
                return new Result(Entities.Abstract.Enums.EResultStatu.Success, $"{orderLine.Product.ProductName} adlı sipariş silinmiştir.");
            }
            return new Result(Entities.Abstract.Enums.EResultStatu.Error, $"{orderLine.Product.ProductName} adlı sipariş bulanamamıştır.");

        }

        public async Task<IDataResult<OrderLine>> Get(int orderLineId)
        {
            var orderLine = await _unitOfWork.OrderLines.GetAsync(ol => ol.OrderLineId == orderLineId, ol => ol.Product);
            if (orderLine != null)
            {
                return new DataResult<OrderLine>(Entities.Abstract.Enums.EResultStatu.Success, orderLine);
            }
            return new DataResult<OrderLine>(Entities.Abstract.Enums.EResultStatu.Error, null, "Sipariş satırı Bulunamadı!");
        }

        public async Task<IDataResult<IList<OrderLine>>> GetAll(int orderId)
        {
            var orderLines = await _unitOfWork.OrderLines.GetAllAsync(ol=>ol.OrderId==orderId,ol=>ol.Product);
            if (orderLines.Count > -1)
            {
                return new DataResult<IList<OrderLine>>(Entities.Abstract.Enums.EResultStatu.Success, orderLines);
            }
            return new DataResult<IList<OrderLine>>(Entities.Abstract.Enums.EResultStatu.Error, null, "Siparişin Satırlarına Ulaşılamadı!");

        }

        public Task<IResult> Update()
        {
            throw new NotImplementedException();
        }
    }
}

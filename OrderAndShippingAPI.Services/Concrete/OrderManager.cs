using AutoMapper;
using Newtonsoft.Json;
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
using Microsoft.EntityFrameworkCore;

namespace OrderAndShippingAPI.Services.Concrete
{
    public class OrderManager : IOrderService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> Add(OrderAddDto orderAddDto)
        {
            orderAddDto.ShippingCompanyId = orderAddDto.OrderLines[0].Product.Category.ShippingCompanyId;

            var order = _mapper.Map<Order>(orderAddDto);
            await _unitOfWork.Orders.AddAsync(order);

            foreach (var item in order.OrderLines)
            {
                await _unitOfWork.OrderLines.AddAsync(item);
            }

            await _unitOfWork.SaveAsync();
            return new Result(Entities.Abstract.Enums.EResultStatu.Success, $"{orderAddDto} adlı sipariş alınmıştır.");

        }


        public async Task<IResult> Delete(int orderId,Role role)
        {
        //    var order = await _unitOfWork.Orders.GetAsync(o => o.OrderId == orderId);

            var orderlines = await _unitOfWork.OrderLines.GetAllAsync(ol => ol.OrderId == orderId,ol=>ol.Product,ol=> ol.Order);

            if (orderlines != null)
            {
                var categoryId = orderlines[0].Product.CategoryId;

                if (categoryId == 1)
                {
                    if (role.RoleName=="Admin")
                    {
                    await _unitOfWork.Orders.DeleteAsync(orderlines[0].Order);
                    }
                    else
                    {
                    return new Result(Entities.Abstract.Enums.EResultStatu.Error, $"Bu siparişi silmeye yetkiniz bulunmamaktadır.");
                    }
                }
                else if (categoryId == 2)
                {
                    await _unitOfWork.Orders.DeleteAsync(orderlines[0].Order);
                }
                else
                {
                    return new Result(Entities.Abstract.Enums.EResultStatu.Error, $"Sipariş giyim veya gıda kategorisine ait değildir.");
                }

                await _unitOfWork.SaveAsync();
                return new Result(Entities.Abstract.Enums.EResultStatu.Success, $"Sipariş silinmiştir.");
            }
            return new Result(Entities.Abstract.Enums.EResultStatu.Error, $"Sipariş bulanamamıştır.");

        }

        public async Task<IDataResult<Order>> Get(int orderId)
        {
            var order = await _unitOfWork.Orders.GetAsync(o => o.OrderId == orderId, o => o.OrderLines);
            if (order != null)
            {
                return new DataResult<Order>(Entities.Abstract.Enums.EResultStatu.Success, order);
            }
            return new DataResult<Order>(Entities.Abstract.Enums.EResultStatu.Error, null, "Sipariş Bulunamadı!");
        }

        public async Task<IDataResult<IList<OrderAddDto>>> GetAll(int userId)
        {
            //https://entityframeworkcore.com/querying-data-include-theninclude

            //var orders = await _unitOfWork.Orders.GetAllAsync(null,o=>o.OrderLines);
            var queryable = await _unitOfWork.Orders.GetQueryableAsync();
            queryable = queryable.Include(x => x.OrderLines).ThenInclude(ol=> ol.Product);

            var orders = queryable.ToList();

            if (orders.Count() > -1)
            {
                var orderDtos = _mapper.Map<IList<OrderAddDto>>(orders);
                return new DataResult<IList<OrderAddDto>>(Entities.Abstract.Enums.EResultStatu.Success, orderDtos);
            }
            return new DataResult<IList<OrderAddDto>>(Entities.Abstract.Enums.EResultStatu.Error, null, "Sipairişlere Ulaşılamadı!");

        }

        public async Task<IResult> Update(Order order)
        {
            await _unitOfWork.Orders.UpdateAsync(order);
            await _unitOfWork.SaveAsync();
            return new Result(Entities.Abstract.Enums.EResultStatu.Success, $"{order.OrderId} id li sipariş güncellenmiştir.");
        }

    }
}

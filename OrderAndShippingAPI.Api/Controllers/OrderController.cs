using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderAndShippingAPI.Api.Authenticate;
using OrderAndShippingAPI.Api.Authenticate.Abstract;
using OrderAndShippingAPI.Data.Abstract;
using OrderAndShippingAPI.Entities.Concrete;
using OrderAndShippingAPI.Entities.Concrete.Dtos;
using OrderAndShippingAPI.Entities.Utilities.Results.Abstract;
using OrderAndShippingAPI.Entities.Utilities.Results.Concrete;
using OrderAndShippingAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController: ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly ILoginTokenService _loginService;
        public OrderController(IOrderService orderService, ILoginTokenService loginService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
            _loginService = loginService;
        }


        [HttpPost(/*"~/api/createorder"*/)]
        public async Task<IActionResult> CreateOrder(OrderAddDto orderAddDto)
        {
            try
            {
                var _userId = AuthHelper.AuthValid(this);
                orderAddDto.UserId = Convert.ToInt32(_userId);
                orderAddDto.ShippingStatu = Entities.Abstract.Enums.EShippingStatu.Transit;
                var result = await _orderService.Add(orderAddDto);

                return Created("",result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            try
            {
                var _userId = AuthHelper.AuthValid(this);
                var user = await _userService.Get(Convert.ToInt32(_userId));
                var role = user.Data.User.Role;

                var result = await _orderService.Delete(orderId,role);
                return Ok(result) ;
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("~/api/orders/{userId}")]
        public async Task<IActionResult> GetOrders(int userId)
        {
            try
            {
                var _userId = AuthHelper.AuthValid(this);
                var result = await _orderService.GetAll(userId);
                
                return Ok(result.Data);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("~/api/order/{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            try
            {
                var _userId = AuthHelper.AuthValid(this);
                var result = await _orderService.Get(orderId);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("~/api/updateOrder/{orderId}")]
        public async Task<IActionResult> OrderUpdate(int orderId)
        {
            try
            {
                var _userId = AuthHelper.AuthValid(this);
                var order = await _orderService.Get(orderId);
                if (order.Data!=null)
                {
                    order.Data.OrderId = orderId;
                    order.Data.Statu = Entities.Abstract.Enums.EShippingStatu.Delivered;
                    var result = await _orderService.Update(order.Data);

                    return Ok(result);
                }
                return BadRequest("Bu Id de bir sipariş bulunamamıştır.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

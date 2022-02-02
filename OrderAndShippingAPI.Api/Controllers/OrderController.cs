using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                orderAddDto.Statu = Entities.Abstract.Enums.EShippingStatu.Transit;
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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrders(int userId)
        {
            try
            {
                var _userId = AuthHelper.AuthValid(this);
                var result = await _orderService.GetAll(userId);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

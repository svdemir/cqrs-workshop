﻿using Microsoft.AspNetCore.Mvc;
using OrderApiMonolith.Data.Entities;
using OrderApiMonolith.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OrderApiMonolith.Controllers
{
    [ApiController]
    [Route("order")]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            await _orderService.CreateOrder(order);
            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> GetOrder([FromQuery]string orderCode)
        {
            var order = await _orderService.GetOrder(orderCode);
            return Ok(order);
        }
    }
}

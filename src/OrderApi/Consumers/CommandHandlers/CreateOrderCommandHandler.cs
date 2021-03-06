﻿using MassTransit;
using OrderApi.Data.Entities;
using OrderApi.Data.Repositories.MsSql;
using OrderApi.Domain.Commands;
using System.Threading.Tasks;

namespace OrderApi.Consumers.CommandHandlers
{
    public class CreateOrderCommandHandler : IConsumer<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Consume(ConsumeContext<CreateOrderCommand> context)
        {
            var order = Order.Create(context.Message.Id, context.Message.OrderCode, context.Message.OrderDate, context.Message.UserId, context.Message.TotalPrice);

            await _orderRepository.Create(order);
        }
    }
}

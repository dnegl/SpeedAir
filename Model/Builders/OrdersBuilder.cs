using SpeedAir.Model.Builders.Abstraction;
using SpeedAir.Model.Dto;
using SpeedAir.Model.Models;
using SpeedAir.Model.Storages.Abstraction;

namespace SpeedAir.Model.Builders;

public class OrdersBuilder : IOrdersBuilder
{
    private readonly IOrdersStorageMutable _ordersStorage;

    public OrdersBuilder(IOrdersStorageMutable ordersStorage)
    {
        _ordersStorage = ordersStorage;
    }
    public void Build(IReadOnlyDictionary<string, OrderDto> ordersDto)
    {
        var orders = ordersDto.Select(orderDto => new Order(orderDto.Key, orderDto.Value.Destination));
        var ordersResult = new Orders(orders);
        _ordersStorage.AddOrders(ordersResult);
    }
}
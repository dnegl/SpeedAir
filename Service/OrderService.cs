using SpeedAir.Model.Builders.Abstraction;
using SpeedAir.Service.Abstraction;
using SpeedAir.Service.Commands.Abstraction;

namespace SpeedAir.Service;

public class OrderService : IOrderService
{
    private readonly IOrdersBuilder _ordersBuilder;
    private readonly ILoadOrdersCommand _loadOrdersCommand;

    public OrderService(
        IOrdersBuilder ordersBuilder,
        ILoadOrdersCommand loadOrdersCommand)
    {
        _ordersBuilder = ordersBuilder;
        _loadOrdersCommand = loadOrdersCommand;
    }
    
    public void LoadOrders()
    {
        var orders = _loadOrdersCommand.Execute();
        _ordersBuilder.Build(orders);
    }
}
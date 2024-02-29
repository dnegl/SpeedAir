using SpeedAir.Model.Models;
using SpeedAir.Model.Storages.Abstraction;

namespace SpeedAir.Model.Storages;

public class FulfilledOrdersStorage : IFulfilledOrdersStorage
{
    private readonly Dictionary<Order, Flight> _fulfilledtOrdersMap = new();
    private readonly List<Order> _unfulfilledOrders = new();

    public void TryAddOrderToFlight(Order order, Flight flight)
    {
        if (!_fulfilledtOrdersMap.ContainsKey(order))
        {
            _fulfilledtOrdersMap[order] = flight;
        }
    }

    public void AddUnfulfilledOrder(Order order)
    {
        _unfulfilledOrders.Add(order);
    }

    public IReadOnlyDictionary<Order, Flight> GetFulfilledOrders()
    {
        return _fulfilledtOrdersMap;
    }
    
    public IEnumerable<Order> GetUnfulfilledOrders()
    {
        return _unfulfilledOrders;
    }
}
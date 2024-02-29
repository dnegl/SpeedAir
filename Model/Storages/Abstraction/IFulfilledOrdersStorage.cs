using SpeedAir.Model.Models;

namespace SpeedAir.Model.Storages.Abstraction;

public interface IFulfilledOrdersStorage
{
    void TryAddOrderToFlight(Order order, Flight flight);
    
    void AddUnfulfilledOrder(Order order);

    IReadOnlyDictionary<Order, Flight> GetFulfilledOrders();

    IEnumerable<Order> GetUnfulfilledOrders();
}
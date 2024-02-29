using SpeedAir.Model.Models;
using SpeedAir.Model.Storages.Abstraction;

namespace SpeedAir.Model.Storages;

public class OrdersStorage : IOrdersStorageMutable
{
    private Orders _orders;

    public Orders GetOrders()
    {
        return _orders;
    }

    public void AddOrders(Orders ordersDto)
    {
        _orders = ordersDto;
    }
}
using SpeedAir.Model.Models;

namespace SpeedAir.Model.Storages.Abstraction;

public interface IOrdersStorageMutable : IOrdersStorageImmutable
{
    void AddOrders(Orders ordersDto);
}
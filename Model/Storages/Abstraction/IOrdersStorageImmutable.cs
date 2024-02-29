using SpeedAir.Model.Models;

namespace SpeedAir.Model.Storages.Abstraction;

public interface IOrdersStorageImmutable
{
    Orders GetOrders();
}
using SpeedAir.Model.Models;

namespace SpeedAir.Model.Storages.Abstraction;

public interface IPlanesStorageImmutable
{
    IEnumerable<Plane> GetAllPlanes();
}
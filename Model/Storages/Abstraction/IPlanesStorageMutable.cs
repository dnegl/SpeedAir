using SpeedAir.Model.Models;

namespace SpeedAir.Model.Storages.Abstraction;

public interface IPlanesStorageMutable : IPlanesStorageImmutable
{
    void AddPlane(Plane plane);
}
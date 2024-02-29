using SpeedAir.Model.Builders.Abstraction;
using SpeedAir.Model.Dto;
using SpeedAir.Model.Models;
using SpeedAir.Model.Storages.Abstraction;

namespace SpeedAir.Model.Builders;

public class PlanesBuilder : IPlanesBuilder
{
    private readonly IPlanesStorageMutable _planesStorage;

    public PlanesBuilder(IPlanesStorageMutable planesStorage)
    {
        _planesStorage = planesStorage;
    }

    public void Build(IEnumerable<PlaneDto> planesDto)
    {
        var planes = planesDto.Select(plane => new Plane(plane.Id, plane.Capacity));
        foreach (var plane in planes)
        {
            _planesStorage.AddPlane(plane);
        }
    }
}
using SpeedAir.Model.Dto;

namespace SpeedAir.Model.Builders.Abstraction;

public interface IPlanesBuilder
{
    void Build(IEnumerable<PlaneDto> planes);
}
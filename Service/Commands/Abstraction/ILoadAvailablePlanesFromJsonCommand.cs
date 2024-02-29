using SpeedAir.Model.Dto;

namespace SpeedAir.Service.Commands.Abstraction;

public interface ILoadAvailablePlanesFromJsonCommand
{
    IEnumerable<PlaneDto> Execute();
}
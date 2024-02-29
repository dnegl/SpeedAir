using SpeedAir.Model.Builders.Abstraction;
using SpeedAir.Service.Abstraction;
using SpeedAir.Service.Commands.Abstraction;

namespace SpeedAir.Service;

public class AvailablePlanesService : IAvailablePlanesService
{
    private readonly ILoadAvailablePlanesFromJsonCommand _loadAvailablePlanesFromJsonCommand;
    private readonly IPlanesBuilder _planesBuilder;

    public AvailablePlanesService(
        ILoadAvailablePlanesFromJsonCommand loadAvailablePlanesFromJsonCommand,
        IPlanesBuilder planesBuilder)
    {
        _loadAvailablePlanesFromJsonCommand = loadAvailablePlanesFromJsonCommand;
        _planesBuilder = planesBuilder;
    }

    public void LoadAvailablePlanes()
    {
        var planes = _loadAvailablePlanesFromJsonCommand.Execute();
        _planesBuilder.Build(planes);
    }
}
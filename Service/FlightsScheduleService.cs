using SpeedAir.Model.Builders.Abstraction;
using SpeedAir.Service.Abstraction;
using SpeedAir.Service.Commands.Abstraction;

namespace SpeedAir.Service;

public class FlightsScheduleService : IFlightsScheduleService
{
    private readonly ILoadScheduleFromJsonCommand _loadScheduleFromJsonCommand;
    private readonly IScheduleBuilder _scheduleBuilder;

    public FlightsScheduleService(
        ILoadScheduleFromJsonCommand loadScheduleFromJsonCommand,
        IScheduleBuilder scheduleBuilder)
    {
        _loadScheduleFromJsonCommand = loadScheduleFromJsonCommand;
        _scheduleBuilder = scheduleBuilder;
    }

    public void LoadSchedule()
    {
        var schedule = _loadScheduleFromJsonCommand.Execute();
        _scheduleBuilder.Build(schedule);
    }
}
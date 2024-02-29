using SpeedAir.Model.Dto;

namespace SpeedAir.Service.Commands.Abstraction;

public interface ILoadScheduleFromJsonCommand
{
    IEnumerable<DayDto> Execute();
}
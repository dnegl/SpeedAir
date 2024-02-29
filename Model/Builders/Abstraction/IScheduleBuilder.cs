using SpeedAir.Model.Dto;

namespace SpeedAir.Model.Builders.Abstraction;

public interface IScheduleBuilder
{
    void Build(IEnumerable<DayDto> dayDtos);
}
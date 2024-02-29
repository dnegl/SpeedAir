using SpeedAir.Model.Builders.Abstraction;
using SpeedAir.Model.Dto;
using SpeedAir.Model.Models;
using SpeedAir.Model.Storages.Abstraction;

namespace SpeedAir.Model.Builders;

public class ScheduleBuilder : IScheduleBuilder
{
    private readonly IScheduleStorageMutable _scheduleStorage;

    public ScheduleBuilder(IScheduleStorageMutable scheduleStorage)
    {
        _scheduleStorage = scheduleStorage;
    }
    public void Build(IEnumerable<DayDto> dayDtos)
    {
        var days = dayDtos.Select(dayDto => new Day(
            dayDto.Id, 
            dayDto.Flights.Select(flightDto => new Flight(
                flightDto.Id,
                flightDto.Day,
                flightDto.PlaneId,
                flightDto.Departure,
                flightDto.Destination)).ToList())).ToList();
        _scheduleStorage.AddDays(days);
    }
}
using SpeedAir.Model.Models;

namespace SpeedAir.Model.Storages.Abstraction;

public interface IScheduleStorageImmutable
{
    IEnumerable<Day> GetDays();
}
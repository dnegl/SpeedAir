using SpeedAir.Model.Models;

namespace SpeedAir.Model.Storages.Abstraction;

public interface IScheduleStorageMutable : IScheduleStorageImmutable
{
    void AddDays(List<Day> days);
}
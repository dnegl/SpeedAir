using SpeedAir.Model.Models;
using SpeedAir.Model.Storages.Abstraction;

namespace SpeedAir.Model.Storages;

public class ScheduleStorage : IScheduleStorageMutable
{
    private List<Day> _days = new();
    
    public void AddDays(List<Day> days)
    {
        _days = days;
    }

    public IEnumerable<Day> GetDays()
    {
        return _days;
    }
}
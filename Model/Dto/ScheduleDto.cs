namespace SpeedAir.Model.Dto;

public record ScheduleDto
{
    public List<DayDto> Days { get; init; } = new();
}
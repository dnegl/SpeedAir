using System.Text.Json;
using Microsoft.Extensions.Configuration;
using SpeedAir.Model.Dto;
using SpeedAir.Service.Commands.Abstraction;

namespace SpeedAir.Service.Commands;

public class LoadScheduleFromJsonCommand : ILoadScheduleFromJsonCommand
{
    private readonly IConfiguration _configuration;

    public LoadScheduleFromJsonCommand(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<DayDto> Execute()
    {
        var filesSettings = _configuration.GetRequiredSection("Files").Get<FilesSettings>();
        if (filesSettings == null || string.IsNullOrEmpty(filesSettings.Schedule))
        {
            throw new InvalidOperationException("Configuration or file path is missing.");
        }
        using var fileStream = File.OpenRead(filesSettings.Schedule);
        var schedule = JsonSerializer.Deserialize<List<DayDto>>(fileStream);
        return schedule ?? new List<DayDto>();
    }
}
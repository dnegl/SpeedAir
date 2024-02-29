using System.Text.Json;
using Microsoft.Extensions.Configuration;
using SpeedAir.Model.Dto;
using SpeedAir.Service.Commands.Abstraction;

namespace SpeedAir.Service.Commands;

public class LoadAvailablePlanesFromJsonCommand : ILoadAvailablePlanesFromJsonCommand
{
    private readonly IConfiguration _configuration;

    public LoadAvailablePlanesFromJsonCommand(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<PlaneDto> Execute()
    {
        var filesSettings = _configuration.GetRequiredSection("Files").Get<FilesSettings>();
        if (filesSettings == null || string.IsNullOrEmpty(filesSettings.AvailablePlanesFilePath))
        {
            throw new InvalidOperationException("Configuration or file path is missing.");
        }
        using var fileStream = File.OpenRead(filesSettings.AvailablePlanesFilePath);
        var planes = JsonSerializer.Deserialize<List<PlaneDto>>(fileStream);
        return planes ?? new List<PlaneDto>();
    }
}
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using SpeedAir.Model.Dto;
using SpeedAir.Service.Commands.Abstraction;

namespace SpeedAir.Service.Commands;

public class LoadOrdersFromJsonCommand : ILoadOrdersCommand
{
    private readonly IConfiguration _configuration;

    public LoadOrdersFromJsonCommand(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IReadOnlyDictionary<string, OrderDto> Execute()
    {
        var filesSettings = _configuration.GetRequiredSection("Files").Get<FilesSettings>();
        if (filesSettings == null || string.IsNullOrEmpty(filesSettings.OrdersFilePath))
        {
            throw new InvalidOperationException("Configuration or file path is missing.");
        }
        using var fileStream = File.OpenRead(filesSettings.OrdersFilePath);
        var orders = JsonSerializer.Deserialize<Dictionary<string, OrderDto>>(fileStream);
        return orders ?? new Dictionary<string, OrderDto>();
    }
}
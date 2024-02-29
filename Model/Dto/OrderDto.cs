using System.Text.Json.Serialization;

namespace SpeedAir.Model.Dto;

public record OrderDto
{
    [JsonPropertyName("destination")] 
    public string Destination { get; init; } = string.Empty;
}
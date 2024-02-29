using System.Text.Json.Serialization;

namespace SpeedAir.Model.Dto;

public record FlightDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }
    
    [JsonPropertyName("day")]
    public int Day { get; init; }
    
    [JsonPropertyName("planeId")]
    public int PlaneId { get; init; }
    
    [JsonPropertyName("departure")]
    public string Departure { get; init; } = string.Empty;
    
    [JsonPropertyName("destination")]
    public string Destination { get; init; } = string.Empty;
}
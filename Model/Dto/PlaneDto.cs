using System.Text.Json.Serialization;

namespace SpeedAir.Model.Dto;

public record PlaneDto
{
    [JsonPropertyName("id")]
    public int Id { get; init; }
    
    [JsonPropertyName("capacity")]
    public int Capacity { get; init; }
}
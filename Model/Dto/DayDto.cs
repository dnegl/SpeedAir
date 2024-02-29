using System.Text.Json.Serialization;

namespace SpeedAir.Model.Dto;

public record DayDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("flights")] 
    public List<FlightDto> Flights { get; init; } = new();
}
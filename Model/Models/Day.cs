namespace SpeedAir.Model.Models;

public class Day
{
    public int Id { get; }
    
    public List<Flight> Flights { get; }

    public Day(int id, List<Flight> flights)
    {
        Id = id;
        Flights = flights;
    }
}
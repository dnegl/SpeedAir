namespace SpeedAir.Model.Models;

public class Flight
{
    public int Id { get; }
    
    public int Day { get; }
    
    public int PlaneId { get; }
    
    public string Departure { get;  }
    
    public string Destination { get; }
    
    public List<Order> FulfilledOrders { get; init; } = new();

    public Flight(int id, int day, int planeId, string departure, string destination)
    {
        Id = id;
        Day = day;
        PlaneId = planeId;
        Departure = departure;
        Destination = destination;
    }
}
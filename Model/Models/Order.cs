namespace SpeedAir.Model.Models;

public class Order
{
    public string Id { get; }
    public string Destination { get; }
    
    public Order(string id, string destination)
    {
        Id = id;
        Destination = destination;
    }
}
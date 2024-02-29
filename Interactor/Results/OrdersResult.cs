namespace SpeedAir.Interactor.Results;

public class OrdersResult
{
    public List<FulfilledOrdersResult> Fulfilled = new();
    public List<UnfulfilledOrdersResult> Unfulfilled = new();
}

public class FulfilledOrdersResult
{
    public string OrderId { get; }
    public string FlightNumber { get; }
    public string Departure { get; }
    public string Destination { get; }
    public string Day { get; }
    
    public FulfilledOrdersResult(string orderId, string flightNumber, string departure, string destination, string day)
    {
        OrderId = orderId;
        FlightNumber = flightNumber;
        Departure = departure;
        Destination = destination;
        Day = day;
    }
}

public class UnfulfilledOrdersResult
{
    public string OrderId { get; }
    
    public UnfulfilledOrdersResult(string orderId)
    {
        OrderId = orderId;
    }
}
namespace SpeedAir.Interactor.Results;

public class ScheduleResult
{
    public List<FlightResult> Flights { get; }

    public ScheduleResult(List<FlightResult> flights)
    {
        Flights = flights;
    }
}

public class FlightResult
{
    public string FlightId { get; }
    public string Departure { get; }
    public string Destination { get; }
    public string DayId { get; }

    public FlightResult(string flightId, string departure, string destination, string dayId)
    {
        FlightId = flightId;
        Departure = departure;
        Destination = destination;
        DayId = dayId;
    }
}
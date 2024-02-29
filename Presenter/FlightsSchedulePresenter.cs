using SpeedAir.Interactor.Abstraction;
using SpeedAir.Presenter.Abstraction;

namespace SpeedAir.Presenter;

public class FlightsSchedulePresenter : IFlightsSchedulePresenter
{
    private readonly IFlightOrderInteractor _flightOrderInteractor;

    public FlightsSchedulePresenter(IFlightOrderInteractor flightOrderInteractor)
    {
        _flightOrderInteractor = flightOrderInteractor;
    }

    public void Init()
    {
        _flightOrderInteractor.Init();
    }
    
    public void PrintSchedule()
    {
        var schedule = _flightOrderInteractor.GetScheduleResult();
        
        Console.WriteLine("Flight Schedule:");
            
        foreach (var flight in schedule.Flights)
        {
                Console.WriteLine($"Flight: {flight.FlightId}, " +
                                  $"departure: {flight.Departure}, " +
                                  $"arrival: {flight.Destination}, " +
                                  $"day: {flight.DayId}");
        }
    }

    public void FulfillOrders()
    {
        _flightOrderInteractor.FulfillOrders();
    }
    
    public void PrintOrders()
    {
        var orders = _flightOrderInteractor.GetOrdersResult();

        Console.WriteLine("Scheduled Orders:");
        
        foreach (var order in orders.Fulfilled)
        {
            Console.WriteLine($"order: {order.OrderId}, " +
                              $"flightNumber: {order.FlightNumber}, " +
                              $"departure: {order.Departure}, " +
                              $"arrival: {order.Destination}, " +
                              $"day: {order.Day}");
        }

        
        foreach (var unfulfilledOrder in orders.Unfulfilled)
        {
            Console.WriteLine($"order: {unfulfilledOrder.OrderId}, flightNumber: not scheduled");
        }
    }
}
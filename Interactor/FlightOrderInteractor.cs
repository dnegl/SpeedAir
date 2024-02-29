using SpeedAir.Interactor.Abstraction;
using SpeedAir.Interactor.Results;
using SpeedAir.Model.Models;
using SpeedAir.Model.Storages.Abstraction;
using SpeedAir.Service.Abstraction;

namespace SpeedAir.Interactor;

public class FlightOrderInteractor : IFlightOrderInteractor
{
    private readonly IAvailablePlanesService _planesService;
    private readonly IOrderService _orderService;
    private readonly IFlightsScheduleService _flightsScheduleService;
    
    private readonly IOrdersStorageMutable _ordersStorage;
    private readonly IPlanesStorageMutable _planesStorage;
    private readonly IScheduleStorageMutable _scheduleStorage;
    private readonly IFulfilledOrdersStorage _fulfilledOrdersStorage;
        
    public FlightOrderInteractor(
        IAvailablePlanesService planesService,
        IOrderService orderService,
        IOrdersStorageMutable ordersStorage,
        IPlanesStorageMutable planesStorage, 
        IScheduleStorageMutable scheduleStorage,
        IFlightsScheduleService flightsScheduleService, IFulfilledOrdersStorage fulfilledOrdersStorage)
    {
        _planesService = planesService;
        _orderService = orderService;
        _ordersStorage = ordersStorage;
        _planesStorage = planesStorage;
        _scheduleStorage = scheduleStorage;
        _flightsScheduleService = flightsScheduleService;
        _fulfilledOrdersStorage = fulfilledOrdersStorage;
    }

    public void Init()
    {
        _planesService.LoadAvailablePlanes();
        _orderService.LoadOrders();
        _flightsScheduleService.LoadSchedule();
    }

    public ScheduleResult GetScheduleResult()
    {
        var days = new List<FlightResult>();
        
        foreach (var day in _scheduleStorage.GetDays())
        {
            foreach (var flight in day.Flights)
            {
                days.Add(new FlightResult(flight.Id.ToString(), flight.Departure, flight.Destination, flight.Day.ToString()));
            }
        }

        return new ScheduleResult(days);
    }

    public OrdersResult GetOrdersResult()
    {
        var ordersResult = new OrdersResult();
        var fulfilledOrdersResult = new List<FulfilledOrdersResult>();
        var unfulfilledOrdersResult = new List<UnfulfilledOrdersResult>();
        ordersResult.Fulfilled = fulfilledOrdersResult;
        ordersResult.Unfulfilled = unfulfilledOrdersResult;
        
        foreach (var fulfilledOrderPair in _fulfilledOrdersStorage.GetFulfilledOrders())
        {
            var fulfilledResult = new FulfilledOrdersResult(
                fulfilledOrderPair.Key.Id,
                fulfilledOrderPair.Value.Id.ToString(),
                fulfilledOrderPair.Value.Departure,
                fulfilledOrderPair.Value.Destination,
                fulfilledOrderPair.Value.Day.ToString());
            fulfilledOrdersResult.Add(fulfilledResult);
        }

        foreach (var unfulfilledOrder in _fulfilledOrdersStorage.GetUnfulfilledOrders())
        {
            var unfulfilledResult = new UnfulfilledOrdersResult(unfulfilledOrder.Id);
            unfulfilledOrdersResult.Add(unfulfilledResult);
        }

        return ordersResult;
    }
    
    public void FulfillOrders()
    {
        var orders = _ordersStorage.GetOrders().OrdersList;
        
        foreach (var order in orders)
        {
            var days = _scheduleStorage.GetDays();
            
            var isOrderFulfilled = false;
            
            foreach (var day in days)
            {
                var flight = day.Flights.FirstOrDefault(f => f.Destination == order.Destination);
                if (flight == null || !TryGetPlaneById(flight.PlaneId, out var plane)) continue;
                if (!(flight.FulfilledOrders.Count < plane?.Capacity)) continue;
                _fulfilledOrdersStorage.TryAddOrderToFlight(order, flight);
                flight.FulfilledOrders.Add(order);
                isOrderFulfilled = true;
                break;
            }

            if (!isOrderFulfilled)
            {
                _fulfilledOrdersStorage.AddUnfulfilledOrder(order);
            }
        }
    }

    private bool TryGetPlaneById(int planeId, out Plane? availablePlane)
    {
        availablePlane = default;
        foreach (var plane in _planesStorage.GetAllPlanes())
        {
            if (plane.Id != planeId) continue;
            availablePlane = plane;
            return true;
        }

        return false;
    }
}
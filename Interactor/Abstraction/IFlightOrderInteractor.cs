using SpeedAir.Interactor.Results;

namespace SpeedAir.Interactor.Abstraction;

public interface IFlightOrderInteractor
{
    void Init();
    
    void FulfillOrders();
    
    ScheduleResult GetScheduleResult();
    
    OrdersResult GetOrdersResult();
}
namespace SpeedAir.Presenter.Abstraction;

public interface IFlightsSchedulePresenter
{
    void Init();

    void FulfillOrders();
    
    void PrintSchedule();

    void PrintOrders();
}
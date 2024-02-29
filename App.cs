using SpeedAir.Presenter.Abstraction;

namespace SpeedAir;

public class App
{
    private readonly IFlightsSchedulePresenter _flightsSchedulePresenter;

    public App(IFlightsSchedulePresenter flightsSchedulePresenter)
    {
        _flightsSchedulePresenter = flightsSchedulePresenter;
    }

    public void Run(string[] args)
    {
        _flightsSchedulePresenter.Init();
        
        // First story
        _flightsSchedulePresenter.PrintSchedule();
        
        _flightsSchedulePresenter.FulfillOrders();
        
        // Second story
        _flightsSchedulePresenter.PrintOrders();
    }
}
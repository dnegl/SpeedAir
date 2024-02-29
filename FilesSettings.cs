namespace SpeedAir;

public class FilesSettings
{
    public FilesSettings(string ordersFilePath, string availablePlanesFilePath, string schedule)
    {
        OrdersFilePath = ordersFilePath;
        AvailablePlanesFilePath = availablePlanesFilePath;
        Schedule = schedule;
    }

    public string OrdersFilePath { get; }
    public string AvailablePlanesFilePath { get; }
    public string Schedule { get; }
}
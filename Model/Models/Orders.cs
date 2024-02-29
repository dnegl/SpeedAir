namespace SpeedAir.Model.Models;

public class Orders
{
    public IEnumerable<Order> OrdersList { get; }

    public Orders(IEnumerable<Order> orders)
    {
        OrdersList = orders;
    }
}
namespace SpeedAir.Model.Models;

public class Plane
{
    public int Id { get; }
    public int Capacity { get; }

    public Plane(int id, int capacity)
    {
        Id = id;
        Capacity = capacity;
    }
}
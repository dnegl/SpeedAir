using SpeedAir.Model.Models;
using SpeedAir.Model.Storages.Abstraction;

namespace SpeedAir.Model.Storages;

public class PlanesStorage : IPlanesStorageMutable
{
    private List<Plane> _planes = new();
    
    public IEnumerable<Plane> GetAllPlanes()
    {
        return _planes;
    }

    public void AddPlane(Plane plane)
    {
        _planes.Add(plane);
    }
}
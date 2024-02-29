using SpeedAir.Model.Dto;

namespace SpeedAir.Model.Builders.Abstraction;

public interface IOrdersBuilder
{
    void Build(IReadOnlyDictionary<string, OrderDto> orders);
}
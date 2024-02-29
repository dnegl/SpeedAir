using SpeedAir.Model.Dto;

namespace SpeedAir.Service.Commands.Abstraction;

public interface ILoadOrdersCommand
{
    IReadOnlyDictionary<string, OrderDto> Execute();
}
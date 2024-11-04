using FluentResults;

namespace Domain.DomainServices.SlotGeneratorService;

public interface ISlotService
{
    Task<Result> Clean();
    Task<Result> Generate(int days);

}
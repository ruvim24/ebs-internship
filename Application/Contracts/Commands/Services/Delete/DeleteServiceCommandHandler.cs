using Domain.IRepositories;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.Services.Delete;

public record DeleteServiceCommand(int Id) : IRequest<Result>;
public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, Result>
{
    public readonly IServiceRepository _serviceRepository;

    public DeleteServiceCommandHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    public async Task<Result> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var result = await _serviceRepository.GetByIdAsync(request.Id);
        if(result == null) return Result.Fail("Service not found");
        
        await _serviceRepository.DeleteAsync(result);
        
        return Result.Ok();
    }
}
using Domain.IRepositories;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.Cars.Delete;

public record DeleteCarCommand(int Id) : IRequest<Result>;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Result>
{
    private readonly ICarRepository _carRepository;

    public DeleteCarCommandHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task<Result> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id);
        if(car == null) return Result.Fail($"Car with id:{request.Id} not found");
        await _carRepository.DeleteAsync(car);
        return Result.Ok();
    }
}
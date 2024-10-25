using Application.DTOs.Car;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.CarCommands.Update;

public record UpdateCarCommand(UpdateCarDto Model) : IRequest<Result<CarDto>>;
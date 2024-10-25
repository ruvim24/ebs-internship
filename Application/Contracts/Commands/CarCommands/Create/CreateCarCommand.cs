using Application.DTOs.Car;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.CarCommands.Create;

public record CreateCarCommand(CreateCarDto Model) : IRequest<Result<CarDto>>;
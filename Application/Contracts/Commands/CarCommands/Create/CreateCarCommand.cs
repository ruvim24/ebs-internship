using Application.DTOs.Car;
using Application.DTOs.CarDtos;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.CarCommands.Create;

public record CreateCarCommand(CreateCarDto Model) : IRequest<Result<CarDto>>;
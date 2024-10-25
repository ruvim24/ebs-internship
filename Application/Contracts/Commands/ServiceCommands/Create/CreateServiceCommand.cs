using Application.DTOs.Service;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.ServiceCommands.Create;

public record CreateServiceCommand(CreateServiceDto Model) : IRequest<Result<ServiceDto>>;
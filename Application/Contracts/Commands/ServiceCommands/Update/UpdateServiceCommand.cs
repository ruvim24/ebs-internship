using Application.DTOs.ServiceDtos;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.ServiceCommands.Update;

public record UpdateServiceCommand(UpdateServiceDto Model) : IRequest<Result<ServiceDto>>;
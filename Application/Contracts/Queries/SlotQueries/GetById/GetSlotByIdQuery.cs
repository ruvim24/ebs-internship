using Application.DTOs.SlotDtos;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.SlotQueries.GetById;

public record GetSlotByIdQuery(int Id) : IRequest<Result<SlotDto>>;
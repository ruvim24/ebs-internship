using Application.DTOs.SlotDtos;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.SlotQueries.GetMastersAvailableSlots;

public record GetMasterAvailableSlotsQuery(int MasterId) : IRequest<Result<IEnumerable<SlotDto>>>;
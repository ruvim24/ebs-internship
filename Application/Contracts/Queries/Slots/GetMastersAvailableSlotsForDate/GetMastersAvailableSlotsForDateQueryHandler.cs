using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;
using Shared.Dtos.Slots;

namespace Application.Contracts.Queries.Slots.GetMastersAvailableSlotsForDate;

public record GetMasterAvailableSlotsForDateQuery(DateTime Date, int MasterId) : IRequest<Result<IEnumerable<SlotDto>>>;

public class GetMastersAvailableSlotsForDateQueryHandler : IRequestHandler<GetMasterAvailableSlotsForDateQuery, Result<IEnumerable<SlotDto>>>
{
    private readonly ISlotRepository _slotRepository;
    private readonly IMapper _mapper;

    public GetMastersAvailableSlotsForDateQueryHandler(ISlotRepository slotRepository, IMapper mapper)
    {
        _slotRepository = slotRepository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<SlotDto>>> Handle(GetMasterAvailableSlotsForDateQuery request, CancellationToken cancellationToken)
    {
        var result = await _slotRepository.GetMastersAvailableSlotsForDate(request.Date, request.MasterId);
        if(result == null)  return Result.Fail($"No available slots for date: {request.Date}");
        return Result.Ok(_mapper.Map<IEnumerable<SlotDto>>(result));
    }
}
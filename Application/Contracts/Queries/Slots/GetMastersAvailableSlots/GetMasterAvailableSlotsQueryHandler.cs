using Application.DTOs.Slots;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.Slots.GetMastersAvailableSlots;

public record GetMasterAvailableSlotsQuery(int MasterId) : IRequest<Result<IEnumerable<SlotDto>>>;

public class GetMasterAvailableSlotsQueryHandler : IRequestHandler<GetMasterAvailableSlotsQuery, Result<IEnumerable<SlotDto>>>
{
    private readonly ISlotRepository _slotRepository;
    private readonly IMapper _mapper;

    public GetMasterAvailableSlotsQueryHandler(ISlotRepository slotRepository, IMapper mapper)
    {
        _slotRepository = slotRepository;
        _mapper = mapper;
    }   
    public async Task<Result<IEnumerable<SlotDto>>> Handle(GetMasterAvailableSlotsQuery request, CancellationToken cancellationToken)
    {
        if (request.MasterId <= 0) return Result.Fail("Id should be greater than 0");
        var result = await _slotRepository.GetMasterAvaialableSlotsAsync(request.MasterId); 
        if(result == null) return Result.Fail("No slots available");
        return Result.Ok(_mapper.Map<IEnumerable<SlotDto>>(result));
    }
}
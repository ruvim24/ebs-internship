using Application.DTOs.SlotDtos;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.SlotQueries.GetMastersAvailableSlots;

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
        var result = await _slotRepository.GetMasterAvaialableSlotsAsync(request.MasterId); 
        if(result == null) return Result.Fail("No slots available");
        return Result.Ok(_mapper.Map<IEnumerable<SlotDto>>(result));
    }
}
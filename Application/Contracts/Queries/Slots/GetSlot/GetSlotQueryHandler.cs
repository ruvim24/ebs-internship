using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;
using Shared.Dtos.Slots;

namespace Application.Contracts.Queries.Slots.GetSlot;

public record GetSlotQuery(int SlotId) : IRequest<Result<SlotDto>>;
public class GetSlotQueryHandler : IRequestHandler<GetSlotQuery, Result<SlotDto>>
{
    ISlotRepository _slotRepository;
    IMapper _mapper;

    public GetSlotQueryHandler(ISlotRepository slotRepository, IMapper mapper)
    {
        _slotRepository = slotRepository;
        _mapper = mapper;
    }
    public async Task<Result<SlotDto>> Handle(GetSlotQuery request, CancellationToken cancellationToken)
    {
        var result = await _slotRepository.GetByIdAsync(request.SlotId);
        if (result == null)
        {
            return Result.Fail("Slot not found");
        }
        
        return Result.Ok(_mapper.Map<SlotDto>(result));
    }
}
using Application.DTOs.Slots;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.Slots.GetById;

public record GetSlotByIdQuery(int Id) : IRequest<Result<SlotDto>>;

public class GetSlotByIdQueryHandler : IRequestHandler<GetSlotByIdQuery, Result<SlotDto>>
{
    private readonly ISlotRepository _slotRepository;
    private readonly IMapper _mapper;

    public GetSlotByIdQueryHandler(ISlotRepository slotRepository, IMapper mapper)
    {
        this._slotRepository = slotRepository;
        this._mapper = mapper;
        
    }
    public async Task<Result<SlotDto>> Handle(GetSlotByIdQuery request, CancellationToken cancellationToken)
    {
        if(request.Id <= 0) return Result.Fail("Id should be greater than 0");
        var result = await _slotRepository.GetByIdAsync(request.Id);
        if(result == null) return Result.Fail("Slot not found");
        return Result.Ok(this._mapper.Map<SlotDto>(result));
    }
}
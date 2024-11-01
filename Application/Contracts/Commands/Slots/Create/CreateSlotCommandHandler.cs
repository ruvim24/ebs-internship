using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.Slots.Create;

public class CreateSlotDto
{
    public int MasterId { get;  set; }
    public DateTime StartTime { get;  set; }
    public DateTime EndTime { get;  set; }
}


public record CreateSlotCommand(CreateSlotDto Model) : IRequest<Result>;

public class CreateSlotCommandHandler : IRequestHandler<CreateSlotCommand, Result>
{
    private readonly ISlotRepository _slotRepository;
    private readonly IUserRepository _userRepository;

    public CreateSlotCommandHandler(ISlotRepository slotRepository, IUserRepository userRepository)
    {
        _slotRepository = slotRepository;
        _userRepository = userRepository;
    }
    public async Task<Result> Handle(CreateSlotCommand request, CancellationToken cancellationToken)
    {
       // if (request.Model.MasterId == 1) return Result.Fail("Id - ul este: 1");
        var exists = await _userRepository.GetByIdAsync(request.Model.MasterId);
        if (exists == null) return Result.Fail("Master not found");
        
        var slot = Slot.Create(request.Model.MasterId, request.Model.StartTime, request.Model.EndTime);
        await _slotRepository.AddAsync(slot.Value);
        
        return Result.Ok();
    }
}
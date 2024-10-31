using Application.DTOs.UserDtos;
using Application.DTOs.Users;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Commands.Users.CreateMaster;

public record CreateMasterCommand(CreateMasterDto Model) : IRequest<Result<UserDto>>;

public class CreateMasterCommandHandler : IRequestHandler<CreateMasterCommand, Result<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<CreateMasterDto> _validator;
    private readonly IMapper _mapper;

    public CreateMasterCommandHandler(IUserRepository userRepository, IValidator<CreateMasterDto> validator, IMapper mapper)
    {
        _userRepository = userRepository;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<Result<UserDto>> Handle(CreateMasterCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request.Model);
        if(!validationResult.IsValid) return Result.Fail("Validation failed");
        
        var master = _mapper.Map<User>(request.Model);
        var createMaster = User.Create(master.FullName, master.Email, master.PhoneNumber, master.Password, master.Role);
        if(createMaster.IsFailed) return Result.Fail("Failed to create Master");
        
        await _userRepository.AddAsync(createMaster.Value);
        return Result.Ok(_mapper.Map<UserDto>(createMaster.Value));
    }
}
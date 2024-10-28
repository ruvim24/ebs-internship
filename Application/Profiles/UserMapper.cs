using Application.DTOs.UserDtos;
using Domain.Entities;
using Domain.Enums;
using Mapster;

namespace Application.Profiles;

public class UserMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<User, UserDto>.NewConfig();

        TypeAdapterConfig<UserDto, User>.NewConfig()
            .Map(dest => dest.FullName, src => src.FullName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.Role, src => src.Role);

        TypeAdapterConfig<CreateUserDto, User>.NewConfig()
            .Map(dest => dest.FullName, src => src.FullName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.Password, src => src.Password)
            .ConstructUsing(src => User.Create(src.FullName,  src.Email,  src.PhoneNumber, src.Password, Role.Customer).Value);
        
        TypeAdapterConfig<UpdateUserDto, User>.NewConfig()
            .Map(dest => dest.Id, src => src.Id) 
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.Role, src => src.Role); 
    }
}
using Application.DTOs.Slot;
using Domain.Entities;
using FluentResults;
using Mapster;

namespace Application.Profiles;

public class SlotMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<Slot, SlotDto>.NewConfig();
            
        TypeAdapterConfig<SlotDto, Slot>.NewConfig()
            .Map(dest => dest.StartTime, src => src.StartTime)
            .Map(dest => dest.EndTime, src => src.EndTime)
            .Map(dest => dest.Availability, src => src.Availability)
            .Map(dest => dest.MasterId, src => src.MasterId);
    }
}
using Application.DTOs.DaySchedule;
using Application.DTOs.DaySchedules;
using Domain.Entities;
using Mapster;

namespace Application.Profiles;

public class DayScheduleMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<DaySchedule, DayScheduleDto>.NewConfig();

        TypeAdapterConfig<UpdateDayScheduleDto, DaySchedule>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.StartTime, src => src.StartTime)
            .Map(dest => dest.EndTime, src => src.EndTime);
    }
}
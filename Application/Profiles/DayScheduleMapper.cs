using Application.DTOs.DaySchedule;
using Domain.Entities.Schedule;
using Mapster;

namespace Application.Profiles;

public class DayScheduleMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<DaySchedule, DayScheduleDto>.NewConfig();

        TypeAdapterConfig<UpdateDayScheduleDto, DaySchedule>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.StartTime, src => src.StartTime)
            .Map(dest => dest.EndTime, src => src.EndTime);

    }
}
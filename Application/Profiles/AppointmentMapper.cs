using Application.DTOs.Appointment;
using Domain.Entities;
using Mapster;

namespace Application.Profiles;

public class AppointmentMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<Appointment, AppointmentDto>.NewConfig();

        TypeAdapterConfig<AppointmentDto, Appointment>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.CarId, src => src.CarId)
            .Map(dest => dest.ServiceId, src => src.ServiceId)
            .Map(dest => dest.SlotId, src => src.SlotId)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt);

        TypeAdapterConfig<CreateAppointmentDto, Appointment>.NewConfig()
            .Map(dest => dest.CarId, src => src.CarId)
            .Map(dest => dest.ServiceId, src => src.ServiceId)
            .Map(dest => dest.SlotId, src => src.SlotId);

        TypeAdapterConfig<UpdateAppointmentDto, Appointment>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Status, src => src.Status);
    }
}
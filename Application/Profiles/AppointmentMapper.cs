using Application.DTOs.Appointment;
using Application.DTOs.AppointmentDtos;
using Domain.Entities;
using Mapster;

namespace Application.Profiles;

public class AppointmentMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
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
            .Map(dest => dest.SlotId, src => src.SlotId)
            .ConstructUsing(scr => Appointment.Create(scr.CarId, scr.ServiceId, scr.SlotId).Value);

        TypeAdapterConfig<UpdateAppointmentDto, Appointment>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Status, src => src.Status);
    }
}
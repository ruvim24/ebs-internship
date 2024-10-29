using Domain.Enums;
using Domain.IRepositories;
using Quartz;

namespace Application.Jobs.Cleaner;

public class SlotAppointmnetCleaner : IJob
{
    private readonly ISlotRepository _slotRepository;
    private readonly IAppointmentRepository _appointmentRepository;

    public SlotAppointmnetCleaner(ISlotRepository slotRepository, IAppointmentRepository appointmentRepository)
    {
        _slotRepository = slotRepository;
        _appointmentRepository = appointmentRepository;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        var slots = await _slotRepository.GetAllAsync();
        foreach (var slot in slots)
        {
            //stergere sloturi care nu au fost rezervate
            if (slot.IsAvailable() && slot.EndTime < DateTime.Now)
            {
                await _slotRepository.DeleteByIdAsync(slot.Id);
            }
        }
        
        var appointments = await _appointmentRepository.GetAllAsync();
        appointments = appointments?.ToList();
        if(appointments == null || !appointments.Any()) return;
        
        //setare appointment-uri pe expired la care a expirat data dar sunt pe statutul Scheduled
        foreach (var appointment in appointments)
        {
            if (appointment.Status == AppointmentStatus.Scheduled && appointment.Slot.EndTime < DateTime.Now)
            {
                appointment.SetExpired();
                await _appointmentRepository.UpdateAsync(appointment);
            }
        }
    }
}
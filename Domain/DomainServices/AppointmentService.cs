using Domain.Entities.ObjectValues;
using Domain.Entities.NewFolder;


namespace Domain.DomainServices
{
    public sealed class AppointmentService
    {
        public async Task<Appointment> CreateAppointment(Guid masterId, Guid carId, Guid serviceId, TimeSlot reservationTime)
        {
            using (var context = new ApplicationDbContext())
            {
                // Verifică dacă masterul, serviciul și mașina există
                var masterExists = await context.Users.AnyAsync(u => u.Id == masterId && u.Role == UserRole.Master);
                var serviceExists = await context.Services.AnyAsync(s => s.Id == serviceId && s.MasterId == masterId);
                var carExists = await context.Cars.AnyAsync(c => c.Id == carId);

                if (!masterExists || !serviceExists || !carExists)
                {
                    throw new ArgumentException("Invalid master, service, or car.");
                }

                // Verifică dacă slotul de timp este disponibil
                var schedule = await context.Schedules.FirstOrDefaultAsync(s => s.UserId == masterId);
                if (schedule != null && schedule.ReservedTimeSlots.Contains(reservationTime))
                {
                    throw new InvalidOperationException("Time slot is already reserved.");
                }

                // Creează appointment-ul
                var appointment = Appointment.Create(masterId, Guid.Empty, serviceId, carId, reservationTime); // CustomerId nu este folosit

                // Adaugă appointment-ul în baza de date
                await context.Appointments.AddAsync(appointment);

                // Adaugă slotul rezervat în programul masterului
                schedule.AddRezervedTimeSlot(reservationTime);
                context.Schedules.Update(schedule);

                // Salvează modificările
                await context.SaveChangesAsync();

                return appointment;
            }
        }

    }
}

using Domain.Entities;
using Domain.IRepositories;
using FluentResults;

namespace Domain.DomainServices.AppointmentService;

public class AppointmentService : IAppointmentService
{
    private IUserRepository _userRepository;
    private IAppointmentRepository _appointmentRepository;
    private ICarRepository _carRepository;
    private ISlotRepository _slotRepository;
    private IServiceRepository _serviceRepository;
    
    public AppointmentService(IUserRepository userRepository, 
        IAppointmentRepository appointmentRepository,
        ICarRepository carRepository,
        ISlotRepository slotRepository,
        IServiceRepository serviceRepository)
    {
        _userRepository = userRepository;
        _appointmentRepository = appointmentRepository;
        _carRepository = carRepository;
        _slotRepository = slotRepository;
        _serviceRepository = serviceRepository;
    }
    public async Task<Result<Appointment>> Create(int carId, int serviceId, int slotId)
    {
        var car = await  _carRepository.GetByIdAsync(carId);
        var service = await _serviceRepository.GetByIdAsync(serviceId);
        var slot = await _slotRepository.GetByIdAsync(slotId);

        if (car != null && service != null && slot != null && slot.Availability == true)
        {
            //Set slot as unavailable
            slot.SetNotAvailable();
            await _slotRepository.UpdateAsync(slot);
            
            var appointment = Appointment.Create(carId, serviceId, slotId);
            if(appointment.IsFailed) return Result.Fail("Failed to create appointment");    
            
            await _appointmentRepository.AddAsync(appointment.Value);
            return Result.Ok(appointment.Value);
        }
        return Result.Fail("Invalid arguments");
    }
    
    
}
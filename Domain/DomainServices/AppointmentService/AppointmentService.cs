using Domain.Entities;
using Domain.IRepositories;

namespace Domain.Services;

public class AppointmentService
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

    public async void Create(int carId, int serviceId, int slotId)
    {
        var car = await  _carRepository.GetByIdAsync(carId);
        var service = await _serviceRepository.GetByIdAsync(serviceId);
        var slot = await _slotRepository.GetByIdAsync(slotId);

        if (slot.IsAvailable())
        {
            var appointment = Appointment.Create(car, service, slot);
           await _appointmentRepository.AddAsync(appointment.Value);
        }
    }
    
    
}
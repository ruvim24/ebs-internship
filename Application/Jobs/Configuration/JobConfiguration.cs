using Application.Jobs.Cleaner;
using Application.Jobs.Generator;
using Domain.DomainServices.SlotGeneratorService;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Application.Jobs.Configuration
{
    public static class QuartzExtensions
    {
        public static void ConfigureQuartzJobs(this IServiceCollection services)
        {
            services.AddQuartz(q =>
            {

                services.AddScoped<ISlotService, SlotService>();

                // Adaugă job-ul
                var jobKey = new JobKey("slotGeneratorJob");
                q.AddJob<SlotGeneratorJob>(opts => opts.WithIdentity(jobKey));

                // Adaugă un trigger pentru job
                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity("slotGeneratorJob-trigger")
                    .WithCronSchedule("0 0 15 * * ?")); // Exemplu: Rulează zilnic la ora 15:00
                
                // Adaugă job-ul
                var slotJobKey = new JobKey("slotAppointmentCleanerJob");
                q.AddJob<SlotAppointmentCleanerJob>(opts => opts.WithIdentity(slotJobKey));

                // Adaugă un trigger pentru job
                q.AddTrigger(opts => opts
                    .ForJob(slotJobKey)
                    .WithIdentity("slotAppointmentCleanerJob-trigger")
                    .WithCronSchedule("0 0 14 * * ?")); // Exemplu: Rulează zilnic la ora 14:00
            });

            // Asigură-te că serviciul Quartz este activ și așteaptă finalizarea joburilor la oprire
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        }
    }
}
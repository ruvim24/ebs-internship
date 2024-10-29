using Application.Jobs.Cleaner;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Application.Jobs.Extension;

public static class QuartzConfiguration
{
    public static void AddQuartzServices(this IServiceCollection services)
    {
        services.AddQuartz(q =>
        {
            //q.UseMicrosoftDependencyInjectionJobFactory();
            var jobKey = new JobKey("SlotAppointmentCleanerJob");
            q.AddJob<SlotAppointmnetCleaner>(opts => opts.WithIdentity(jobKey));

            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("SlotAppointmentCleanerTrigger")
                .WithCronSchedule("0 0 9,13,17 * * ?")
            ); 

        });
        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    }
}
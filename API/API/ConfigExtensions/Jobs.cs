using Application.Jobs.Cleaner;
using Application.Jobs.Generator;
using Hangfire;

namespace API.ConfigExtensions;

public static class Jobs
{
    public static void JobsConfiguration(this IApplicationBuilder app)
    {
        
        var backgroundJobClient = app.ApplicationServices.GetRequiredService<IBackgroundJobClient>();

        //backgroundJobClient.Enqueue(() => Console.WriteLine("Job executed"));
        backgroundJobClient.Enqueue<SlotAppointmentCleanerJob>(job => job.Execute());
        backgroundJobClient.Enqueue<SlotGeneratorJob>(job => job.Execute());

        var recurringJobManager = app.ApplicationServices.GetRequiredService<IRecurringJobManager>();

        recurringJobManager.AddOrUpdate<SlotGeneratorJob>(
            "slotGenerator-job", 
            job => job.Execute(),
            "0 8 * * *",
            new RecurringJobOptions 
            {
                TimeZone = TimeZoneInfo.Local 
            });

        recurringJobManager.AddOrUpdate<SlotAppointmentCleanerJob>(
            "cleaner-job",
            job => job.Execute(),
            "0 8 * * *",
            new RecurringJobOptions
            {
                TimeZone = TimeZoneInfo.Local
            });
    }
}
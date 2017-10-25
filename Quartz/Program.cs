using System;
using Quartz.Impl;
using Quartz;
using Quartz.Impl.Matchers;
using System.Threading.Tasks;
using System.Threading;
using Quartz.Listeners;

namespace Quartz
{
    class Program
    {
        static void Main(string[] args)
        {

            MainAsync().GetAwaiter().GetResult();

            Console.WriteLine("Press any key for exit..");
            Console.ReadKey();
        }
        static async Task MainAsync()
        {
            var scheduler = await new StdSchedulerFactory().GetScheduler();
            SchedulerConfiration(scheduler);
            //add jobs and triggers and start scheduler as usual
            var job = JobBuilder.Create<ExampleJob>().WithIdentity("MyJob", "MyGroupJob").Build();
            var trigger = TriggerBuilder.Create().WithIdentity("MyTrigger", "MyTriggerGroup").WithSimpleSchedule(s => s.WithIntervalInSeconds(2).RepeatForever()).Build();
            await scheduler.ScheduleJob(job, trigger);
                //start
            await scheduler.Start();
            Thread.Sleep(5000);

            await scheduler.Shutdown(true);
        }
        static void SchedulerConfiration(IScheduler scheduler)
        {

            scheduler.ListenerManager.AddSchedulerListener(new SchedulerListener());
            scheduler.ListenerManager.AddJobListener(new JobListener(), GroupMatcher<JobKey>.AnyGroup());
            scheduler.ListenerManager.AddTriggerListener(new TriggerListner(), GroupMatcher<TriggerKey>.AnyGroup());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace Quartz.Listeners
{
    public class SchedulerListener : ISchedulerListener
    {
        public string Name => "SchedulerListener";

        public Task JobAdded(IJobDetail jobDetail, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Job({2}) was added", Name, DateTime.Now, jobDetail.Key.Name);
            });
        }

        public Task JobDeleted(JobKey jobKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Job({2}) was deleted", Name, DateTime.Now, jobKey.Name);
            });
        }

        public Task JobInterrupted(JobKey jobKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Job({2}) was deleted", Name, DateTime.Now, jobKey.Name);
            });
        }

        public Task JobPaused(JobKey jobKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Job({2}) was paused", Name, DateTime.Now,jobKey.Name);
            });
        }

        public Task JobResumed(JobKey jobKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Job({2}) was resumed", Name, DateTime.Now, jobKey.Name);
            });
        }

        public Task JobScheduled(ITrigger trigger, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(()=> {
                Write("{0} -- {1}  --  JobScheduled() was called", Name, DateTime.Now);
            });
        }

        public Task JobsPaused(string jobGroup, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  JobGroup({2}) was paused", Name, DateTime.Now, jobGroup);
            });
        }

        public Task JobsResumed(string jobGroup, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  JobGroup({2}) was resumed", Name, DateTime.Now, jobGroup);
            });
        }

        public Task JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  JobUnscheduled({2})", Name, DateTime.Now, triggerKey.Name);
            });
        }

        public Task SchedulerError(string msg, SchedulerException cause, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Scheduler has error {3}", Name, DateTime.Now, msg);
            });
        }

        public Task SchedulerInStandbyMode(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Scheduler in Standby Mode", Name, DateTime.Now);
            });
        }

        public Task SchedulerShutdown(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Scheduler is shutdown", Name, DateTime.Now);
            });
        }

        public Task SchedulerShuttingdown(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Scheduler is shutingdown ", Name, DateTime.Now);
            });
        }

        public Task SchedulerStarted(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Scheduler was started", Name, DateTime.Now);
            });
        }

        public Task SchedulerStarting(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Scheduler is starting", Name, DateTime.Now);
            });
        }

        public Task SchedulingDataCleared(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  SchedulerData was cleared", Name, DateTime.Now);
            });
        }

        public Task TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Trigger({3}) was finalized", Name, DateTime.Now,trigger.Key.Name);
            });
        }

        public Task TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Trigger({3}) was paused", Name, DateTime.Now, triggerKey.Name);
            });
        }

        public Task TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Trigger({3}) was resumed", Name, DateTime.Now, triggerKey.Name);
            });
        }

        public Task TriggersPaused(string triggerGroup, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  TriggerGroup({3}) were paused", Name, DateTime.Now, triggerGroup);
            });
        }

        public Task TriggersResumed(string triggerGroup, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  TriggerGroup({3}) were resumed", Name, DateTime.Now, triggerGroup);
            });
        }

        private static void Write(string message, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message, args);
            Console.ResetColor();

        }
    }
}

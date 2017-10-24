using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace Quartz.Listeners
{
    public class TriggerListner : ITriggerListener
    {
        public string Name => "GlobalTriggerListener";

        public Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {

                Write("{0} -- {1}  --  Trigger ({2}) comleted", Name, DateTime.Now, trigger.Key);
            });
        }

        public Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {

                Write("{0} -- {1}  --  Trigger ({2}) was fired", Name, DateTime.Now,trigger.Key);
            });
        }

        public Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {

                Write("{0} -- {1}  --  Trigger ({2}) was misfired", Name, DateTime.Now, trigger.Key);
            }); ;
        }

        public Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task<bool>.Run(()=> {

                Write("{0} -- {1}  --  Trigger ({2}) is not going to veto the job({3})", Name, DateTime.Now, trigger.Key,context.JobDetail.Key);
                return false;
            });
        }
        private static void Write(string message, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message, args);
            Console.ResetColor();

        }
    }
}

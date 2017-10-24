using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace Quartz.Listeners
{
    public class JobListener : IJobListener
    {
        public string Name => "GlobalJobListener";

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {
                Write("{0} -- {1}  --  Job ({2}) was vetoed", Name, DateTime.Now, context.JobDetail.Key);
            });
        }

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(()=> {

                Write("{0} -- {1}  --  Job ({2}) is about to be executed",Name,DateTime.Now,context.JobDetail.Key);
            });
        }

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {

                Write("{0} -- {1}  --  Job ({2}) was executed", Name, DateTime.Now, context.JobDetail.Key);
            });
        }
        private static void Write(string message, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message, args);
            Console.ResetColor();

        }
    }
}

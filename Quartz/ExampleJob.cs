using System;
using System.Threading.Tasks;
using Quartz;

namespace Quartz
{
    class ExampleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() => {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("--->Executing the example job");
                Console.ResetColor();

            });
        }
    }
}

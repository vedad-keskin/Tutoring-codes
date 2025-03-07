using Microsoft.Extensions.Logging;
using Quartz;
using ridewithme.Service.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Jobs
{
    public class CompletedObavjestenjaJob : IJob
    {
        RidewithmeContext Context;
        ILogger<CompletedObavjestenjaJob> _logger;
        public CompletedObavjestenjaJob(RidewithmeContext dbContext, ILogger<CompletedObavjestenjaJob> logger)
        {
            Context = dbContext;
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            var results = Context.Obavjestenja.Where(x => x.DatumZavrsetka <= DateTime.Now).ToList();

            foreach (var result in results)
            {
                result.StateMachine = "completed";
            }

            Context.SaveChanges();

            _logger.LogInformation("[!!!] CompletedObavjestenja CRON zavrsen.");


            return Task.CompletedTask;
        }
    }
}

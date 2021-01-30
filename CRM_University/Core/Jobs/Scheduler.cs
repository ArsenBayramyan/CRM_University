using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Core.Jobs
{
    public class Scheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<QueryExecuteJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
             .WithCronSchedule("0 * * ? * *")
             .ForJob("job", "group1")
             .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}

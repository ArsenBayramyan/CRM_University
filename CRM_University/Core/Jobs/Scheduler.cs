using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Quartz.MisfireInstruction;

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
            .StartNow()
                .WithSchedule(CronScheduleBuilder.CronSchedule("0 30 9 1,5,10,15,20,25 MAY,DEC ? *"))
            .Build();
            scheduler.ScheduleJob(job, trigger);
        }
    }
}

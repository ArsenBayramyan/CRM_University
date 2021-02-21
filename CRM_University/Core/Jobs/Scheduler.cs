using Quartz;
using Quartz.Impl;

namespace CRM_University.Core.Jobs
{
    public class Scheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
            scheduler.Start();

            IJobDetail firstJob = JobBuilder.Create<QueryExecuteJob>().Build();

            ITrigger firstTrigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartNow()
                .WithSchedule(CronScheduleBuilder.CronSchedule("0 30 9 1,5,10,15,20,25 MAY,DEC ? *"))
            .Build();
            

            IJobDetail secondJob = JobBuilder.Create<ProcedureExecuteJob>().Build();

            ITrigger secondTrigger=TriggerBuilder.Create()
            .WithIdentity("trigger2", "group2")
            .StartNow()
                .WithSchedule(CronScheduleBuilder.CronSchedule(" 0 0 0 ? * FRI *"))
            .Build();

            scheduler.ScheduleJob(firstJob, firstTrigger);
            scheduler.ScheduleJob(secondJob, secondTrigger);
        }
    }
}

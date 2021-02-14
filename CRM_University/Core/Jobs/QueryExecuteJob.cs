using CRM_University.BLL;
using CRM_University.Data.ExecuteComand;
using Quartz;
using System.Threading.Tasks;

namespace CRM_University.Core.Jobs
{
    public class QueryExecuteJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var students = StoredProcedure.GetNonPaidResult();
            foreach (var student in students)
            {
                var message = "usman vardzy vjarel";
                BaseBL.SendEmailMessage(student.Email, message);
            }
            return null;
        }
    }
}

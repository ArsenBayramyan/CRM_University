using CRM_University.Core.Enums;
using CRM_University.Data.Contexts;
using CRM_University.Data.ExecuteComand;
using CRM_University.Data.Models;
using CRM_University.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System;
using System.Threading.Tasks;

namespace CRM_University.Core.Jobs
{
    public class ProcedureExecuteJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var students = StoredProcedure.GetFrequenciesAllResult(80);
            var contextOptions = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseSqlServer(@"Server=DESKTOP-B1TS7RO;Database=CRM_UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
            var context2 = new ApplicationDBContext(contextOptions);
            var uow = new UnitOfWorkRepository(context2);
            foreach (var student in students)
            {
                var message = "bacakayutyan nkatoxutyun eq stacel";
                EmailSender.SendEmail(student.Email, message);
                uow.UnpaidStudentsRepository.Save(new SentEmails { StudentId = student.StudentId, SendEmailDate = DateTime.Now, AlertType = AlertType.SentForAssessment });
            }

            return null;
        }
    }
}

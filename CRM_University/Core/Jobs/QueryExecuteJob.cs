using CRM_University.BLL;
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
    public class QueryExecuteJob : IJob
    {

        public Task Execute(IJobExecutionContext context)
        {
            var students = StoredProcedure.GetNonPaidResult();
            var contextOptions = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseSqlServer(@"Server=localhost;Database=CRM_UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
            var context2 = new ApplicationDBContext(contextOptions);
            var uow = new UnitOfWorkRepository(context2);
            foreach (var student in students)
            {
                var message = "Խնդրում ենք վճարել ուսման վարձը";
                EmailSender.SendEmail(student.Email, message);
                uow.EmailLogRepository.Save(new EmailLog { StudentId = student.StudentId, SendEmailDate = DateTime.Now,AlertType=AlertType.SentForTution });
            }

            return null;
        }
    }
}

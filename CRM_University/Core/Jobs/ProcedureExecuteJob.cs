using CRM_University.Core.Enums;
using CRM_University.Data.Contexts;
using CRM_University.Data.ExecuteComand;
using CRM_University.Data.Models;
using CRM_University.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System;
using System.Linq;
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
            var emailLogs = uow.EmailLogRepository.List();
            var dateNowMonth = DateTime.Now.Month;
            foreach (var student in students)
            {
                if (emailLogs.FirstOrDefault(e=>e.StudentId==student.StudentId) is null)
                {
                    var message = "Դուք ստացել եք նկատողություն 80 ժամից ավել բացակայելու պատճառով";
                    EmailSender.SendEmail(student.Email, message);
                    ReprimandedStudent reprimandedStudent = new ReprimandedStudent();
                    reprimandedStudent.StudentId = student.StudentId;
                    reprimandedStudent.DateOfReprimand = DateTime.Now;
                    uow.ReprimandedStudentRepository.Save(reprimandedStudent);
                    uow.EmailLogRepository.Save(new EmailLog { StudentId = student.StudentId, SendEmailDate = DateTime.Now, AlertType = AlertType.SentForAssessment });
                }
            }

            return null;
        }
    }
}

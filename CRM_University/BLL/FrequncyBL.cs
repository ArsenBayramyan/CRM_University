using CRM_University.Data.Models;
using CRM_University.Data.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace CRM_University.BLL
{
    public class FrequncyBL:BaseBL
    {
        public FrequncyBL(UnitOfWorkRepository unitOfWork) : base(unitOfWork) { }
        
        public void SendEmailForFrequency(List<BaseModel> baseModels)
        {
            foreach (var model in baseModels)
            {
                if (model.Frequency==80)
                {
                    var student = UOW.StudentRepository.GetByID(model.StudentId);
                    var message = "nkatoxutyun";
                    BaseBL.SendEmailMessage(student.Email, message);
                }
            }
        }
    }
}

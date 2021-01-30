using CRM_University.Data.Models;
using CRM_University.Data.Repositories;
using System.Collections.Generic;

namespace CRM_University.BLL
{
    public class TutionPaidBL:BaseBL
    {

        public TutionPaidBL(UnitOfWorkRepository unitOfWork) : base(unitOfWork) { }

        public void SendEmailForTution(List<BaseModel> baseModels)
        {
            foreach (var model in baseModels)
            {
                if (model.Frequency == 80)
                {
                    var student = UOW.StudentRepository.GetByID(model.StudentId);
                    var message = "nkatoxutyun";
                    BaseBL.SendEmailMessage(student.Email, message);
                }
            }
        }
    }
}

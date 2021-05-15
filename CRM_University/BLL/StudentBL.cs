using AutoMapper;
using CRM_University.Data.Models;
using CRM_University.Data.Repositories;
using CRM_University.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CRM_University.BLL
{
    public class StudentBL : BaseBL
    {
        public StudentBL(UnitOfWorkRepository unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public DataTable ExportToExcel(List<BaseModel> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            table.Columns.Add("Faculty Name", typeof(string));
            table.Columns.Add("Group Name", typeof(string));
            table.Columns.Add("Subject Name", typeof(string));
            table.Columns.Add("Result", typeof(byte));
            foreach (var student in list)
            {
                table.Rows.Add(student.StudentFirstName,
                               student.StudentLastName,
                               student.FacultyName,
                               student.GroupName,
                               student.SubjectName,
                               student.ExaminationResult);
            }
            return table;
        }

        public Data.Models.Filter GetExamResult(string subject, string facultyName, string groupName, int studentId, int result)
        {
            var students = from exam in UOW.ExaminationRepository.List()
                           join s in UOW.StudentRepository.List() on exam.StudentId equals s.StudentId
                           join g in UOW.GroupRepository.List() on s.GroupId equals g.GroupId
                           join f in UOW.FacultyRepository.List() on g.FacultyId equals f.FacultyId
                           join sub in UOW.SubjectRepository.List() on exam.SubjectId equals sub.SubjectId
                           select new BaseModel
                           {
                               StudentId = s.StudentId,
                               StudentFirstName = s.FirstName,
                               StudentLastName = s.LastName,
                               FacultyName = f.FacultyName,
                               GroupName = g.GroupName,
                               SubjectName = sub.SubjectName,
                               ExaminationResult = exam.Result
                           };
            if (facultyName != "---- ընտրել ----")
            {
                students = students.Where(f => f.FacultyName == facultyName);
            }
            if (groupName != "---- ընտրել ----")
            {
                students = students.Where(g => g.GroupName == groupName);
            }
            if (studentId != 0)
            {
                students = students.Where(s => s.StudentId == studentId);
            }

            if (result != default(int))
            {
                students = students.Where(s => s.ExaminationResult == result);

            }
            if (subject != "---- ընտրել ----")
            {
                students = students.Where(s => s.SubjectName == subject);
            }
            return new Data.Models.Filter { FilterList = students.ToList() };
        }

        public Data.Models.Filter GetFrequency(int absenceCount, string facultyName, string groupName)
        {
            var ex = (from fr in UOW.FrequenciyRepository.List()
                      join s in UOW.StudentRepository.List() on fr.StudentId equals s.StudentId
                      join g in UOW.GroupRepository.List() on s.GroupId equals g.GroupId
                      join f in UOW.FacultyRepository.List() on g.FacultyId equals f.FacultyId
                      select new BaseModel
                      {
                          StudentId = s.StudentId,
                          StudentFirstName = s.FirstName,
                          StudentLastName = s.LastName,
                          Email = s.Email,
                          FacultyName = f.FacultyName,
                          GroupName = g.GroupName,
                          Absences = UOW.FrequenciyRepository.List().GroupBy(x => x.StudentId).First(x => x.Key == s.StudentId).Sum(x => x.Absences)
                      }).GroupBy(x => x.StudentId).Select(x => x.FirstOrDefault());

            if (facultyName != "---- ընտրել ----")
            {
                ex = ex.Where(f => f.FacultyName == facultyName);
            }
            if (groupName != "---- ընտրել ----")
            {
                ex = ex.Where(g => g.GroupName == groupName);
            }
            ex = ex.Where(a => a.Absences >= absenceCount);

            return new Data.Models.Filter { FilterList = ex.ToList() };

        }

        public Data.Models.Filter GetUnPaidStudents(string facultyName, string groupName)
        {
            var ex = (from st in UOW.StudentRepository.List()
                      join g in UOW.GroupRepository.List() on st.GroupId equals g.GroupId
                      join f in UOW.FacultyRepository.List() on g.FacultyId equals f.FacultyId
                      select new BaseModel
                      {
                          StudentId = st.StudentId,
                          StudentFirstName = st.FirstName,
                          StudentLastName = st.LastName,
                          Email = st.Email,
                          FacultyName = f.FacultyName,
                          GroupName = g.GroupName,
                          FacultyFee = f.Fee,
                          Paid = st.Paid,
                      }).GroupBy(x => x.StudentId).Select(x => x.FirstOrDefault());

            if (facultyName != "---- ընտրել ----")
            {
                ex = ex.Where(f => f.FacultyName == facultyName);
            }
            if (groupName != "---- ընտրել ----")
            {
                ex = ex.Where(g => g.GroupName == groupName);
            }
            ex = ex.Where(e => e.Paid == false);

            return new Data.Models.Filter { FilterList = ex.ToList() };
        }

        public Data.Models.Filter GetAnotherCountryStudents()
        {
            var students = from st in UOW.StudentRepository.List()
                           join g in UOW.GroupRepository.List() on st.GroupId equals g.GroupId
                           join f in UOW.FacultyRepository.List() on g.FacultyId equals f.FacultyId
                           select new BaseModel
                           {
                               StudentId = st.StudentId,
                               StudentFirstName = st.FirstName,
                               StudentLastName = st.LastName,
                               Email = st.Email,
                               FacultyName = f.FacultyName,
                               GroupName = g.GroupName,
                               Country = st.Country,
                               City = st.City,
                               Address = st.Address,
                               Status = st.Status
                           };

            students = students.Where(s => s.Country.Trim() != "Հայաստան");

            return new Data.Models.Filter { FilterList = students.ToList() };
        }

        public Data.Models.Filter GetStudents(string facultyName, string groupName)
        {
            var students = from st in UOW.StudentRepository.List()
                           join g in UOW.GroupRepository.List() on st.GroupId equals g.GroupId
                           join f in UOW.FacultyRepository.List() on g.FacultyId equals f.FacultyId
                           select new BaseModel
                           {
                               StudentId = st.StudentId,
                               StudentFirstName = st.FirstName,
                               StudentLastName = st.LastName,
                               Country = st.Country,
                               City = st.City,
                               Address = st.Address,
                               Email = st.Email,
                               YearOfAdmission = st.YearOfAdmission,
                               FacultyName = f.FacultyName,
                               GroupName = g.GroupName,
                               Status = st.Status
                           };
            if (facultyName != "---- ընտրել ----")
            {
                students = students.Where(f => f.FacultyName == facultyName);
            }
            if (groupName != "---- ընտրել ----")
            {
                students = students.Where(g => g.GroupName == groupName);
            }

            return new Data.Models.Filter { FilterList = students.ToList() };
        }

        public Data.Models.Filter GetForFreeStudents(string facultyName, string groupName)
        {
            var students = from st in UOW.StudentRepository.List()
                           join g in UOW.GroupRepository.List() on st.GroupId equals g.GroupId
                           join f in UOW.FacultyRepository.List() on g.FacultyId equals f.FacultyId
                           select new BaseModel
                           {
                               StudentId = st.StudentId,
                               StudentFirstName = st.FirstName,
                               StudentLastName = st.LastName,
                               Country = st.Country,
                               City = st.City,
                               Address = st.Address,
                               Email = st.Email,
                               YearOfAdmission = st.YearOfAdmission,
                               FacultyName = f.FacultyName,
                               GroupName = g.GroupName,
                               Status = st.Status
                           };
            if (facultyName != "---- ընտրել ----")
            {
                students = students.Where(f => f.FacultyName == facultyName);
            }
            if (groupName != "---- ընտրել ----")
            {
                students = students.Where(g => g.GroupName == groupName);
            }

            students = students.Where(s => s.Status == Core.Enums.StudentStatus.Անվճար);

            return new Data.Models.Filter { FilterList = students.ToList() };
        }

        public Data.Models.Filter GetNotReceiveds()
        {
            var students = from notR in UOW.NotReceivedRepository.List()
                           join st in UOW.StudentRepository.List() on notR.StudentId equals st.StudentId
                           join g in UOW.GroupRepository.List() on notR.GroupId equals g.GroupId
                           join f in UOW.FacultyRepository.List() on notR.FacultyId equals f.FacultyId
                           select new BaseModel
                           {
                               StudentId = st.StudentId,
                               StudentFirstName = st.FirstName,
                               StudentLastName = st.LastName,
                               Country = st.Country,
                               City = st.City,
                               Address = st.Address,
                               Email = st.Email,
                               YearOfAdmission = st.YearOfAdmission,
                               FacultyName = f.FacultyName,
                               GroupName = g.GroupName,
                               Status = st.Status
                           };

            return new Data.Models.Filter { FilterList = students.ToList() };
        }

        public Data.Models.Filter GetStudentMog(string facultyName, string groupName, int studentId, DateTime StartDate, DateTime EndDate)
        {
            var students = from exam in UOW.ExaminationRepository.List()
                           join st in UOW.StudentRepository.List() on exam.StudentId equals st.StudentId
                           join s in UOW.SubjectRepository.List() on exam.SubjectId equals s.SubjectId
                           join g in UOW.GroupRepository.List() on st.GroupId equals g.GroupId
                           join f in UOW.FacultyRepository.List() on g.FacultyId equals f.FacultyId
                           select new BaseModel
                           {
                               StudentId = st.StudentId,
                               StudentFirstName = st.FirstName,
                               StudentLastName = st.LastName,
                               SubjectName = s.SubjectName,
                               ExaminationDay = exam.ExaminationDay,
                               ExaminationResult = exam.Result,
                               MOG = UOW.ExaminationRepository.List().GroupBy(x => x.StudentId).First(x => x.Key == st.StudentId).Average(x => x.Result),
                               FacultyName = f.FacultyName,
                               GroupName = g.GroupName,
                           };


            students = students.Where(f => f.FacultyName == facultyName);
            students = students.Where(g => g.GroupName == groupName);
            students = students.Where(s => s.StudentId == studentId);
            students = students.Where(d => DateTime.Parse(d.ExaminationDay.ToString("dd/MM/yyyy")) >= StartDate && DateTime.Parse(d.ExaminationDay.ToString("dd/MM/yyyy")) <= EndDate);

            return new Data.Models.Filter { FilterList = students.ToList() };

        }

        public Data.Models.Filter GetDiscountStudents(string facultyName, string groupName, int studentId, DateTime StartDate, DateTime EndDate)
        {
            var students = from dis in UOW.DiscountStudentRepository.List()
                           join st in UOW.StudentRepository.List() on dis.StudentId equals st.StudentId
                           join g in UOW.GroupRepository.List() on st.GroupId equals g.GroupId
                           join f in UOW.FacultyRepository.List() on g.FacultyId equals f.FacultyId
                           select new BaseModel
                           {
                               StudentId = st.StudentId,
                               StudentFirstName = st.FirstName,
                               StudentLastName = st.LastName,
                               DiscountName = dis.DiscountName,
                               DiscountDate = dis.DiscountDate,
                               FacultyName = f.FacultyName,
                               GroupName = g.GroupName,
                           };

            if (facultyName != "---- ընտրել ----")
            {
                students = students.Where(f => f.FacultyName == facultyName);
            }
            if (groupName != "---- ընտրել ----")
            {
                students = students.Where(g => g.GroupName == groupName);
            }
            if (studentId != 0)
            {
                students = students.Where(s => s.StudentId == studentId);
            }

            return new Data.Models.Filter { FilterList = students.ToList() };
        }

        public EmailLogViewModel GetEmailLogsForAbsences()
        {
            var students = UOW.StudentRepository.List();
            var studentsViewModels = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentViewModel>>(students);
            var faculties = UOW.FacultyRepository.List();
            var groups = UOW.GroupRepository.List();
            var dateMonth = DateTime.Now.Month;
            EmailLogViewModel emailLog = new EmailLogViewModel();
            IEnumerable<EmailLog> forAbsences;
            if (dateMonth >= 9 && dateMonth <= 12)
            {
                emailLog.Students = studentsViewModels;
                emailLog.Faculties = UOW.FacultyRepository.List();
                emailLog.Groups = UOW.GroupRepository.List();
                forAbsences = UOW.EmailLogRepository.List().Where(a => a.AlertType == Core.Enums.AlertType.SentForAssessment && a.SendEmailDate.Month >= 2 && a.SendEmailDate.Month <= 5);
                IEnumerable<EmailLogViewModel> forAbsencesViewModels = Mapper.Map<IEnumerable<EmailLog>, IEnumerable<EmailLogViewModel>>(forAbsences);
                emailLog.EmailLogs = forAbsencesViewModels;
            }
            else
            {
                emailLog.Students = studentsViewModels;
                emailLog.Faculties = UOW.FacultyRepository.List();
                emailLog.Groups = UOW.GroupRepository.List();
                forAbsences = UOW.EmailLogRepository.List().Where(a => a.AlertType == Core.Enums.AlertType.SentForAssessment && a.SendEmailDate.Month >= 2 && a.SendEmailDate.Month <= 5);
                IEnumerable<EmailLogViewModel> forAbsencesViewModels = Mapper.Map<IEnumerable<EmailLog>, IEnumerable<EmailLogViewModel>>(forAbsences);
                emailLog.EmailLogs = forAbsencesViewModels;

            }


            return emailLog;
        }

        public EmailLogViewModel GetEmailLogsForUnPaids()
        {
            var students = UOW.StudentRepository.List();
            var studentsViewModels = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentViewModel>>(students);
            var faculties = UOW.FacultyRepository.List();
            var groups = UOW.GroupRepository.List();
            var dateMonth = DateTime.Now.Month;
            EmailLogViewModel emailLog = new EmailLogViewModel();
            IEnumerable<EmailLog> forTution;
            if (dateMonth >= 9 && dateMonth <= 12)
            {
                emailLog.Students = studentsViewModels;
                emailLog.Faculties = UOW.FacultyRepository.List();
                emailLog.Groups = UOW.GroupRepository.List();
                forTution = UOW.EmailLogRepository.List().Where(a => a.AlertType == Core.Enums.AlertType.SentForTution && a.SendEmailDate.Month >= 9 && a.SendEmailDate.Month <= 12);
                IEnumerable<EmailLogViewModel> forTutionViewModels = Mapper.Map<IEnumerable<EmailLog>, IEnumerable<EmailLogViewModel>>(forTution);
                emailLog.EmailLogs = forTutionViewModels;
            }
            else
            {
                emailLog.Students = studentsViewModels;
                emailLog.Faculties = UOW.FacultyRepository.List();
                emailLog.Groups = UOW.GroupRepository.List();
                forTution = UOW.EmailLogRepository.List().Where(a => a.AlertType == Core.Enums.AlertType.SentForTution && a.SendEmailDate.Month >= 2 && a.SendEmailDate.Month <= 5);
                IEnumerable<EmailLogViewModel> forTutionViewModels = Mapper.Map<IEnumerable<EmailLog>, IEnumerable<EmailLogViewModel>>(forTution);
                emailLog.EmailLogs = forTutionViewModels;
            }


            return emailLog;
        }

        public ReprimandedStudentViewModel GetReprimandedStudents()
        {
            var students = UOW.StudentRepository.List();
            var studentsViewModels = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentViewModel>>(students);
            var faculties = UOW.FacultyRepository.List();
            var groups = UOW.GroupRepository.List();
            var dateYear = DateTime.Now.Year;
            var dateMonth = DateTime.Now.Month;
            ReprimandedStudentViewModel reprimandedStudentViewModel = new ReprimandedStudentViewModel();
            IEnumerable<ReprimandedStudent> reprimandedStudents;
            reprimandedStudentViewModel.Students = studentsViewModels;
            reprimandedStudentViewModel.Faculties = faculties;
            reprimandedStudentViewModel.Groups = groups;
            if (dateMonth>=9 && dateMonth<=12)
            {
                reprimandedStudents = UOW.ReprimandedStudentRepository.List().Where(r => r.DateOfReprimand.Year == dateYear && r.DateOfReprimand.Month >= 9 && r.DateOfReprimand.Month <= 12);
                var reprimandedStudentViewModels = Mapper.Map<IEnumerable<ReprimandedStudent>, IEnumerable<ReprimandedStudentViewModel>>(reprimandedStudents);
                reprimandedStudentViewModel.ReprimandedStudentViewModels= reprimandedStudentViewModels;
            }
            else
            {
                reprimandedStudents = UOW.ReprimandedStudentRepository.List().Where(r => (r.DateOfReprimand.Year == dateYear || r.DateOfReprimand.Year==dateYear-1) && r.DateOfReprimand.Month >= 2 && r.DateOfReprimand.Month <= 5);
                var reprimandedStudentViewModels = Mapper.Map<IEnumerable<ReprimandedStudent>, IEnumerable<ReprimandedStudentViewModel>>(reprimandedStudents);
                reprimandedStudentViewModel.ReprimandedStudentViewModels = reprimandedStudentViewModels;
            }

            return reprimandedStudentViewModel;
        }
    }

}


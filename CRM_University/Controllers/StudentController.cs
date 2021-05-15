using AutoMapper;
using CRM_University.BLL;
using CRM_University.Core.Enums;
using CRM_University.Core.Interfaces;
using CRM_University.Data.Models;
using CRM_University.Data.Repositories;
using CRM_University.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Controllers
{
    public class StudentController : Controller
    {
        private UnitOfWorkRepository _unitOfWork;
        private IMapper _mapper;

        public StudentController(IUnitOfWorkRepository unitOfWork, IMapper mapper)
        {
            _unitOfWork = (UnitOfWorkRepository)unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExamResult()
        {
            var subjects = _unitOfWork.SubjectRepository.List().Where(s => s.AssessmentCheck == false);
            var faculties = _unitOfWork.FacultyRepository.List();
            var groups = _unitOfWork.GroupRepository.List();
            var students = _unitOfWork.StudentRepository.List();
            var subjectsList = _mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectViewModel>>(subjects);


            return View(new SubjectViewModel { Subjects = subjectsList, Faculties = faculties, Groups = groups, Students = students });
        }

        [HttpPost]
        public IActionResult ExamResult(SubjectViewModel subjectViewModel)
        {
            StudentBL studentBL = new StudentBL(_unitOfWork,_mapper);
            var dalFilter = studentBL.GetExamResult(subjectViewModel.SubjectName, subjectViewModel.FacultyName, subjectViewModel.GroupName, subjectViewModel.StudentId, subjectViewModel.Result);
            var filter = this._mapper.Map<Filter, FilterViewModel>(dalFilter);
            return View("~/Views/Student/ExamResultPost.cshtml", filter);
        }

        [HttpGet]
        public IActionResult GetFrequencies()
        {
            var faculties = _unitOfWork.FacultyRepository.List();
            var groups = _unitOfWork.GroupRepository.List();

            return View(new FrequencyViewModel { Faculties = faculties, Groups = groups });
        }

        [HttpPost]
        public IActionResult GetFrequencies(FrequencyViewModel frequencyViewModel)
        {
            StudentBL studentBL = new StudentBL(_unitOfWork,_mapper);
            var filterForFrequencies = studentBL.GetFrequency(frequencyViewModel.AbsenceCount, frequencyViewModel.FacultyName, frequencyViewModel.GroupName);
            var filterViewModel = this._mapper.Map<Filter, FilterViewModel>(filterForFrequencies);

            return View("~/Views/Student/GetFrequenciesPost.cshtml", filterViewModel);
        }

        [HttpGet]
        public IActionResult UnPaidStudents()
        {
            var faculties = _unitOfWork.FacultyRepository.List();
            var groups = _unitOfWork.GroupRepository.List();

            return View(new UnPaidStudentViewModel { Faculties = faculties, Groups = groups });
        }
        [HttpPost]
        public IActionResult UnPaidStudents(UnPaidStudentViewModel unPaidStudentViewModel)
        {
            StudentBL studentBL = new StudentBL(_unitOfWork,_mapper);
            var filterForUnPaidStudents = studentBL.GetUnPaidStudents(unPaidStudentViewModel.FacultyName, unPaidStudentViewModel.GroupName);
            var filterViewModel = _mapper.Map<Filter, FilterViewModel>(filterForUnPaidStudents);

            return View("~/Views/Student/UnPaidStudentsPost.cshtml", filterViewModel);
        }

        [HttpGet]
        public IActionResult GetAnotherCountryStudents()
        {
            StudentBL studentBL = new StudentBL(_unitOfWork,_mapper);
            var students = studentBL.GetAnotherCountryStudents();
            var studentsViewModel = this._mapper.Map<Filter, FilterViewModel>(students);

            return View(studentsViewModel);
        }

        [HttpGet]
        public IActionResult Students()
        {
            var faculties = _unitOfWork.FacultyRepository.List();
            var groups = _unitOfWork.GroupRepository.List();

            return View(new StudentViewModel { Faculties = faculties, Groups = groups });
        }
        [HttpPost]
        public IActionResult Students(StudentViewModel studentViewModel)
        {
            StudentBL studentBL = new StudentBL(_unitOfWork,_mapper);

            var students = studentBL.GetStudents(studentViewModel.FacultyName, studentViewModel.GroupName);
            var studentsViewModel = this._mapper.Map<Filter, FilterViewModel>(students);

            return View("~/Views/Student/StudentsPost.cshtml", studentsViewModel);
        }

        [HttpGet]
        public JsonResult GetStudentsByGroup(string groupName)
        {
            var group = _unitOfWork.GroupRepository.List().FirstOrDefault(g => g.GroupName == groupName);
            var students = _unitOfWork.StudentRepository.List().Where(s => s.GroupId == group.GroupId);

            return Json(students);
        }
        [HttpGet]
        public JsonResult GetStudents()
        {
            return Json(_unitOfWork.StudentRepository.List());
        }
        [HttpGet]
        public JsonResult GetGroupsByFaculty(string facultyName)
        {
            var faculty = _unitOfWork.FacultyRepository.List().FirstOrDefault(f => f.FacultyName == facultyName);
            var groups = _unitOfWork.GroupRepository.List().Where(g => g.FacultyId == faculty.FacultyId);

            return Json(groups);
        }
        [HttpGet]
        public JsonResult GetGroups()
        {
            return Json(_unitOfWork.GroupRepository.List());
        }

        [HttpGet]
        public IActionResult GetForFreeStudents()
        {
            var faculties = _unitOfWork.FacultyRepository.List();
            var groups = _unitOfWork.GroupRepository.List();

            return View(new StudentViewModel { Faculties = faculties, Groups = groups });
        }

        [HttpPost]
        public IActionResult GetForFreeStudents(StudentViewModel studentViewModel)
        {
            StudentBL studentBL = new StudentBL(_unitOfWork,_mapper);
            var students = studentBL.GetForFreeStudents(studentViewModel.FacultyName, studentViewModel.GroupName);
            var studentsViewModel = this._mapper.Map<Filter, FilterViewModel>(students);

            return View("~/Views/Student/GetForFreeStudentsPost.cshtml", studentsViewModel);
        }

        [HttpGet]
        public IActionResult GetNotReceivedStudents()
        {
            StudentBL studentBL = new StudentBL(_unitOfWork,_mapper);
            var students = studentBL.GetNotReceiveds();
            var studentsViewModel = this._mapper.Map<Filter, FilterViewModel>(students);

            return View(studentsViewModel);
        }

        [HttpGet]
        public IActionResult Mog()
        {
            var faculties = _unitOfWork.FacultyRepository.List();
            var groups = _unitOfWork.GroupRepository.List();
            var students = _unitOfWork.StudentRepository.List();

            return View(new StudentViewModel { Faculties = faculties, Groups = groups, Students = students });
        }
        [HttpPost]
        public IActionResult Mog(StudentViewModel studentViewModel)
        {
            StudentBL studentBL = new StudentBL(_unitOfWork,_mapper);
            var students = studentBL.GetStudentMog(studentViewModel.FacultyName, studentViewModel.GroupName, studentViewModel.StudentId, studentViewModel.StartDate, studentViewModel.EndDate);
            var studentsViewModel = this._mapper.Map<Filter, FilterViewModel>(students);

            return View("~/Views/Student/MogPost.cshtml", studentsViewModel);
        }

        [HttpGet]
        public IActionResult GetDiscountStudents()
        {
            var faculties = _unitOfWork.FacultyRepository.List();
            var groups = _unitOfWork.GroupRepository.List();
            var students = _unitOfWork.StudentRepository.List();

            return View(new StudentViewModel { Faculties = faculties, Groups = groups, Students = students });
        }
        [HttpPost]
        public IActionResult GetDiscountStudents(StudentViewModel studentViewModel)
        {
            StudentBL studentBL = new StudentBL(_unitOfWork,_mapper);
            var students = studentBL.GetDiscountStudents(studentViewModel.FacultyName, studentViewModel.GroupName, studentViewModel.StudentId, studentViewModel.StartDate, studentViewModel.EndDate);
            var studentsViewModel = this._mapper.Map<Filter, FilterViewModel>(students);

            return View("~/Views/Student/GetDiscountStudentsPost.cshtml", studentsViewModel);
        }

        [HttpGet]
        public IActionResult EmailLog() => View();

        public IActionResult EmailLogForAbsences()
        {
            StudentBL studentBL = new StudentBL(_unitOfWork, _mapper);
            var forAbsencesViewModels = studentBL.GetEmailLogsForAbsences();

            return View(forAbsencesViewModels);
        }

        public IActionResult EmailLogForUnPaids()
        {
            StudentBL studentBL = new StudentBL(_unitOfWork, _mapper);
            var forTutionViewModels = studentBL.GetEmailLogsForUnPaids();

            return View(forTutionViewModels);
        }

        public IActionResult ReprimandedStudents()
        {
            StudentBL studentBL = new StudentBL(_unitOfWork, _mapper);
            var reprimandedStudents = studentBL.GetReprimandedStudents();

            return View(reprimandedStudents);
        }

    }
}

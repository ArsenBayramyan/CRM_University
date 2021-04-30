using AutoMapper;
using CRM_University.BLL;
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
            var subjects = _unitOfWork.SubjectRepository.List().Where(s=>s.AssessmentCheck==false);
            var faculties = _unitOfWork.FacultyRepository.List();
            var groups = _unitOfWork.GroupRepository.List();

            var subjectsList = _mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectViewModel>>(subjects);


            return View(new SubjectViewModel { Subjects=subjectsList,Faculties=faculties,Groups=groups});
        }

        [HttpPost]
        public IActionResult ExamResult(SubjectViewModel subjectViewModel)
        {
            StudentBL studentBL = new StudentBL(_unitOfWork);
            var dalFilter = studentBL.GetExamResult(subjectViewModel.SubjectName,subjectViewModel.FacultyName,subjectViewModel.GroupName, subjectViewModel.Result);
            var filter = this._mapper.Map<Filter, FilterViewModel>(dalFilter);
            return View("~/Views/Student/ExamResultPost.cshtml", filter);
        }

        [HttpGet]
        public IActionResult GetFrequencies()
        {
            var faculties = _unitOfWork.FacultyRepository.List();
            var groups = _unitOfWork.GroupRepository.List();

            return View(new FrequencyViewModel { Faculties=faculties,Groups=groups});
        }

        [HttpPost]
        public IActionResult GetFrequencies(FrequencyViewModel frequencyViewModel)
        {
            StudentBL studentBL = new StudentBL(_unitOfWork);
            var filterForFrequencies = studentBL.GetFrequency(frequencyViewModel.AbsenceCount,frequencyViewModel.FacultyName,frequencyViewModel.GroupName);
            var filterViewModel = this._mapper.Map<Filter, FilterViewModel>(filterForFrequencies);

            return View("~/Views/Student/GetFrequenciesPost.cshtml", filterViewModel);
        }

        [HttpGet]
        public IActionResult UnPaidStudents()
        {
            var faculties = _unitOfWork.FacultyRepository.List();
            var groups = _unitOfWork.GroupRepository.List();

            return View(new UnPaidStudentViewModel { Faculties=faculties,Groups=groups});
        }
        [HttpPost]
        public IActionResult UnPaidStudents(UnPaidStudentViewModel unPaidStudentViewModel)
        {
            StudentBL studentBL = new StudentBL(_unitOfWork);
            var filterForUnPaidStudents = studentBL.GetUnPaidStudents(unPaidStudentViewModel.FacultyName, unPaidStudentViewModel.GroupName);
            var filterViewModel = _mapper.Map<Filter, FilterViewModel>(filterForUnPaidStudents);

            return View("~/Views/Student/UnPaidStudentsPost.cshtml", filterViewModel);
        }

        [HttpGet]
        public IActionResult GetAnotherCountryStudents()
        {
            StudentBL studentBL = new StudentBL(_unitOfWork);
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
            StudentBL studentBL = new StudentBL(_unitOfWork);
            var students = studentBL.GetStudents(studentViewModel.FacultyName,studentViewModel.GroupName);
            var studentsViewModel = this._mapper.Map<Filter, FilterViewModel>(students);

            return View("~/Views/Student/StudentsPost.cshtml", studentsViewModel);
        }

        [HttpGet]
        public IActionResult GetForFreeStudents()
        {
            var faculties = _unitOfWork.FacultyRepository.List();
            var groups = _unitOfWork.GroupRepository.List();

            return View( new StudentViewModel { Faculties = faculties, Groups = groups });
        }

        [HttpPost]
        public IActionResult GetForFreeStudents(StudentViewModel studentViewModel)
        {
            StudentBL studentBL = new StudentBL(_unitOfWork);
            var students = studentBL.GetForFreeStudents(studentViewModel.FacultyName, studentViewModel.GroupName);
            var studentsViewModel = this._mapper.Map<Filter, FilterViewModel>(students);

            return View("~/Views/Student/GetForFreeStudentsPost.cshtml", studentsViewModel);
        }

        [HttpGet]
        public IActionResult GetNotReceivedStudents()
        {
            StudentBL studentBL = new StudentBL(_unitOfWork);
            var students = studentBL.GetNotReceiveds();
            var studentsViewModel = this._mapper.Map<Filter, FilterViewModel>(students);

            return View(studentsViewModel);
        }
    }
}

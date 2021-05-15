using AutoMapper;
using CRM_University.Data.Models;
using CRM_University.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Core.Profiles
{
    public class StudentProfile:Profile
    {
        public const string ViewModel = "StudentProfile";
        public override string ProfileName => ViewModel;

        public StudentProfile()
        {
            this.CreateMap<StudentViewModel, Student>();
            this.CreateMap<Student, StudentViewModel>();
        }
    }
}

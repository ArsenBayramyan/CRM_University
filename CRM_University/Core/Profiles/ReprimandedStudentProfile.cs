using AutoMapper;
using CRM_University.Data.Models;
using CRM_University.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Core.Profiles
{
    public class ReprimandedStudentProfile:Profile
    {
        public const string ViewModel = "ReprimandedStudentProfile";
        public override string ProfileName => ViewModel;

        public ReprimandedStudentProfile()
        {
            this.CreateMap<ReprimandedStudent, ReprimandedStudentViewModel>();
            this.CreateMap<ReprimandedStudentViewModel, ReprimandedStudent>();
        }
    }
}

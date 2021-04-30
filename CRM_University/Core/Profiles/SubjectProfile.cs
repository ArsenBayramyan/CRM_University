using AutoMapper;
using CRM_University.Data.Models;
using CRM_University.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Core.Profiles
{
    public class SubjectProfile:Profile
    {
        public const string ViewModel = "SubjectProfile";
        public override string ProfileName => ViewModel;

        public SubjectProfile()
        {
            this.CreateMap<SubjectViewModel, Subject>();
            this.CreateMap<Subject, SubjectViewModel>();
        }
    }

}

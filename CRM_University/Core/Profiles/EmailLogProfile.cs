using AutoMapper;
using CRM_University.Data.Models;
using CRM_University.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Core.Profiles
{
    public class EmailLogProfile:Profile
    {
        public const string ViewModel = "EmailLogProfile";
        public override string ProfileName => ViewModel;

        public EmailLogProfile()
        {
            this.CreateMap<EmailLogViewModel, EmailLog>();
            this.CreateMap<Subject, SubjectViewModel>();
        }
    }
}

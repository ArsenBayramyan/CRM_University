using AutoMapper;
using CRM_University.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Core.Profiles
{
    public class BaseModelProfile : Profile
    {
        public const string ViewModel = "BaseModelProfile";

        public override string ProfileName => ViewModel;
        public BaseModelProfile()
        {
            var t = new Data.Models.BaseModel();
            this.CreateMap< Data.Models.BaseModel,BaseModel>();
        }
    }
}

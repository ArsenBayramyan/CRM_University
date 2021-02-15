using AutoMapper;
using CRM_University.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Core.Profiles
{
    public class FilterModelProfile:Profile
    {
        public const string ViewModel = "FilterModelProfile";

        public override string ProfileName => ViewModel;
        public FilterModelProfile()
        {
            var t = new Data.Models.FilterModel();
            this.CreateMap<Data.Models.FilterModel,FilterModel>();
        }
    }
}

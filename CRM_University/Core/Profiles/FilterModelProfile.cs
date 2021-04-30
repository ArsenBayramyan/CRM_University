using AutoMapper;
using CRM_University.Models.ViewModels;

namespace CRM_University.Core.Profiles
{
    public class FilterModelProfile:Profile
    {
        public const string ViewModel = "FilterModelProfile";

        public override string ProfileName => ViewModel;
        public FilterModelProfile()
        {
            var t = new Data.Models.Filter();
            this.CreateMap<Data.Models.Filter,FilterViewModel>();
        }
    }
}

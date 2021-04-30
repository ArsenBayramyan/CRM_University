using CRM_University.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM_University.Models.ViewModels
{
    public class FrequencyViewModel
    {
        [Display(Name = "Բացակայությունների քանակ")]
        public int AbsenceCount { get; set; }
        [Display(Name = "Ֆակուլտետ")]
        public string FacultyName { get; set; }
        [Display(Name = "Խումբ")]
        public string GroupName { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}

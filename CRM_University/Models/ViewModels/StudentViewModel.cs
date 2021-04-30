using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Models.ViewModels
{
    public class StudentViewModel
    {
        [Display(Name = "Ֆակուլտետ")]
        public string FacultyName { get; set; }
        [Display(Name = "Խումբ")]
        public string GroupName { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}

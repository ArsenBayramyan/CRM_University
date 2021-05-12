using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Models.ViewModels
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }
        [Display(Name ="Քննական առարկա")]
        public string SubjectName { get; set; }
        [Display(Name ="Քննության արդյունքը")]
        public int Result { get; set; }
        [Display(Name = "Ֆակուլտետ")]
        public string FacultyName { get; set; }
        [Display(Name = "Խումբ")]
        public string GroupName { get; set; }
        [Display(Name = "Ուսանող")]
        public int StudentId { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<SubjectViewModel> Subjects { get; set; }
        public IEnumerable<Student> Students { get; set; }

    }
}

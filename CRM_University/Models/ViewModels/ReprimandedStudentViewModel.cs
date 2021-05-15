using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Models.ViewModels
{
    public class ReprimandedStudentViewModel
    {
        [Display(Name ="Ուսանող")]
        public int StudentId { get; set; }
        [Display(Name = "Նկատողություն ստանալու ամսաթիվը")]
        public DateTime DateOfReprimand { get; set; }
        public StudentViewModel Student { get; set; }
        public IEnumerable<ReprimandedStudentViewModel> ReprimandedStudentViewModels { get; set; }
        public IEnumerable<StudentViewModel> Students { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}

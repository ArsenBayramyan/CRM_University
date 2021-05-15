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
        public int FacultyId { get; set; }
        [Display(Name = "Խումբ")]
        public string GroupName { get; set; }
        public int GroupId { get; set; }
        [Display(Name = "ՈՒսանող")]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Ուսումնական փուլի սկիզբ")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Ուսումնական փուլի ավարտ")]
        public DateTime EndDate { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Examination> Examinations { get; set; }
    }
}

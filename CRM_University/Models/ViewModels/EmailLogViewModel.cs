using CRM_University.Core.Enums;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Models.ViewModels
{
    public class EmailLogViewModel
    {
        [Display(Name ="Ուսանող")]
        public int StudentId { get; set; }
        [Display(Name = "ՈՒղարկվելու ամսաթիվը")]
        public DateTime SendEmailDate { get; set; }
        [Display(Name = "Հաղորդագրության տեսակը")]
        public AlertType AlertType { get; set; }
        public StudentViewModel Student { get; set; }
        public IEnumerable<EmailLogViewModel> EmailLogs { get; set; }
        public IEnumerable<StudentViewModel> Students { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}

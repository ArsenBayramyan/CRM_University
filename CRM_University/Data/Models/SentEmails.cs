using CRM_University.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Models
{
    public class SentEmails
    {
        [Key]
        public int StudentId { get; set; }
        public DateTime SendEmailDate { get; set; }
        public AlertType AlertType { get; set; }
    }
}

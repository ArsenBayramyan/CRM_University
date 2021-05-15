using CRM_University.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Models
{
    public class EmailLog
    {
        public int EmailLogId { get; set; }
        public int StudentId { get; set; }
        public DateTime SendEmailDate { get; set; }
        public AlertType AlertType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Models
{
    public class ReprimandedStudent
    {
        public int ReprimandedStudentId { get; set; }
        public int StudentId { get; set; }
        public DateTime DateOfReprimand { get; set; }
    }
}

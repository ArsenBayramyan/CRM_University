using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Models
{
    public class Examination
    {
        public int ExaminationId { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public byte Result { get; set; }
    }
}

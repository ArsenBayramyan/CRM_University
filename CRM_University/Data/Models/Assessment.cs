using CRM_University.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Models
{
    public class Assessment
    {
        public int AssessmentId { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public AssessmentResult Result { get; set; }
    }
}

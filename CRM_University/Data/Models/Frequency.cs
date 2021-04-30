using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Models
{
    public class Frequency
    {
        public int FrequencyId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public byte Absences { get; set; }
    }
}

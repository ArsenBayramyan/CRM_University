using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Models
{
    public class MOG
    {
        public int MOGId { get; set; }
        public DateTime OneParteDate { get; set; }
        public DateTime? TwoParteDate { get; set; }
        public int StudentId { get; set; }
    }
}
